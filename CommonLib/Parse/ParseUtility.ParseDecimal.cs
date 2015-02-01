using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static decimal ParseDecimal(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseDecimal(value, styles, formatProvider);
		}

		public static decimal ParseDecimal(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseDecimal(value, styles, formatProvider);
		}

		public static decimal ParseDecimal(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseDecimal(value, styles, formatProvider);
		}

		public static decimal ParseDecimal(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return decimal.Parse(value, styles, formatProvider);
		}

		public static decimal? TryParseDecimal(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseDecimal(value, styles, formatProvider);
		}

		public static decimal? TryParseDecimal(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseDecimal(value, styles, formatProvider);
		}

		public static decimal? TryParseDecimal(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseDecimal(value, styles, formatProvider);
		}

		public static decimal? TryParseDecimal(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			decimal parsedValue;
			return (decimal.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (decimal?)null;
		}
	}
}
