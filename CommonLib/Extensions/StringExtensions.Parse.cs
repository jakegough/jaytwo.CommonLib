using jaytwo.Common.Parse;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace jaytwo.Common.Extensions
{
	public static partial class StringExtensions
	{
		public static Guid? TryParseGuid(this string value)
		{
			return ParseUtility.TryParseGuid(value);
		}

		public static bool ParseBoolean(this string value)
		{
			return ParseUtility.ParseBoolean(value);
		}

		public static bool ParseBoolean(this string value, BoolStyles styles)
		{
			return ParseUtility.ParseBoolean(value, styles);
		}

		public static bool? TryParseBoolean(this string value)
		{
			return ParseUtility.TryParseBoolean(value);
		}

		public static bool? TryParseBoolean(this string value, BoolStyles styles)
		{
			return ParseUtility.TryParseBoolean(value, styles);
		}

		public static byte ParseByte(this string value)
		{
			return ParseUtility.ParseByte(value);
		}

		public static byte ParseByte(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseByte(value, styles);
		}

		public static byte ParseByte(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseByte(value, formatProvider);
		}

		public static byte ParseByte(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseByte(value, styles, formatProvider);
		}

		public static byte? TryParseByte(this string value)
		{
			return ParseUtility.TryParseByte(value);
		}

		public static byte? TryParseByte(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseByte(value, styles);
		}

		public static byte? TryParseByte(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseByte(value, formatProvider);
		}

		public static byte? TryParseByte(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseByte(value, styles, formatProvider);
		}

		public static DateTime ParseDateTime(this string value)
		{
			return ParseUtility.ParseDateTime(value);
		}

		public static DateTime ParseDateTime(this string value, DateTimeStyles styles)
		{
			return ParseUtility.ParseDateTime(value, styles);
		}

		public static DateTime ParseDateTime(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDateTime(value, formatProvider);
		}

		public static DateTime ParseDateTime(this string value, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDateTime(value, styles, formatProvider);
		}

		public static DateTime? TryParseDateTime(this string value)
		{
			return ParseUtility.TryParseDateTime(value);
		}

		public static DateTime? TryParseDateTime(this string value, DateTimeStyles styles)
		{
			return ParseUtility.TryParseDateTime(value, styles);
		}

		public static DateTime? TryParseDateTime(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDateTime(value, formatProvider);
		}

		public static DateTime? TryParseDateTime(this string value, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDateTime(value, styles, formatProvider);
		}

		public static decimal ParseDecimal(this string value)
		{
			return ParseUtility.ParseDecimal(value);
		}

		public static decimal ParseDecimal(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseDecimal(value, styles);
		}

		public static decimal ParseDecimal(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDecimal(value, formatProvider);
		}

		public static decimal ParseDecimal(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDecimal(value, styles, formatProvider);
		}

		public static decimal? TryParseDecimal(this string value)
		{
			return ParseUtility.TryParseDecimal(value);
		}

		public static decimal? TryParseDecimal(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseDecimal(value, styles);
		}

		public static decimal? TryParseDecimal(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDecimal(value, formatProvider);
		}

		public static decimal? TryParseDecimal(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDecimal(value, styles, formatProvider);
		}

		public static double ParseDouble(this string value)
		{
			return ParseUtility.ParseDouble(value);
		}

		public static double ParseDouble(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseDouble(value, styles);
		}

		public static double ParseDouble(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDouble(value, formatProvider);
		}

		public static double ParseDouble(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDouble(value, styles, formatProvider);
		}

		public static double? TryParseDouble(this string value)
		{
			return ParseUtility.TryParseDouble(value);
		}

		public static double? TryParseDouble(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseDouble(value, styles);
		}

		public static double? TryParseDouble(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDouble(value, formatProvider);
		}

		public static double? TryParseDouble(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDouble(value, styles, formatProvider);
		}

		public static T ParseEnum<T>(this string value) where T : struct
		{
			return ParseUtility.ParseEnum<T>(value);
		}

		public static T? TryParseEnum<T>(this string value) where T : struct
		{
			return ParseUtility.TryParseEnum<T>(value);
		}

		public static Guid ParseGuid(this string value)
		{
			return ParseUtility.ParseGuid(value);
		}

		public static short ParseInt16(this string value)
		{
			return ParseUtility.ParseInt16(value);
		}

		public static short ParseInt16(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseInt16(value, styles);
		}

		public static short ParseInt16(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt16(value, formatProvider);
		}

		public static short ParseInt16(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt16(value, styles, formatProvider);
		}

		public static short? TryParseInt16(this string value)
		{
			return ParseUtility.TryParseInt16(value);
		}

		public static short? TryParseInt16(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseInt16(value, styles);
		}

		public static short? TryParseInt16(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt16(value, formatProvider);
		}

		public static short? TryParseInt16(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt16(value, styles, formatProvider);
		}

		public static int ParseInt32(this string value)
		{
			return ParseUtility.ParseInt32(value);
		}

		public static int ParseInt32(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseInt32(value, styles);
		}

		public static int ParseInt32(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt32(value, formatProvider);
		}

		public static int ParseInt32(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt32(value, styles, formatProvider);
		}

		public static int? TryParseInt32(this string value)
		{
			return ParseUtility.TryParseInt32(value);
		}

		public static int? TryParseInt32(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseInt32(value, styles);
		}

		public static int? TryParseInt32(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt32(value, formatProvider);
		}

		public static int? TryParseInt32(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt32(value, styles, formatProvider);
		}

		public static long ParseInt64(this string value)
		{
			return ParseUtility.ParseInt64(value);
		}

		public static long ParseInt64(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseInt64(value, styles);
		}

		public static long ParseInt64(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt64(value, formatProvider);
		}

		public static long ParseInt64(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt64(value, styles, formatProvider);
		}

		public static long? TryParseInt64(this string value)
		{
			return ParseUtility.TryParseInt64(value);
		}

		public static long? TryParseInt64(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseInt64(value, styles);
		}

		public static long? TryParseInt64(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt64(value, formatProvider);
		}

		public static long? TryParseInt64(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt64(value, styles, formatProvider);
		}

#if GTENET40
		public static dynamic ParseJsonAsDynamic(this string json, StringComparer stringComparer)
		{
			return ParseUtility.ParseJsonAsDynamic(json, stringComparer);
		}

		public static dynamic TryParseJsonAsDynamic(this string json, StringComparer stringComparer)
		{
			return ParseUtility.TryParseJsonAsDynamic(json, stringComparer);
		}

		public static dynamic ParseJsonAsDynamic(this string json)
		{
			return ParseUtility.ParseJsonAsDynamic(json);
		}

		public static dynamic TryParseJsonAsDynamic(this string json)
		{
			return ParseUtility.TryParseJsonAsDynamic(json);
		}
#endif

		public static XmlDocument ParseJsonAsXmlDocument(this string json)
		{
			return ParseUtility.ParseJsonAsXmlDocument(json);
		}

		public static XmlDocument TryParseJsonAsXmlDocument(this string json)
		{
			return ParseUtility.TryParseJsonAsXmlDocument(json);
		}

		public static XDocument ParseJsonAsXDocument(this string json)
		{
			return ParseUtility.ParseJsonAsXDocument(json);
		}

		public static XDocument TryParseJsonAsXDocument(this string json)
		{
			return ParseUtility.TryParseJsonAsXDocument(json);
		}

        [CLSCompliant(false)]
		public static sbyte ParseSByte(this string value)
		{
			return ParseUtility.ParseSByte(value);
		}

        [CLSCompliant(false)]
		public static sbyte ParseSByte(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseSByte(value, styles);
		}

        [CLSCompliant(false)]
		public static sbyte ParseSByte(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSByte(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte ParseSByte(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSByte(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(this string value)
		{
			return ParseUtility.TryParseSByte(value);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseSByte(value, styles);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSByte(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static sbyte? TryParseSByte(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSByte(value, styles, formatProvider);
		}

		public static float ParseSingle(this string value)
		{
			return ParseUtility.ParseSingle(value);
		}

		public static float ParseSingle(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseSingle(value, styles);
		}

		public static float ParseSingle(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSingle(value, formatProvider);
		}

		public static float ParseSingle(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSingle(value, styles, formatProvider);
		}

		public static float? TryParseSingle(this string value)
		{
			return ParseUtility.TryParseSingle(value);
		}

		public static float? TryParseSingle(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseSingle(value, styles);
		}

		public static float? TryParseSingle(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSingle(value, formatProvider);
		}

		public static float? TryParseSingle(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSingle(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort ParseUInt16(this string value)
		{
			return ParseUtility.ParseUInt16(value);
		}

        [CLSCompliant(false)]
		public static ushort ParseUInt16(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseUInt16(value, styles);
		}

        [CLSCompliant(false)]
		public static ushort ParseUInt16(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt16(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort ParseUInt16(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(this string value)
		{
			return ParseUtility.TryParseUInt16(value);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseUInt16(value, styles);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt16(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static ushort? TryParseUInt16(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt16(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint ParseUInt32(this string value)
		{
			return ParseUtility.ParseUInt32(value);
		}

        [CLSCompliant(false)]
		public static uint ParseUInt32(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseUInt32(value, styles);
		}

        [CLSCompliant(false)]
		public static uint ParseUInt32(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt32(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint ParseUInt32(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(this string value)
		{
			return ParseUtility.TryParseUInt32(value);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseUInt32(value, styles);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt32(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static uint? TryParseUInt32(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt32(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong ParseUInt64(this string value)
		{
			return ParseUtility.ParseUInt64(value);
		}

        [CLSCompliant(false)]
		public static ulong ParseUInt64(this string value, NumberStyles styles)
		{
			return ParseUtility.ParseUInt64(value, styles);
		}

        [CLSCompliant(false)]
		public static ulong ParseUInt64(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt64(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong ParseUInt64(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt64(value, styles, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(this string value)
		{
			return ParseUtility.TryParseUInt64(value);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(this string value, NumberStyles styles)
		{
			return ParseUtility.TryParseUInt64(value, styles);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(this string value, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt64(value, formatProvider);
		}

        [CLSCompliant(false)]
		public static ulong? TryParseUInt64(this string value, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt64(value, styles, formatProvider);
		}

#if GTENET40
		public static dynamic ParseXmlAsDynamic(this string xml, StringComparer stringComparer)
		{
			return ParseUtility.ParseXmlAsDynamic(xml, stringComparer);
		}

		public static dynamic TryParseXmlAsDynamic(this string xml, StringComparer stringComparer)
		{
			return ParseUtility.TryParseXmlAsDynamic(xml, stringComparer);
		}

		public static dynamic ParseXmlAsDynamic(this string xml)
		{
			return ParseUtility.ParseXmlAsDynamic(xml);
		}

		public static dynamic TryParseXmlAsDynamic(this string xml)
		{
			return ParseUtility.TryParseXmlAsDynamic(xml);
		}
#endif

		public static XmlDocument ParseXmlDocument(this string xml)
		{
			return ParseUtility.ParseXmlDocument(xml);
		}

		public static XmlDocument TryParseXmlDocument(this string xml)
		{
			return ParseUtility.TryParseXmlDocument(xml);
		}

		public static XDocument ParseXDocument(this string xml)
		{
			return ParseUtility.ParseXDocument(xml);
		}

		public static XDocument TryParseXDocument(this string xml)
		{
			return ParseUtility.TryParseXDocument(xml);
		}
	}
}