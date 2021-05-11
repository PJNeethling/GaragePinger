using Microsoft.AspNetCore.Mvc;
using ParkBee.Assesment.Framework;
using ParkBee.Assesment.Framework.Domain;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ParkBee.Assesment.Website.Controllers
{
    public class GaragesController : Controller
    {

        #region Public Methods
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<Garages> GetGarages()
        {
            var garages = new Garages();

            using (var bc = new BusinessController())
                garages = bc.GetGarages().Result;

            return garages;
        }

        [HttpGet]
        public async Task<Garage> GetUserGarageInformation()
        {
            var garage = new Garage();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(Context.TokenModel.Token) as JwtSecurityToken;
            var garageID = Int32.Parse(jwtToken.Claims.First(claim => claim.Type == "garageid").Value);

            using (var bc = new BusinessController())
                garage = bc.GetGarageInformation(garageID).Result;

            garage = await ValidateGarageStatusBasedOnDoorStatuses(garage);

            return garage;
        }
        [HttpGet]
        public async Task<Garage> RefreshGarage(int id)
        {
            var garage = new Garage();

            using (var bc = new BusinessController())
                garage = bc.GetGarageInformation(id).Result;

            garage = await ValidateGarageStatusBasedOnDoorStatuses(garage);

            return garage;
        }
        #endregion

        #region Private Methods
        private async Task<Garage> ValidateGarageStatusBasedOnDoorStatuses(Garage garage)
        {
            foreach (var door in garage.Doors)
            {
                var doorPingResut = new DoorPingResult();

                using (var bc = new BusinessController())
                    doorPingResut = await bc.PingDoor(door.ID);

                switch (doorPingResut.Status)
                {
                    case PingStatuses.Successful:
                        door.StatusTypeID = (int)DoorStatuses.Online;
                        break;

                    case PingStatuses.UnSuccessful:
                        door.StatusTypeID = (int)DoorStatuses.Offline;
                        break;
                }
            }

            if (garage.Doors.All(x => x.Status == DoorStatuses.Offline))
                garage.StatusTypeID = (int)GarageStatuses.Offline;
            else
                garage.StatusTypeID = (int)GarageStatuses.Online;

            return garage;
        } 
        #endregion
    }
}