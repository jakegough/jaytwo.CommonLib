using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class TimeSpanExtensions
	{
		public static double? GetTotalDays(this TimeSpan? value)
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

		public static double? GetTotalHours(this TimeSpan? value)
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

		public static double? GetTotalMinutes(this TimeSpan? value)
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

		public static double? GetTotalTotalSeconds(this TimeSpan? value)
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

		public static double? GetTotalMilliseconds(this TimeSpan? value)
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

		public static TimeSpan TruncateToSecondPrecision(this TimeSpan value)
		{
			var seconds = Math.Floor(value.TotalSeconds);
			return TimeSpan.FromSeconds(seconds);
		}

		public static TimeSpan? TruncateToSecondPrecision(this TimeSpan? value)
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

		public static TimeSpan TruncateToMinutePrecision(this TimeSpan value)
		{
			var minutes = Math.Floor(value.TotalMinutes);
			return TimeSpan.FromMinutes(minutes);
		}

		public static TimeSpan? TruncateToMinutePrecision(this TimeSpan? value)
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
