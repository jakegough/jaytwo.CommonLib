using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Time
{
    public static class TimeUtility
    {
		private static readonly DateTime UnixTimeOrigin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
		private static readonly DateTime LdapTimeOrigin = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

		public static DateTime AddWeekdays(DateTime value, int weekdaysToAdd)
		{
			var step = (weekdaysToAdd > 0) ? 1 : -1;
			var weekdaysAdded = 0;
			var result = value;

			while (Math.Abs(weekdaysAdded) < Math.Abs(weekdaysToAdd))
			{
				result = result.AddDays(step);
				weekdaysAdded += step;

				while (!IsWeekday(result))
				{
					result = result.AddDays(step);
				}
			}

			return result;
		}

        public static bool IsWeekday(DateTime value)
        {
            return !IsWeekend(value);
        }

        public static bool IsWeekend(DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }

		public static string GetHttpTimeString(DateTime utcDate)
        {
            return DateTime.SpecifyKind(utcDate, DateTimeKind.Utc)
				.ToString("ddd, dd MMM yyyy HH:mm:ss ", CultureInfo.InvariantCulture) + "GMT";
        }

        public static string GetHttpTimeString(DateTime? value)
        {
            if (value.HasValue)
            {
                return GetHttpTimeString(value.Value);
            }
            else
            {
                return null;
            }
        }

		public static string GetSortableTimeString(DateTime time)
		{
			return time.ToString("s", CultureInfo.InvariantCulture);
		}

        public static string GetSortableTimeString(DateTime? value)
        {
            if (value.HasValue)
            {
                return GetSortableTimeString(value.Value);
            }
            else
            {
                return null;
            }
        }

		public static string GetIso8601TimeString(DateTime utcTime)
		{
			return DateTime.SpecifyKind(utcTime, DateTimeKind.Utc)
				.ToString("s", CultureInfo.InvariantCulture) + "Z";
		}

        public static string GetIso8601TimeString(DateTime? value)
        {
            if (value.HasValue)
            {
                return GetIso8601TimeString(value.Value);
            }
            else
            {
                return null;
            }
        }

        public static DateTime GetDateTimeFromUnixTime(double unixTime)
        {
            return UnixTimeOrigin.AddSeconds(unixTime);
        }

        public static DateTime? GetDateTimeFromUnixTime(double? value)
        {
            if (value.HasValue)
            {
                return GetDateTimeFromUnixTime(value.Value);
            }
            else
            {
                return null;
            }
        }

        public static double GetUnixTime(DateTime value)
        {
            return value.Subtract(UnixTimeOrigin).TotalSeconds;
        }

        public static double? GetUnixTime(DateTime? value)
        {
            if (value.HasValue)
            {
                return GetUnixTime(value.Value);
            }
            else
            {
                return null;
            }
        }

		public static long GetLdapTimestampFromUtcTime(DateTime utc)
		{
			return utc.Subtract(LdapTimeOrigin).Ticks;
		}

		public static long? GetLdapTimestampFromUtcTime(DateTime? utc)
		{
			if (utc.HasValue)
			{
				return GetLdapTimestampFromUtcTime(utc.Value);
			}
			else
			{
				return null;
			}
		}

		public static DateTime GetUtcTimeFromLdapTimestamp(long activeDirectoryTimestamp)
		{
			// the number of 100-nanosecond intervals that have elapsed since the 0 hour on January 1, 1601 
			// 100 nanoseconds = 0.0001 milliseconds
			// 1 milliseconds = 100 nanoseconds * 10000
			// conveniently, 1 tick = 10000 milliseconds

			return LdapTimeOrigin.AddTicks(activeDirectoryTimestamp);
		}

		public static DateTime? GetUtcTimeFromLdapTimestamp(long? activeDirectoryTimestamp)
		{
			if (activeDirectoryTimestamp.HasValue)
			{
				return GetUtcTimeFromLdapTimestamp(activeDirectoryTimestamp.Value);
			}
			else
			{
				return null;
			}
		}

		public static DateTime TruncateToSecondPrecision(DateTime value)
		{
			return new DateTime(
				value.Year,
				value.Month,
				value.Day,
				value.Hour,
				value.Minute,
				value.Second,
				0,
				value.Kind);
		}

        public static DateTime? TruncateToSecondPrecision(DateTime? value)
        {
            if (value.HasValue)
            {
                return TruncateToSecondPrecision(value.Value);
            }
            else
            {
                return null;
            }
        }

		public static DateTime TruncateToMinutePrecision(DateTime value)
		{
			return new DateTime(
				value.Year,
				value.Month,
				value.Day,
				value.Hour,
				value.Minute,
				0,
				0,
				value.Kind);
		}

        public static DateTime? TruncateToMinutePrecision(DateTime? value)
        {
            if (value.HasValue)
            {
                return TruncateToMinutePrecision(value.Value);
            }
            else
            {
                return null;
            }
        }

        public static bool IsSameDayAs(DateTime value, DateTime other)
        {
            return value.Date == other.Date;
        }

        public static bool IsSameDayOrAfter(DateTime value, DateTime other)
        {
            return IsSameDayAs(value, other) || IsAfter(value, other);
        }

        public static bool IsSameDayOrBefore(DateTime value, DateTime other)
        {
            return IsSameDayAs(value, other) || IsBefore(value, other);
        }

        public static bool IsAfter(DateTime value, DateTime other)
        {
            return value > other;
        }

        public static bool IsBefore(DateTime value, DateTime other)
        {
            return value < other;
        }

        public static bool IsOnOrAfter(DateTime value, DateTime other)
        {
            return value >= other;
        }

        public static bool IsOnOrBefore(DateTime value, DateTime other)
        {
            return value <= other;
        }

        public static double? GetTotalDays(TimeSpan? value)
        {
            if (value.HasValue)
            {
				return value.Value.TotalDays;
            }
            else
            {
                return null;
            }
        }

        public static double? GetTotalHours(TimeSpan? value)
        {
            if (value.HasValue)
            {
				return value.Value.TotalHours;
            }
            else
            {
                return null;
            }
        }

        public static double? GetTotalMinutes(TimeSpan? value)
        {
            if (value.HasValue)
            {
				return value.Value.TotalMinutes;
            }
            else
            {
                return null;
            }
        }

        public static double? GetTotalSeconds(TimeSpan? value)
        {
            if (value.HasValue)
            {
				return value.Value.TotalSeconds;
            }
            else
            {
                return null;
            }
        }

        public static double? GetTotalMilliseconds(TimeSpan? value)
        {
            if (value.HasValue)
            {
				return value.Value.TotalMilliseconds;
            }
            else
            {
                return null;
            }
        }

        public static TimeSpan TruncateToSecondPrecision(TimeSpan value)
        {
            var seconds = Math.Floor(value.TotalSeconds);
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan? TruncateToSecondPrecision(TimeSpan? value)
        {
            if (value.HasValue)
            {
                return TruncateToSecondPrecision(value.Value);
            }
            else
            {
                return null;
            }
        }

        public static TimeSpan TruncateToMinutePrecision(TimeSpan value)
        {
            var minutes = Math.Floor(value.TotalMinutes);
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan? TruncateToMinutePrecision(TimeSpan? value)
        {
            if (value.HasValue)
            {
                return TruncateToMinutePrecision(value.Value);
            }
            else
            {
                return null;
            }
        }
    }
}
