using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static int ParseInt32(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseInt32(value, styles, formatProvider);
		}

		public static int ParseInt32(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseInt32(value, styles, formatProvider);
		}

		public static int ParseInt32(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseInt32(value, styles, formatProvider);
		}

		public static int ParseInt32(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return int.Parse(value, styles, formatProvider);
		}

		public static int? TryParseInt32(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseInt32(value, styles, formatProvider);
		}

		public static int? TryParseInt32(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseInt32(value, styles, formatProvider);
		}

		public static int? TryParseInt32(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseInt32(value, styles, formatProvider);
		}

		public static int? TryParseInt32(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			int parsedValue;
			return (int.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (int?)null;
		}
	}
}
