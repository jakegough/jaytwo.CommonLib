using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static double ParseDouble(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseDouble(value, styles, formatProvider);
		}

		public static double ParseDouble(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseDouble(value, styles, formatProvider);
		}

		public static double ParseDouble(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseDouble(value, styles, formatProvider);
		}

		public static double ParseDouble(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return double.Parse(value, styles, formatProvider);
		}

		public static double? TryParseDouble(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseDouble(value, styles, formatProvider);
		}

		public static double? TryParseDouble(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseDouble(value, styles, formatProvider);
		}

		public static double? TryParseDouble(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseDouble(value, styles, formatProvider);
		}

		public static double? TryParseDouble(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			double parsedValue;
			return (double.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (double?)null;
		}
	}
}
