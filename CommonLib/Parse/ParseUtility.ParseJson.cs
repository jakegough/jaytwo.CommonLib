using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Xml.Linq;

#if GTENET40
using System.Dynamic;
#endif

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using jaytwo.Common.System;
using jaytwo.Common.Collections;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
#if GTENET40
		public static dynamic ParseJsonAsDynamic(string json, StringComparer stringComparer)
		{
			var serializer = new JavaScriptSerializer();
			var dictionary = serializer.Deserialize<IDictionary<string, object>>(json);
			return DynamicDictionary.CreateDynamic(dictionary, stringComparer);
		}

		public static dynamic TryParseJsonAsDynamic(string json, StringComparer stringComparer)
		{
			try
			{
				return ParseJsonAsDynamic(json, stringComparer);
			}
			catch
			{
				return null;
			}
		}

		public static dynamic ParseJsonAsDynamic(string json)
		{
			var serializer = new JavaScriptSerializer();
			var dictionary = serializer.Deserialize<IDictionary<string, object>>(json);
			return DynamicDictionary.CreateDynamic(dictionary);
		}

		public static dynamic TryParseJsonAsDynamic(string json)
		{
			try
			{
				return ParseJsonAsDynamic(json);
			}
			catch
			{
				return null;
			}
		}
#endif

		private static string GetProperJson(string json)
		{
			var serializer = new JavaScriptSerializer();
			var deserialized = serializer.Deserialize<object>(json);
			var result = serializer.Serialize(deserialized);
			return result;
		}

		private static XmlReader GetJsonXmlReader(string json)
		{
			var properJson = GetProperJson(json);
			var stream = new MemoryStream(Encoding.GetBytes(properJson));
			var reader = JsonReaderWriterFactory.CreateJsonReader(
				stream,
				Encoding,
				XmlDictionaryReaderQuotas.Max,
				x => { using (stream) { } });

			return reader;
		}

		public static XmlDocument ParseJsonAsXmlDocument(string json)
		{
			using (var reader = GetJsonXmlReader(json))
			{
				var result = new XmlDocument();
				result.Load(reader);

				return result;
			}
		}

		public static XmlDocument TryParseJsonAsXmlDocument(string json)
		{
			try
			{
				return ParseJsonAsXmlDocument(json);
			}
			catch
			{
				return null;
			}
		}

		public static XDocument ParseJsonAsXDocument(string json)
		{
			using (var reader = GetJsonXmlReader(json))
			{
				var result = XDocument.Load(reader);
				return result;
			}
		}

		public static XDocument TryParseJsonAsXDocument(string json)
		{
			try
			{
				return ParseJsonAsXDocument(json);
			}
			catch
			{
				return null;
			}
		}
	}
}
