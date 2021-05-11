using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Assesment.Framework;
using ParkBee.Assesment.Framework.Domain;

namespace ParkBee.Assesment.Website.Controllers
{
    public class DoorStatusHistoryController : Controller
    {
        #region Public Methods
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<DoorStatusHistoryList> GetDoorStatusHistoryList()
        {
            var historyList = new DoorStatusHistoryList();

            using (var bc = new BusinessController())
                historyList = await bc.GetDoorStatusHistoryList();

            return historyList;
        } 
        #endregion
    }
}