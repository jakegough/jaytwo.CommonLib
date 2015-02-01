using jaytwo.Common.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jaytwo.Common.Extensions
{
	public static class TimeSpanExtensions
	{
        public static double? GetTotalDays(this TimeSpan? value)
		{
            return TimeUtility.GetTotalDays(value);
		}

        public static double? GetTotalHours(this TimeSpan? value)
		{
            return TimeUtility.GetTotalHours(value);
		}

		public static double? GetTotalMinutes(this TimeSpan? value)
		{
            return TimeUtility.GetTotalMinutes(value);
		}

        public static double? GetTotalSeconds(this TimeSpan? value)
		{
            return TimeUtility.GetTotalSeconds(value);
		}

		public static double? GetTotalMilliseconds(this TimeSpan? value)
		{
            return TimeUtility.GetTotalMilliseconds(value);
		}

		public static TimeSpan TruncateToSecondPrecision(this TimeSpan value)
		{
            return TimeUtility.TruncateToSecondPrecision(value);
		}

		public static TimeSpan? TruncateToSecondPrecision(this TimeSpan? value)
		{
            return TimeUtility.TruncateToSecondPrecision(value);
		}

		public static TimeSpan TruncateToMinutePrecision(this TimeSpan value)
		{
            return TimeUtility.TruncateToMinutePrecision(value);
		}

		public static TimeSpan? TruncateToMinutePrecision(this TimeSpan? value)
		{
            return TimeUtility.TruncateToMinutePrecision(value);
		}
	}
}