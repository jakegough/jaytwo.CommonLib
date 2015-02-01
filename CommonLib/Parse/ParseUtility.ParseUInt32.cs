using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
        [CLSCompliant(false)]
		public static uint ParseUInt32(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint ParseUInt32(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint ParseUInt32(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint ParseUInt32(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return uint.Parse(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			uint parsedValue;
			return (uint.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (uint?)null;
		}
	}
}
