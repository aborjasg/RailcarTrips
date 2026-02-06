using System.ComponentModel.DataAnnotations;

namespace RailcarTrips.Models
{
    public class RailcarTrip
    {
        [Key]
        public int TripId { get; set; } = 0;
        public string EquipmetId { get; set; } = string.Empty;
        public int OriginCityId { get; set; } = 0;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public int DestinationCityId { get; set; } = 0;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        public double TotalTripHours { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    }
}