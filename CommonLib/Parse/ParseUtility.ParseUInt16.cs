using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
        [CLSCompliant(false)]
		public static ushort ParseUInt16(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort ParseUInt16(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort ParseUInt16(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort ParseUInt16(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ushort.Parse(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			ushort parsedValue;
			return (ushort.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (ushort?)null;
		}
	}
}
