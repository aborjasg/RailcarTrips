using System.ComponentModel.DataAnnotations.Schema;

namespace RailcarTrips.Models
{
    [NotMapped]
    public class EquipmentEvent_View: EquipmentEvent
    {
        public string EventDescription { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public string CityTimeZone { get; set; } = string.Empty;
    }
}
