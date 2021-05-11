using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Assessment.API.Models;
using ParkBee.Assessment.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkBee.Assessment.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class DoorController : Controller
    {
        #region Private Fields
        private DoorService _doorService;
        #endregion

        #region Constructor
        public DoorController(ApplicationDbContext context)
        {
            _doorService = new DoorService(context);
        }
        #endregion

        #region Public Methods
        [HttpGet("{id}/Ping")]
        public async Task<DoorPingResult> Ping(int id)
        {
            return await _doorService.PingDoor(id);
        }

        [HttpGet("History")]
        public async Task<List<DoorStatusHistory>> History()
        {
            return await _doorService.GetHistoryList();
        } 
        #endregion
    }
}
