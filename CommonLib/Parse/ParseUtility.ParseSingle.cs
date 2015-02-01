using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static float ParseSingle(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseSingle(value, styles, formatProvider);
		}

		public static float ParseSingle(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseSingle(value, styles, formatProvider);
		}

		public static float ParseSingle(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseSingle(value, styles, formatProvider);
		}

		public static float ParseSingle(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return float.Parse(value, styles, formatProvider);
		}

		public static float? TryParseSingle(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseSingle(value, styles, formatProvider);
		}

		public static float? TryParseSingle(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseSingle(value, styles, formatProvider);
		}

		public static float? TryParseSingle(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseSingle(value, styles, formatProvider);
		}

		public static float? TryParseSingle(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			float parsedValue;
			return (float.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (float?)null;
		}
	}
}
