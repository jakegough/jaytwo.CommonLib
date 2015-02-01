using jaytwo.Common.Time;
using System;
using System.Globalization;

namespace jaytwo.Common.Extensions
{
	public static class DateTimeExtensions
	{
		public static bool IsWeekend(this DateTime value)
		{
			return TimeUtility.IsWeekend(value);
		}

		public static bool IsWeekday(this DateTime value)
		{
			return TimeUtility.IsWeekday(value);
		}

		public static DateTime AddWeekdays(this DateTime value, int weekdaysToAdd)
		{
			return TimeUtility.AddWeekdays(value, weekdaysToAdd);
		}

		public static bool IsSameDayAs(this DateTime value, DateTime other)
		{
            return TimeUtility.IsSameDayAs(value, other);
		}

		public static bool IsSameDayOrAfter(this DateTime value, DateTime other)
		{
            return TimeUtility.IsSameDayOrAfter(value, other);
		}

		public static bool IsSameDayOrBefore(this DateTime value, DateTime other)
		{
            return TimeUtility.IsSameDayOrBefore(value, other);
		}

		public static bool IsAfter(this DateTime value, DateTime other)
		{
            return TimeUtility.IsAfter(value, other);
		}

		public static bool IsBefore(this DateTime value, DateTime other)
		{
            return TimeUtility.IsBefore(value, other);
		}

		public static bool IsOnOrAfter(this DateTime value, DateTime other)
		{
            return TimeUtility.IsOnOrAfter(value, other);
		}

		public static bool IsOnOrBefore(this DateTime value, DateTime other)
		{
            return TimeUtility.IsOnOrBefore(value, other);
		}

		public static DateTime TruncateToSecondPrecision(this DateTime value)
		{
            return TimeUtility.TruncateToSecondPrecision(value);
		}

		public static DateTime? TruncateToSecondPrecision(this DateTime? value)
		{
            return TimeUtility.TruncateToSecondPrecision(value);
		}

		public static DateTime TruncateToMinutePrecision(this DateTime value)
		{
			return TimeUtility.TruncateToMinutePrecision(value);
		}

		public static DateTime? TruncateToMinutePrecision(this DateTime? value)
		{
            return TimeUtility.TruncateToMinutePrecision(value);
		}

		public static DateTime WithKind(this DateTime value, DateTimeKind kind)
		{
			return DateTime.SpecifyKind(value, kind);
		}

		public static DateTime? WithKind(this DateTime? value, DateTimeKind kind)
		{
			if (value.HasValue)
			{
				return WithKind(value.Value, kind);
			}
			else
			{
				return null;
			}
		}
	}
}