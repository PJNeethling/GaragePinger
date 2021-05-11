using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ParkBee.Assessment.API.Services
{
    public class DoorService
    {
        #region Private Fields
        private ApplicationDbContext _context;
        #endregion

        #region Constructor
        public DoorService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        public async Task<DoorPingResult> PingDoor(int id)
        {
            var pingResponse = new DoorPingResult();
            var currentDoor = GetDoor(id);
            var oldDoorStatus = currentDoor.Status;

            //Ping the Door twice after initial ping to check if the door is online.
            for (int i = 1; i <= 3; i++)
            {
                pingResponse = Ping(id);
                if (pingResponse.Status == PingStatuses.Successful)
                    break;
            }

            //Set the door status so that we can save it to our In Memory Database.
            switch (pingResponse.Status)
            {
                case PingStatuses.Successful:
                    currentDoor.StatusTypeID = (int)DoorStatuses.Online;
                    break;

                case PingStatuses.UnSuccessful:
                    currentDoor.StatusTypeID = (int)DoorStatuses.Offline;
                    break;
            }

            _context.Doors.Update(currentDoor);
            await _context.SaveChangesAsync();

            //Only log door history if the status has changed.
            if (oldDoorStatus != currentDoor.Status)
                LogDoorStatusChanged(currentDoor, oldDoorStatus);

            return pingResponse;
        }
        public async Task<List<DoorStatusHistory>> GetHistoryList()
        {
            var historyList = await _context.DoorStatusHistory
               .ToListAsync();

            historyList.ForEach(x => x.DoorName = GetDoor(x.DoorID).Name);

            return historyList;
        }
        #endregion

        #region Private Methods
        private DoorPingResult Ping(int id)
        {
            var pingResult = new DoorPingResult();

            try
            {
                var door = GetDoor(id);
                pingResult.IPAddress = door.IPAddress;
                using (var pinger = new Ping())
                {
                    PingReply reply = pinger.Send(door.IPAddress);
                    var pingable = reply.Status == IPStatus.Success;

                    if (pingable)
                        pingResult.PingStatusTypeID = (int)PingStatuses.Successful;
                    else
                        pingResult.PingStatusTypeID = (int)PingStatuses.UnSuccessful;
                }
            }
            catch (PingException pe)
            {
                pingResult.PingStatusTypeID = (int)PingStatuses.UnSuccessful;
                pingResult.StatusMessage = pe.Message;
            }
            return pingResult;
        }

        private Door GetDoor(int id)
        {
            return _context.Doors.FirstOrDefault(d => d.ID == id);
        }

        private void LogDoorStatusChanged(Door door, DoorStatuses oldDoorStatus)
        {
            var doorStatusHistoryEntry = new DoorStatusHistory()
            {
                DoorID = door.ID,
                Description = $"Status Changed from {oldDoorStatus.ToString()} to {door.Status.ToString()}",
                ModifiedDate = DateTime.Now
            };

            _context.DoorStatusHistory.Add(doorStatusHistoryEntry);
            _context.SaveChanges();
        }
        #endregion
    }
}
