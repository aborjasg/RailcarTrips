using RailcarTrips.Models;

namespace RailcarTrips.Utils
{
    public static class SharedFunctions
    {
        public static DateTime ConvertToUtcTime(List<City> list, DateTime localTime, int cityId)
        {
            var timeZone = list.FirstOrDefault(x => x.Id == cityId)!.TimeZone;
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            var utcTime = TimeZoneInfo.ConvertTimeToUtc(localTime, tz);
            return utcTime;
        }
    }
}
