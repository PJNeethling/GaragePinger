using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkBee.Assessment.API.Models
{
    public class Doors : List<Door> { }
    public class Door
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int StatusTypeID { get; set; }
        public DoorStatuses Status => (DoorStatuses)StatusTypeID;
        public bool IsOnline => Status == DoorStatuses.Online ? true : false;
    }

    public class DoorPingResult
    {
        public string IPAddress { get; set; }
        public string StatusMessage { get; set; }
        public int PingStatusTypeID { get; set; }
        public PingStatuses Status => (PingStatuses)PingStatusTypeID;
        public bool IsOnline => Status == PingStatuses.Successful ? true : false;
    }

    public class DoorStatusHistory
    {
        [Key]
        public int ID { get; set; }
        public int DoorID { get; set; }
        public string DoorName { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public enum DoorStatuses
    {
        Unknown = 0,
        Online = 1,
        Busy = 2,
        Offline = 3,
    }

    public enum PingStatuses
    {
        Successful = 1,
        UnSuccessful = 2
    }
}
