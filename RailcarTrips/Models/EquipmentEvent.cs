using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace RailcarTrips.Models
{
    public class EquipmentEvent
    {
        [Key]
        public int Id { get; set; } = 0;
        public int TripId { get; set; } = 0;
        public string EventId { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
        public int CityId { get; set; } = 0;
    }
}
