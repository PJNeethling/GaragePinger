using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.API;
using ParkBee.Assessment.API.Models;
using ParkBee.Assessment.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkBee.Assessment.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class GarageController
    {
        #region Private Fields
        private GarageService _garageService;
        #endregion

        #region Constructor
        public GarageController(ApplicationDbContext context)
        {
            _garageService = new GarageService(context);
        }

        #endregion
        #region Public Methods
        [HttpGet("Get")]
        public async Task<IEnumerable<Garage>> Get()
        {
            return await _garageService.GetGarages();
        }

        [HttpGet("Get/{id}")]
        public async Task<Garage> GarageInformation(int id)
        {
            return await _garageService.GarageInformation(id);
        } 
        #endregion
    }
}