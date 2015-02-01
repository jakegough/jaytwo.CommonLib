using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		public static byte ParseByte(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseByte(value, styles, formatProvider);
		}

		public static byte ParseByte(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseByte(value, styles, formatProvider);
		}

		public static byte ParseByte(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseByte(value, styles, formatProvider);
		}

		public static byte ParseByte(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return byte.Parse(value, styles, formatProvider);
		}

		public static byte? TryParseByte(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseByte(value, styles, formatProvider);
		}

		public static byte? TryParseByte(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseByte(value, styles, formatProvider);
		}

		public static byte? TryParseByte(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseByte(value, styles, formatProvider);
		}

		public static byte? TryParseByte(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			byte parsedValue;
			return (byte.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (byte?)null;
		}
	}
}
