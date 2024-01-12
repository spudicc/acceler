using Acceler.Models;
using System.Data.Entity;

namespace Acceler.DAL
{
    public class AccelerDbContext : DbContext
    {
        public AccelerDbContext() : base("AccelerDbContext")
        { 
        }

        public DbSet<Ride> Rides { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Waypoint> Waypoints { get; set; }
    }
}