using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkBee.Assessment.API.Services
{
    public class GarageService
    {
        #region Private Fields
        private ApplicationDbContext _context;
        #endregion

        #region Constructor
        public GarageService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        public async Task<IEnumerable<Garage>> GetGarages()
        {
            var garages = await _context.Garages
                .ToListAsync();
            return garages;
        }

        public async Task<Garage> GarageInformation(int id)
        {
            var garage = await _context.Garages.Include(d => d.Doors)
                .FirstOrDefaultAsync(gar => gar.ID == id);

            return garage;
        } 
        #endregion
    }
}
