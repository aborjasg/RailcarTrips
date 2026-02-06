using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RailcarTrips.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<RailcarTrip> RailcarTrips { get; set; }
        public DbSet<EquipmentEvent> EquipmentEvents { get; set; }
        public DbSet<EventCode> EventCodes { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
