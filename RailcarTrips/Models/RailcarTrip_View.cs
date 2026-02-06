using System.ComponentModel.DataAnnotations.Schema;

namespace RailcarTrips.Models
{
    [NotMapped]
    public class RailcarTrip_View: RailcarTrip
    {
        public string OriginCityName { get; set; } = string.Empty;
        public string DestinationCityName { get; set; } = string.Empty;
    }
}
