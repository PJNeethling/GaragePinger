using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.API.Models;

namespace ParkBee.Assessment.API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorStatusHistory> DoorStatusHistory { get; set; }
    }
}