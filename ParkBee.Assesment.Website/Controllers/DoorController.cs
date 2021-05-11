using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Assesment.Framework;
using ParkBee.Assesment.Framework.Domain;

namespace ParkBee.Assesment.Website.Controllers
{
    public class DoorController : Controller
    {
        #region Public Methods
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<DoorPingResult> PingDoor(int id)
        {
            var pingResult = new DoorPingResult();

            using (var bc = new BusinessController())
                pingResult = bc.PingDoor(id).Result;

            return pingResult;
        } 
        #endregion
    }
}