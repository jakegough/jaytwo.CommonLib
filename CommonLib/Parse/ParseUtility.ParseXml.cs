using System.Linq;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using jaytwo.Common.System;
using jaytwo.Common.Collections;
using System.Xml.XPath;

namespace jaytwo.Common.Parse
{
    public static partial class ParseUtility
    {
#if GTENET40
		public static dynamic ParseXmlAsDynamic(string xml, StringComparer stringComparer)
		{
			var dictionary = ParseXmlAsDictionary(xml);
			var result = DynamicDictionary.CreateDynamic(dictionary, stringComparer);
			return result;
		}

		public static dynamic TryParseXmlAsDynamic(string xml, StringComparer stringComparer)
		{
			try
			{
				return ParseXmlAsDynamic(xml, stringComparer);
			}
			catch
			{
				return null;
			}
		}

		public static dynamic ParseXmlAsDynamic(string xml)
		{
			var dictionary = ParseXmlAsDictionary(xml);
			var result = DynamicDictionary.FromDictionary(dictionary);
			return result;
		}

		public static dynamic TryParseXmlAsDynamic(string xml)
		{
			try
			{
				return ParseXmlAsDynamic(xml);
			}
			catch
			{
				return null;
			}
		}

        private static IDictionary<string, object> ParseXmlAsDictionary(string xml)
		{
			var xDocument = XDocument.Parse(xml);
			var result = XElementToDictionary(xDocument.Root);
			return result;
		}

		private static IDictionary<string, object> XElementToDictionary(XElement element)
		{
			var result = new Dictionary<string, object>();

			//TODO: perhaps set child items with the same name to be an indexed array
			//      that is, stop doing: items/item, items/item_0, items/item_1

			foreach (var child in element.Descendants())
			{
				int keyIndex = 0;
				string key = child.Name.LocalName;

				while (result.ContainsKey(key))
				{
					key = child.Name.LocalName + "_" + keyIndex++;
				}

				object value = (child.HasElements)
					? (object)XElementToDictionary(child)
					: (object)child.Value;

				result.Add(key, value);
			}

			return result;
		}
#endif

        public static IXPathNavigable ParseXml(string xml)
        {
            return ParseXmlDocument(xml);
        }

        public static IXPathNavigable TryParseXml(string xml)
        {
            return TryParseXmlDocument(xml);
        }

        public static XmlDocument ParseXmlDocument(string xml)
		{
			var result = new XmlDocument();
			result.LoadXml(xml);

			return result;
		}

		public static XmlDocument TryParseXmlDocument(string xml)
		{
			try
			{
				return ParseXmlDocument(xml);
			}
			catch
			{
				return null;
			}
		}

		public static XDocument ParseXDocument(string xml)
		{
			var result = XDocument.Parse(xml);
			return result;
		}

		public static XDocument TryParseXDocument(string xml)
		{
			try
			{
				return ParseXDocument(xml);
			}
			catch
			{
				return null;
			}
		}
    }
}
