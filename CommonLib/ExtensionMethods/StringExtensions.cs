using System.Text;
using System;
using System.Globalization;
using System.Web;

using jaytwo.CommonLib.Web;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class StringExtensions
	{
		// See notes with Gartner.Core.Xml.StringExtensions.FilterInvalidXmlCharacters method
		public static string FilterCharactersThatAreInvalidInXml(this string extendedString)
		{
			if (string.IsNullOrWhiteSpace(extendedString))
			{
				return extendedString;
			}

			return extendedString
				// Start of Heading (SOH) => remove
				.Replace(((char)0x1).ToString(), string.Empty)
				// Vertical Tab => replace with space
				.Replace((char)0xB, ' ');
		}

		public static string FormatWith(this string extendedString, params object[] args)
		{
			return extendedString.FormatWith(CultureInfo.InvariantCulture, args);
		}

		public static string FormatWith(this string extendedString, CultureInfo cultureInfo, params object[] args)
		{
			if (extendedString == null)
			{
				throw new NullReferenceException();
			}

			return string.Format(cultureInfo, extendedString, args);
		}

		public static string HtmlDecode(this string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return HttpUtility.HtmlDecode(value);
		}

		public static string HtmlEncode(this string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return HttpUtility.HtmlEncode(value);
		}

		public static string PercentEncode(this string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return UrlUtility.PercentEncode(value);
		}

		public static string PercentEncodePath(this string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return UrlUtility.PercentEncodePath(value);
		}

		public static string UrlDecode(this string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return HttpUtility.UrlDecode(value);
		}

		public static bool? TryParseBool(this string value)
		{
			bool parsedValue;
			return (bool.TryParse(value, out parsedValue))
				? parsedValue
				: (bool?)null;
		}

		public static DateTime? TryParseDateTime(this string value, DateTimeStyles styles)
		{
			var provider = (styles > 0)
				? new CultureInfo("en-US")
				: CultureInfo.InvariantCulture;

			DateTime parsedValue;
			return (DateTime.TryParse(value, provider, styles, out parsedValue))
				? parsedValue
				: (DateTime?)null;
		}

		public static DateTime? TryParseDateTime(this string value)
		{
			return TryParseDateTime(value, DateTimeStyles.None);
		}

		public static decimal? TryParseDecimal(this string value, NumberStyles styles)
		{
			var provider = ((styles & NumberStyles.AllowCurrencySymbol) > 0)
				? new CultureInfo("en-US")
				: CultureInfo.InvariantCulture;

			decimal parsedValue;
			return (decimal.TryParse(value, styles, provider, out parsedValue))
				? parsedValue
				: (decimal?)null;
		}

		public static decimal? TryParseDecimal(this string value)
		{
			return value.TryParseDecimal(NumberStyles.Any);
		}

		public static double? TryParseDouble(this string value, NumberStyles styles)
		{
			var provider = ((styles & NumberStyles.AllowCurrencySymbol) > 0)
				? new CultureInfo("en-US")
				: CultureInfo.InvariantCulture;

			double parsedValue;
			return (double.TryParse(value, styles, provider, out parsedValue))
				? parsedValue
				: (double?)null;
		}

		public static double? TryParseDouble(this string value)
		{
			return value.TryParseDouble(NumberStyles.Any);
		}

		public static T? TryParseEnum<T>(this string value) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new NotSupportedException("T must be an Enum");
			}

			try
			{
				return (T)Enum.Parse(typeof(T), value, true);
			}
			catch
			{
				return null;
			}
		}

		public static Guid? TryParseGuid(this string value)
		{
			try
			{
				return new Guid(value);
			}
			catch
			{
				return null;
			}
		}

		public static short? TryParseInt16(this string value, NumberStyles styles)
		{
			var provider = ((styles & NumberStyles.AllowCurrencySymbol) > 0)
				? new CultureInfo("en-US")
				: CultureInfo.InvariantCulture;

			short parsedValue;
			return (short.TryParse(value, styles, provider, out parsedValue))
				? parsedValue
				: (short?)null;
		}

		public static short? TryParseInt16(this string value)
		{
			return value.TryParseInt16(NumberStyles.Any);
		}

		public static int? TryParseInt32(this string value, NumberStyles styles)
		{
			var provider = ((styles & NumberStyles.AllowCurrencySymbol) > 0)
				? new CultureInfo("en-US")
				: CultureInfo.InvariantCulture;

			int parsedValue;
			return (int.TryParse(value, styles, provider, out parsedValue))
				? parsedValue
				: (int?)null;
		}

		public static int? TryParseInt32(this string value)
		{
			return value.TryParseInt32(NumberStyles.Any);
		}

		public static long? TryParseInt64(this string value, NumberStyles styles)
		{
			var provider = ((styles & NumberStyles.AllowCurrencySymbol) > 0)
				? new CultureInfo("en-US")
				: CultureInfo.InvariantCulture;

			long parsedValue;
			return (long.TryParse(value, styles, provider, out parsedValue))
				? parsedValue
				: (long?)null;
		}

		public static long? TryParseInt64(this string value)
		{
			return value.TryParseInt64(NumberStyles.Any);
		}

		public static float? TryParseSingle(this string value, NumberStyles styles)
		{
			var provider = ((styles & NumberStyles.AllowCurrencySymbol) > 0)
				? new CultureInfo("en-US")
				: CultureInfo.InvariantCulture;

			float parsedValue;
			return (float.TryParse(value, styles, provider, out parsedValue))
				? parsedValue
				: (float?)null;
		}

		public static float? TryParseSingle(this string value)
		{
			return value.TryParseSingle(NumberStyles.Any);
		}

		public static Uri TryParseUri(this string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				try
				{
					return new Uri(value);
				}
				catch
				{
				}
			}

			return null;
		}

		public static bool? TryParseYesNoAsBoolean(this string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (value.Equals("Y", StringComparison.InvariantCultureIgnoreCase) || value.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
				{
					return true;
				}
				else if (value.Equals("N", StringComparison.InvariantCultureIgnoreCase) || value.Equals("No", StringComparison.InvariantCultureIgnoreCase))
				{
					return false;
				}
			}

			return null;
		}

		public static bool TryParseYesNoAsBoolean(this string value, bool defaultWhenNull)
		{
			return TryParseYesNoAsBoolean(value) ?? defaultWhenNull;
		}

		public static byte[] ToByteArray(this string value, Encoding encoding)
		{
			return (encoding ?? Encoding.UTF8).GetBytes(value);
		}

		public static byte[] ToByteArray(this string value)
		{
			return value.ToByteArray(null);
		}
	}
}