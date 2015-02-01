using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
        [CLSCompliant(false)]
		public static sbyte ParseSByte(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return ParseSByte(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte ParseSByte(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return ParseSByte(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte ParseSByte(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return ParseSByte(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte ParseSByte(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return sbyte.Parse(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(string value)
		{
			var styles = GetStyles(value);
			var formatProvider = GetFormatProvider(styles);
			return TryParseSByte(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(string value, NumberStyles styles)
		{
			var formatProvider = GetFormatProvider(styles);
			return TryParseSByte(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(string value, IFormatProvider formatProvider)
		{
			var styles = GetStyles(value);
			return TryParseSByte(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			sbyte parsedValue;
			return (sbyte.TryParse(value, styles, formatProvider, out parsedValue))
				? parsedValue
				: (sbyte?)null;
		}
	}
}
