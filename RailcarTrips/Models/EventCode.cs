using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace RailcarTrips.Models
{
    public class EventCode
    {
        [Key]
        public string Id{  get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
    }
}
