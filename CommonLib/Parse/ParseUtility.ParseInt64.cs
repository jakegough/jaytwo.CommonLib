using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static long ParseInt64(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseInt64(value, styles, formatProvider);
		}

		public static long ParseInt64(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseInt64(value, styles, formatProvider);
		}

		public static long ParseInt64(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseInt64(value, styles, formatProvider);
		}

		public static long ParseInt64(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return long.Parse(value, styles, formatProvider);
		}

		public static long? TryParseInt64(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseInt64(value, styles, formatProvider);
		}

		public static long? TryParseInt64(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseInt64(value, styles, formatProvider);
		}

		public static long? TryParseInt64(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseInt64(value, styles, formatProvider);
		}

		public static long? TryParseInt64(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			long parsedValue;
			return (long.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (long?)null;
		}
	}
}
