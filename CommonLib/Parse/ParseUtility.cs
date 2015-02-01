using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Xml;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
		private static readonly Encoding Encoding = Encoding.UTF8;
		private static readonly CultureInfo UsCulture = new CultureInfo("en-US");
		private static readonly CultureInfo DefaultCulture = CultureInfo.InvariantCulture;
		private static readonly DateTimeStyles DefaultDateTimeStyles = DateTimeStyles.None;
		private static readonly NumberStyles DefaultNumberStyles = NumberStyles.Any;

		private static IFormatProvider GetFormatProvider(DateTimeStyles styles)
		{
			return DefaultCulture;
		}

		private static IFormatProvider GetFormatProvider(NumberStyles styles)
		{
			return ((styles & NumberStyles.AllowCurrencySymbol) > 0) ? UsCulture : DefaultCulture;
		}

		private static NumberStyles GetStyles(string value)
		{
			return DefaultNumberStyles;
		}

		public static T ParseEnum<T>(string value) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new NotSupportedException("T must be an Enum");
			}

			return (T)Enum.Parse(typeof(T), value, true);
		}

		public static T? TryParseEnum<T>(string value) where T : struct
		{
			try
			{
				return ParseEnum<T>(value);
			}
			catch
			{
				return null;
			}
		}

		public static Guid ParseGuid(string value)
		{
			return new Guid(value);
		}

		public static Guid? TryParseGuid(string value)
		{
			try
			{
				return ParseGuid(value);
			}
			catch
			{
				return null;
			}
		}
	}
}
