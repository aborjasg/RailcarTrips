using System.ComponentModel.DataAnnotations.Schema;

namespace RailcarTrips.Models
{
    [NotMapped]
    internal class EquipmentEvent_Import
    {
        public string EquipmentId { get; set; } = string.Empty;
        public string EventCode { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
        public int CityId { get; set; } = 0;
    }
}
