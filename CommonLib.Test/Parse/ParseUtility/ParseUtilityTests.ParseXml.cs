using System.Linq;
using System.Xml.Linq;
using jaytwo.Common.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using jaytwo.Common.Parse;
using jaytwo.Common.Xml;

namespace jaytwo.Common.Test.Parse
{
	[TestFixture]
	public partial class ParseUtilityTests
	{
		private const string goodXml = "<xml><Key1>Value1</Key1><Key2><Key3>Value3</Key3></Key2><items><item>a</item><item>b</item><item>c</item></items></xml>";
		private const string badXml = "<xml><Key1>Value1</Key1>";

        private static IEnumerable<TestCaseData> ParseUtility_ParseXml_TestCases()
        {
            yield return new TestCaseData(goodXml).Returns(true);
            yield return new TestCaseData(badXml).Throws(typeof(XmlException));
        }

        private static IEnumerable<TestCaseData> ParseUtility_TryParseXml_TestCases()
        {
            yield return new TestCaseData(goodXml).Returns(true);
            yield return new TestCaseData(badXml).Returns(false);
        }

#if NET_4_0
        [Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
		public bool ParseUtility_ParseXmlAsDynamic(string xml)
		{			
			var parsed = ParseUtility.ParseXmlAsDynamic(xml);
			VerifyGoodXmlAsDynamic(parsed);
            return (parsed != null);
		}

		[Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
        public bool StringExtensions_ParseXmlAsDynamic(string xml)
		{
			var parsed = xml.ParseXmlAsDynamic();
			VerifyGoodXmlAsDynamic(parsed);
            return (parsed != null);
		}

		
		[Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool ParseUtility_TryParseXmlAsDynamic(string xml)
		{
			var parsed = ParseUtility.TryParseXmlAsDynamic(xml);
			VerifyGoodXmlAsDynamic(parsed);
            return (parsed != null);
		}

		[Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool StringExtensions_TryParseXmlAsDynamic(string xml)
		{
			var parsed = xml.TryParseXmlAsDynamic();
			VerifyGoodXmlAsDynamic(parsed);
            return (parsed != null);
		}

        [Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
        public bool ParseUtility_ParseXmlAsDynamic_with_StringComparer(string xml)
        {
            var parsed = ParseUtility.ParseXmlAsDynamic(xml, StringComparer.OrdinalIgnoreCase);
            VerifyGoodXmlAsDynamic_CaseInsensetive(parsed);
            return (parsed != null);
        }

        [Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
        public bool StringExtensions_ParseXmlAsDynamic_with_StringComparer(string xml)
        {
            var parsed = xml.ParseXmlAsDynamic(StringComparer.OrdinalIgnoreCase);
            VerifyGoodXmlAsDynamic_CaseInsensetive(parsed);
            return (parsed != null);
        }


        [Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool ParseUtility_TryParseXmlAsDynamic_with_StringComparer(string xml)
        {
            var parsed = ParseUtility.TryParseXmlAsDynamic(xml, StringComparer.OrdinalIgnoreCase);
            VerifyGoodXmlAsDynamic_CaseInsensetive(parsed);
            return (parsed != null);
        }

        [Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool StringExtensions_TryParseXmlAsDynamic_with_StringComparer(string xml)
        {
            var parsed = xml.TryParseXmlAsDynamic(StringComparer.OrdinalIgnoreCase);
            VerifyGoodXmlAsDynamic_CaseInsensetive(parsed);
            return (parsed != null);
        }

		private static void VerifyGoodXmlAsDynamic(dynamic parsed)
		{
            if (parsed != null)
            {
                Assert.AreEqual("Value1", parsed.Key1);
                Assert.AreEqual("Value3", parsed.Key2.Key3);
                Assert.AreEqual("a", parsed.items.item);
                Assert.AreEqual("b", parsed.items.item_0);
                Assert.AreEqual("c", parsed.items.item_1);
            }			
		}

        private static void VerifyGoodXmlAsDynamic_CaseInsensetive(dynamic parsed)
        {
            if (parsed != null)
            {
                Assert.AreEqual("Value1", parsed.Key1);
                Assert.AreEqual("Value1", parsed.KEY1);
                Assert.AreEqual("Value3", parsed.Key2.Key3);
                Assert.AreEqual("Value3", parsed.KEY2.KEY3);
                Assert.AreEqual("a", parsed.items.item);
                Assert.AreEqual("a", parsed.ITEMS.ITEM);
                Assert.AreEqual("b", parsed.items.item_0);
                Assert.AreEqual("b", parsed.ITEMS.ITEM_0);
                Assert.AreEqual("c", parsed.items.item_1);
                Assert.AreEqual("c", parsed.ITEMS.ITEM_1);
            }            
        }
#endif

		[Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
		public bool ParseUtility_ParseXmlDocument(string xml)
		{
			var parsed = ParseUtility.ParseXmlDocument(xml);
			VerifyGoodXmlAsXmlDocument(parsed);
            return (parsed != null);
		}

        [Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
        public bool ParseUtility_ParseXml(string xml)
        {
            var parsed = ParseUtility.ParseXml(xml);
            VerifyGoodXmlAsXmlDocument(parsed);
            return (parsed != null);
        }

		private static void VerifyGoodXmlAsXmlDocument(IXPathNavigable parsed)
		{
            if (parsed != null)
            {
                Assert.AreEqual(
                    "Value1",
                    XmlUtility.GetXPathValue(parsed, "//Key1"));
            }			
		}

		[Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
		public bool ParseUtility_TryParseXmlDocument(string xml)
		{
			var parsed = ParseUtility.TryParseXmlDocument(xml);
			VerifyGoodXmlAsXmlDocument(parsed);
            return (parsed != null);
		}

        [Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool ParseUtility_TryParseXml(string xml)
        {
            var parsed = ParseUtility.TryParseXml(xml);
            VerifyGoodXmlAsXmlDocument(parsed);
            return (parsed != null);
        }

		[Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
        public bool StringExtensions_ParseXmlDocument(string xml)
		{
			var parsed = xml.ParseXmlDocument();
			VerifyGoodXmlAsXmlDocument(parsed);
            return (parsed != null);
		}

		[Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool StringExtensions_TryParseXmlDocument(string xml)
		{
			var parsed = xml.TryParseXmlDocument();
			VerifyGoodXmlAsXmlDocument(parsed);
            return (parsed != null);
		}

		[Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
        public bool ParseUtility_ParseXDocument(string xml)
		{
			var parsed = ParseUtility.ParseXDocument(xml);
			VerifyGoodXmlAsXDocument(parsed);
            return (parsed != null);
		}

		[Test]
        [TestCaseSource("ParseUtility_ParseXml_TestCases")]
        public bool StringExtensions_ParseXDocument(string xml)
		{
			var parsed = xml.ParseXDocument();
			VerifyGoodXmlAsXDocument(parsed);
            return (parsed != null);
		}

		private static void VerifyGoodXmlAsXDocument(XDocument parsed)
		{
            if (parsed != null)
            {
                Assert.AreEqual(
                    "Value1",
                    parsed.GetXPathValue("//Key1"));
            }			
		}

		[Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool ParseUtility_TryParseXDocument(string xml)
		{
			var parsed = ParseUtility.TryParseXDocument(xml);
			VerifyGoodXmlAsXDocument(parsed);
            return (parsed != null);
		}

		[Test]
        [TestCaseSource("ParseUtility_TryParseXml_TestCases")]
        public bool StringExtensions_TryParseXDocument(string xml)
		{
			var parsed = xml.TryParseXDocument();
			VerifyGoodXmlAsXDocument(parsed);
            return (parsed != null);
		}
	}
}
