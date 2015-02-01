using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
        [CLSCompliant(false)]
		public static ulong ParseUInt64(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseUInt64(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong ParseUInt64(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseUInt64(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong ParseUInt64(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseUInt64(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong ParseUInt64(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ulong.Parse(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseUInt64(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseUInt64(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseUInt64(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			ulong parsedValue;
			return (ulong.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (ulong?)null;
		}
	}
}
