using System.Runtime.Serialization.Json;
using System.Xml.Linq;

#if NET_4_0
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
using System.Xml.XPath;
using jaytwo.Common.Http;
using jaytwo.Common.Appendix;
using System.Collections;

namespace jaytwo.Common.Parse
{
	public static partial class ParseUtility
	{
#if NET_4_0
		public static dynamic ParseJsonAsDynamic(string json, StringComparer stringComparer)
		{
			var dictionary = ParseJsonAsDictionary(json);
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
			var dictionary = ParseJsonAsDictionary(json);
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

        public static IDictionary ParseJsonAsDictionary(string json, StringComparer stringComparer)
        {
			var dictionary = ParseJsonAsDictionary(json);
			return DynamicDictionary.FromDictionary(dictionary, stringComparer);
        }

        public static IDictionary TryParseJsonAsDictionary(string json, StringComparer stringComparer)
        {
            try
            {
                return ParseJsonAsDictionary(json, stringComparer);
            }
            catch
            {
                return null;
            }
        }

        public static IDictionary ParseJsonAsDictionary(string json)
        {
			return InternalScabHelpers.DeserializeJson<IDictionary>(json);
        }

        public static IDictionary TryParseJsonAsDictionary(string json)
        {
            try
            {
                return ParseJsonAsDictionary(json);
            }
            catch
            {
                return null;
            }
        }

		private static string NormalizeJson(string json)
		{
			var deserialized = InternalScabHelpers.DeserializeJson<object>(json);
			var result = InternalScabHelpers.SerializeToJson(deserialized);
			return result;
		}

		private static XmlReader GetJsonXmlReader(string json)
		{
			var properJson = NormalizeJson(json);
			var stream = new MemoryStream(Encoding.GetBytes(properJson));
			var reader = JsonReaderWriterFactory.CreateJsonReader(
				stream,
				Encoding,
				XmlDictionaryReaderQuotas.Max,
				x => { using (stream) { } });

			return reader;
		}

        public static IXPathNavigable ParseJsonAsXml(string json)
        {
            return ParseJsonAsXmlDocument(json);
        }

        public static IXPathNavigable TryParseJsonAsXml(string json)
        {
            return TryParseJsonAsXmlDocument(json);
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
