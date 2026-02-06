using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailcarTrips.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
    }
}
