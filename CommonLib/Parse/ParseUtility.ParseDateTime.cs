using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static DateTime ParseDateTime(string value)
		{
			var formatProvider = GetFormatProvider(DefaultDateTimeStyles);
			return ParseDateTime(value, DefaultDateTimeStyles, formatProvider);
		}

		public static DateTime ParseDateTime(string value, DateTimeStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseDateTime(value, styles, formatProvider);
		}

		public static DateTime ParseDateTime(string value, IFormatProvider formatProvider)
		{
			return ParseDateTime(value, DefaultDateTimeStyles, formatProvider);
		}

		public static DateTime ParseDateTime(string value, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			return DateTime.Parse(value, formatProvider, styles);
		}

		public static DateTime? TryParseDateTime(string value)
		{
			var formatProvider = GetFormatProvider(DefaultDateTimeStyles);
			return TryParseDateTime(value, DefaultDateTimeStyles, formatProvider);
		}

		public static DateTime? TryParseDateTime(string value, DateTimeStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseDateTime(value, styles, formatProvider);
		}

		public static DateTime? TryParseDateTime(string value, IFormatProvider formatProvider)
		{
			return TryParseDateTime(value, DefaultDateTimeStyles, formatProvider);
		}

		public static DateTime? TryParseDateTime(string value, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			DateTime parsedValue;
			return (DateTime.TryParse(value, formatProvider, styles, out parsedValue))
				? parsedValue
				: (DateTime?)null;
		}
	}
}
