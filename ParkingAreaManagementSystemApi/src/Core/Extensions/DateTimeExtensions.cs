namespace Core.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToTimeZone(this DateTime dateTime, string timeZoneId = "Turkey Standard Time")
    {
        var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        var time = TimeZoneInfo.ConvertTime(dateTime, zone);

        return DateTime.SpecifyKind(time, DateTimeKind.Utc);
    }
}