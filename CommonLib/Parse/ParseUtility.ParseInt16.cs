using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static short ParseInt16(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(DefaultNumberStyles);
			return ParseInt16(value, styles, formatProvider);
		}

		public static short ParseInt16(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseInt16(value, styles, formatProvider);
		}

		public static short ParseInt16(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseInt16(value, styles, formatProvider);
		}

		public static short ParseInt16(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return short.Parse(value, styles, formatProvider);
		}

		public static short? TryParseInt16(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseInt16(value, styles, formatProvider);
		}

		public static short? TryParseInt16(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseInt16(value, styles, formatProvider);
		}

		public static short? TryParseInt16(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseInt16(value, styles, formatProvider);
		}

		public static short? TryParseInt16(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			short parsedValue;
			return (short.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (short?)null;
		}
	}
}
