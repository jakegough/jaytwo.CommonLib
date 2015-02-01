using System.Xml.Linq;
using jaytwo.Common.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using jaytwo.Common.Parse;

namespace jaytwo.Common.Test.Parse
{
	[TestFixture]
	public partial class ParseUtilityTests
	{
		private const string badJson = "{ Key1 : \"Value1\", Key2 : ";
		private const string goodJson = "{ Key1 : \"Value1\", Key2 : { Key3 : \"Value3\" } }";
		private const string perfectJson = "{ \"Key1\" : \"Value1\", \"Key2\" : { \"Key3\" : \"Value3\" } }";

#if GTENET40
		private static void VerifyGoodJsonAsDynamic(dynamic parsed)
		{
			Assert.AreEqual("Value1", parsed.Key1);
			Assert.AreEqual("Value3", parsed.Key2.Key3);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_ParseJsonAsDynamic(string json)
		{
			var parsed = ParseUtility.ParseJsonAsDynamic(json);
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		[ExpectedException]
		public void ParseUtility_ParseJsonAsDynamic_bad_json()
		{
			ParseUtility.ParseJsonAsDynamic(badJson);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_TryParseJsonAsDynamic(string json)
		{
			var parsed = ParseUtility.TryParseJsonAsDynamic(json);
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		public void ParseUtility_TryParseJsonAsDynamic_bad_json()
		{
			Assert.IsNull(ParseUtility.TryParseJsonAsDynamic(badJson));
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_ParseJsonAsDynamic(string json)
		{
			var parsed = json.ParseJsonAsDynamic();
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		[ExpectedException]
		public void StringExtensions_ParseJsonAsDynamic_bad_json()
		{
			badJson.ParseJsonAsDynamic();
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_TryParseJsonAsDynamic(string json)
		{
			var parsed = json.TryParseJsonAsDynamic();
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		public void StringExtensions_TryParseJsonAsDynamic_bad_json()
		{
			Assert.IsNull(badJson.TryParseJsonAsDynamic());
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_ParseJsonAsDynamic_string_comparer(string json)
		{
			var parsed = ParseUtility.ParseJsonAsDynamic(json, StringComparer.OrdinalIgnoreCase);
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		[ExpectedException]
		public void ParseUtility_ParseJsonAsDynamic_string_comparer_bad_json()
		{
			ParseUtility.ParseJsonAsDynamic(badJson, StringComparer.OrdinalIgnoreCase);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_TryParseJsonAsDynamic_string_comparer(string json)
		{
			var parsed = ParseUtility.TryParseJsonAsDynamic(json, StringComparer.OrdinalIgnoreCase);
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		public void ParseUtility_TryParseJsonAsDynamic_string_comparer_bad_json()
		{
			Assert.IsNull(ParseUtility.TryParseJsonAsDynamic(badJson, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_ParseJsonAsDynamic_string_comparer(string json)
		{
			var parsed = json.ParseJsonAsDynamic(StringComparer.OrdinalIgnoreCase);
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		[ExpectedException]
		public void StringExtensions_ParseJsonAsDynamic_string_comparer_bad_json()
		{
			badJson.ParseJsonAsDynamic(StringComparer.OrdinalIgnoreCase);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_TryParseJsonAsDynamic_string_comparer(string json)
		{
			var parsed = json.TryParseJsonAsDynamic(StringComparer.OrdinalIgnoreCase);
			VerifyGoodJsonAsDynamic(parsed);
		}

		[Test]
		public void StringExtensions_TryParseJsonAsDynamic_string_comparer_bad_json()
		{
			Assert.IsNull(badJson.TryParseJsonAsDynamic(StringComparer.OrdinalIgnoreCase));
		}
#endif

		private static void VerifyGoodJsonAsXDocument(XDocument parsed)
		{
			Assert.AreEqual(
				"Value1",
				parsed.GetXPathValue("//Key1"));
		}

		private static void VerifyGoodJsonAsXmlDocument(XmlDocument parsed)
		{
			Assert.AreEqual(
				"Value1",
				parsed.GetXPathValue("//Key1"));
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_ParseJsonAsXDocument(string json)
		{
			var parsed = ParseUtility.ParseJsonAsXDocument(json);
			VerifyGoodJsonAsXDocument(parsed);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_ParseJsonAsXDocument(string json)
		{
			var parsed = json.ParseJsonAsXDocument();
			VerifyGoodJsonAsXDocument(parsed);
		}

		[Test]
		[ExpectedException]
		public void ParseUtility_ParseJsonAsXDocument_bad_json()
		{
			ParseUtility.ParseJsonAsXDocument(badJson);
		}

		[Test]
		[ExpectedException]
		public void StringExtensions_ParseJsonAsXDocument_bad_json()
		{
			badJson.ParseJsonAsXDocument();
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_TryParseJsonAsXDocument(string json)
		{
			var parsed = ParseUtility.TryParseJsonAsXDocument(json);
			VerifyGoodJsonAsXDocument(parsed);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_TryParseJsonAsXDocument(string json)
		{
			var parsed = json.TryParseJsonAsXDocument();
			VerifyGoodJsonAsXDocument(parsed);
		}

		[Test]
		public void ParseUtility_TryParseJsonAsXDocument_bad_json()
		{
			Assert.IsNull(
				ParseUtility.TryParseJsonAsXDocument(badJson));
		}

		[Test]
		public void StringExtensions_TryParseJsonAsXDocument_bad_json()
		{
			Assert.IsNull(
				badJson.TryParseJsonAsXDocument());
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_ParseJsonAsXmlDocument(string json)
		{
			var parsed = ParseUtility.ParseJsonAsXmlDocument(json);
			VerifyGoodJsonAsXmlDocument(parsed);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_ParseJsonAsXmlDocument(string json)
		{
			var parsed = json.ParseJsonAsXmlDocument();
			VerifyGoodJsonAsXmlDocument(parsed);
		}

		[Test]
		[ExpectedException]
		public void ParseUtility_ParseJsonAsXmlDocument_bad_json()
		{
			ParseUtility.ParseJsonAsXmlDocument(badJson);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void ParseUtility_TryParseJsonAsXmlDocument(string json)
		{
			var parsed = ParseUtility.TryParseJsonAsXmlDocument(json);
			VerifyGoodJsonAsXmlDocument(parsed);
		}

		[Test]
		[TestCase(perfectJson)]
		[TestCase(goodJson)]
		public void StringExtensions_TryParseJsonAsXmlDocument(string json)
		{
			var parsed = json.TryParseJsonAsXmlDocument();
			VerifyGoodJsonAsXmlDocument(parsed);
		}

		[Test]
		public void ParseUtility_TryParseJsonAsXmlDocument_bad_json()
		{
			Assert.IsNull(
				ParseUtility.TryParseJsonAsXmlDocument(badJson));
		}

		[Test]
		public void StringExtensions_TryParseJsonAsXmlDocument_bad_json()
		{
			Assert.IsNull(
				badJson.TryParseJsonAsXmlDocument());
		}
	}
}
