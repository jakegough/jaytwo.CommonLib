using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jaytwo.CommonLib.Time
{
    public class TimeUtility
    {
        public static readonly DateTime UNIX_TIME_ORIGIN = new DateTime(1970, 1, 1);

        public static bool TryGetUniversalTime(DateTime localTime, string localTimeZoneId, out DateTime utcTime)
        {
            return TryConvertTime(
                localTime,
                out utcTime,
                x => GetUniversalTime(x, localTimeZoneId));
        }

        public static bool TryGetLocalTime(DateTime utcTime, string localTimeZoneId, out DateTime localTime)
        {
            return TryConvertTime(
                utcTime,
                out localTime,
                x => GetLocalTime(x, localTimeZoneId));
        }

        private static bool TryConvertTime(DateTime sourceTime, out DateTime targetTime, Func<DateTime, DateTime> convertMethod)
        {
            try
            {
                targetTime = convertMethod.Invoke(sourceTime);
            }
            catch (Exception ex)
            {
                string message = string.Format("Could not convert time. ({0})", ex.Message);
                
                targetTime = DateTime.MinValue;
                return false;
            }

            return true;
        }

        public static DateTime GetLocalTime(DateTime utcTime, string localTimeZoneId)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById(localTimeZoneId);

            if (localTimeZone.HasSameRules(TimeZoneInfo.Local))
            {
                return DateTime.SpecifyKind(utcTime, DateTimeKind.Utc).ToLocalTime();
            }
            else
            {
                DateTimeOffset utc = DateTime.SpecifyKind(utcTime, DateTimeKind.Utc);
                DateTimeOffset thisServerTime = utc.ToLocalTime();
                DateTimeOffset localTime = TimeZoneInfo.ConvertTime(thisServerTime, localTimeZone);
                return localTime.DateTime;
            }            
        }

        public static DateTime GetUniversalTime(DateTime localTime, string localTimeZoneId)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById(localTimeZoneId);

            if (localTimeZone.HasSameRules(TimeZoneInfo.Local))
            {
                return DateTime.SpecifyKind(localTime, DateTimeKind.Local).ToUniversalTime();
            }
            else
            {
                localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Unspecified);                
                DateTimeOffset thisServerTime = TimeZoneInfo.ConvertTime(localTime, localTimeZone, TimeZoneInfo.Local);
                return thisServerTime.DateTime.ToUniversalTime();
            }            
        }

        public static DateTime ConvertTimeZone(DateTime sourceTime, string sourceTimeZoneId, string targetTimeZoneId)
        {
            DateTime sourceUtcTime = GetUniversalTime(sourceTime, sourceTimeZoneId);
            DateTime targetLocalTime = GetLocalTime(sourceUtcTime, targetTimeZoneId);
            return targetLocalTime;
        }

        public static bool IsWeekday(DateTime value)
        {
            return !IsWeekend(value);
        }

        public static bool IsWeekend(DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }

        public static string GetHttpDate()
        {
            return GetHttpDate(DateTime.UtcNow);
        }
        public static string GetHttpDate(DateTime utcDate)
        {
            return utcDate.ToString("ddd, dd MMM yyyy HH:mm:ss ", System.Globalization.CultureInfo.InvariantCulture) + "GMT";
        }
        public static DateTime ParseHttpDate(string httpDate)
        {
            DateTime result;
            if (!DateTime.TryParse(httpDate, out result))
            {
                result = UNIX_TIME_ORIGIN;
            }
            return result;
        }

        public static string GetISO8601Date()
        {
            return GetISO8601Date(DateTime.UtcNow);
        }
        public static string GetISO8601Date(DateTime utcDate)
        {
            return utcDate.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static DateTime GetDateTimeFromUnixTime(double unixTime)
        {
            return UNIX_TIME_ORIGIN.AddSeconds(unixTime);
        }
        public static double GetUnixTime(DateTime date)
        {
            return date.Subtract(UNIX_TIME_ORIGIN).TotalSeconds;
        }
    }
}
