using System;
using System.Globalization;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class DateTimeExtensions
	{
		public static bool IsWeekend(this DateTime value)
		{
			return value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday;
		}

		public static bool? IsWeekend(this DateTime? value)
		{
			if (value.HasValue)
			{
				return IsWeekend(value.Value);
			}
			else
			{
				return null;
			}
		}

		public static bool IsWeekday(this DateTime value)
		{
			return !IsWeekend(value);
		}

		public static bool? IsWeekday(this DateTime? value)
		{
			if (value.HasValue)
			{
				return IsWeekday(value.Value);
			}
			else
			{
				return null;
			}
		}

		public static DateTime AddWeekdays(this DateTime value, int weekdaysToAdd)
		{
			// 5 of every 7 days is a weekday
			var step = (weekdaysToAdd > 0) ? 1 : -1;
			var weekdaysAdded = 0;
			var result = value;

			while (weekdaysAdded != weekdaysToAdd)
			{
				result = result.AddDays(step);
				weekdaysAdded += step;

				if (!IsWeekday(result))
				{
					result = result.AddDays(step);				
				}
			}

			return result;
		}

		public static DateTime? AddWeekdays(this DateTime? value, int weekdaysToAdd)
		{
			if (value.HasValue)
			{
				return AddWeekdays(value.Value, weekdaysToAdd);
			}
			else
			{
				return null;
			}
		}

		public static bool IsSameDayAs(this DateTime value, DateTime other)
		{
			return value.Date == other.Date;
		}

		public static bool? IsSameDayAs(this DateTime? value, DateTime other)
		{
			if (value.HasValue)
			{
				return IsSameDayAs(value.Value, other);
			}
			else
			{
				return null;
			}
		}

		public static bool IsSameDayOrAfter(this DateTime value, DateTime other)
		{
			return value.IsSameDayAs(other) || value.IsAfter(other);
		}

		public static bool? IsSameDayOrAfter(this DateTime? value, DateTime other)
		{
			if (value.HasValue)
			{
				return IsSameDayOrAfter(value.Value, other);
			}
			else
			{
				return null;
			}
		}

		public static bool IsSameDayOrBefore(this DateTime value, DateTime other)
		{
			return value.IsSameDayAs(other) || value.IsBefore(other);
		}

		public static bool? IsSameDayOrBefore(this DateTime? value, DateTime other)
		{
			if (value.HasValue)
			{
				return IsSameDayOrBefore(value.Value, other);
			}
			else
			{
				return null;
			}
		}

		public static bool IsAfter(this DateTime value, DateTime other)
		{
			return value > other;
		}

		public static bool? IsAfter(this DateTime? value, DateTime other)
		{
			if (value.HasValue)
			{
				return IsAfter(value.Value, other);
			}
			else
			{
				return null;
			}
		}

		public static bool IsBefore(this DateTime value, DateTime other)
		{
			return value < other;
		}

		public static bool? IsBefore(this DateTime? value, DateTime other)
		{
			if (value.HasValue)
			{
				return IsBefore(value.Value, other);
			}
			else
			{
				return null;
			}
		}

		public static bool IsOnOrAfter(this DateTime value, DateTime other)
		{
			return value >= other;
		}

		public static bool? IsOnOrAfter(this DateTime? value, DateTime other)
		{
			if (value.HasValue)
			{
				return IsOnOrAfter(value.Value, other);
			}
			else
			{
				return null;
			}
		}

		public static bool IsOnOrBefore(this DateTime value, DateTime other)
		{
			return value <= other;
		}

		public static bool? IsOnOrBefore(this DateTime? value, DateTime other)
		{
			if (value.HasValue)
			{
				return IsOnOrBefore(value.Value, other);
			}
			else
			{
				return null;
			}
		}

		public static DateTime TruncateToSecondPrecision(this DateTime value)
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

		public static DateTime? TruncateToSecondPrecision(this DateTime? value)
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

		public static DateTime TruncateToMinutePrecision(this DateTime value)
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

		public static DateTime? TruncateToMinutePrecision(this DateTime? value)
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

		public static string ToSortableTimeString(this DateTime time)
		{
			return time.ToString("s", CultureInfo.InvariantCulture);
		}

		public static string ToSortableTimeString(this DateTime? time)
		{
			if (time.HasValue)
			{
				return ToSortableTimeString(time.Value);
			}
			else
			{
				return null;
			}
		}

		public static string UtcTimeToISO8601TimeString(this DateTime utcTime)
		{
			return utcTime.ToString("s", CultureInfo.InvariantCulture) + "Z";
		}

		public static string UtcTimeToISO8601TimeString(this DateTime? utcTime)
		{
			if (utcTime.HasValue)
			{
				return UtcTimeToISO8601TimeString(utcTime.Value);
			}
			else
			{
				return null;
			}
		}

		public static DateTime SpecifyKind(this DateTime value, DateTimeKind kind)
		{
			return DateTime.SpecifyKind(value, kind);
		}

		public static DateTime? SpecifyKind(this DateTime? value, DateTimeKind kind)
		{
			if (value.HasValue)
			{
				return SpecifyKind(value.Value, kind);
			}
			else
			{
				return null;
			}
		}
	}
}