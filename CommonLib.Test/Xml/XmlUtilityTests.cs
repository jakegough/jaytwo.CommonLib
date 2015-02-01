using jaytwo.Common.Extensions;
using jaytwo.Common.Xml;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Parse;
using System.Xml;
using System.Xml.Linq;

namespace jaytwo.Common.Test.Xml
{
    [TestFixture]
    public static class XmlUtilityTests
    {
        private const string goodXml = "<xml><Key1>Value1</Key1><Key2><Key3>Value3</Key3></Key2><items><item>a</item><item>b</item><item>c</item></items></xml>";
        private const string badXml = "<xml><Key1>Value1</Key1>";

        public static IEnumerable<TestCaseData> XmlUtility_GetXPathInnerXml_TestCases()
        {
            yield return new TestCaseData(null, "//Key2").Returns(null);
            yield return new TestCaseData(goodXml, "//foo").Returns(null);
            yield return new TestCaseData(goodXml, "//Key2").Returns("<Key3>Value3</Key3>");
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathInnerXml_TestCases")]
        public static string XmlUtility_GetXPathInnerXml_XmlDocument(string xml, string xpath)
        {
            var xmlDoc = GetXmlDocumentOrNull(xml);                   
            return XmlUtility.GetXPathInnerXml(xmlDoc, xpath);
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathInnerXml_TestCases")]
        public static string XmlUtility_GetXPathInnerXml_Xdocument(string xml, string xpath)
        {
            var xmlDoc = GetXDocumentOrNull(xml);
            return XmlUtility.GetXPathInnerXml(xmlDoc, xpath);
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathInnerXml_TestCases")]
        public static string XmlExtensions_GetXPathInnerXml_Xdocument(string xml, string xpath)
        {
            var xmlDoc = GetXDocumentOrNull(xml);
            return xmlDoc.GetXPathInnerXml(xpath);
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathInnerXml_TestCases")]
        public static string XmlExtensions_GetXPathInnerXml_XmlDocument(string xml, string xpath)
        {
            var xmlDoc = GetXmlDocumentOrNull(xml);
            return xmlDoc.GetXPathInnerXml(xpath);
        }


        public static IEnumerable<TestCaseData> XmlUtility_GetXPathValue_TestCases()
        {
            yield return new TestCaseData(null, "//Key2").Returns(null);
            yield return new TestCaseData(goodXml, "//foo").Returns(null);
            yield return new TestCaseData(goodXml, "//Key2").Returns("Value3");
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathValue_TestCases")]
        public static string XmlUtility_GetXPathValue_XmlDocument(string xml, string xpath)
        {
            var xmlDoc = GetXmlDocumentOrNull(xml);
            return XmlUtility.GetXPathValue(xmlDoc, xpath);
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathValue_TestCases")]
        public static string XmlExtensions_GetXPathValue_XmlDocument(string xml, string xpath)
        {
            var xmlDoc = GetXmlDocumentOrNull(xml);
            return XmlUtility.GetXPathValue(xmlDoc, xpath);
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathValue_TestCases")]
        public static string XmlUtility_GetXPathValue_Xdocument(string xml, string xpath)
        {
            var xmlDoc = GetXDocumentOrNull(xml);
            return XmlUtility.GetXPathValue(xmlDoc, xpath);
        }

        [Test]
        [TestCaseSource("XmlUtility_GetXPathValue_TestCases")]
        public static string XmlExtensions_GetXPathValue_Xdocument(string xml, string xpath)
        {
            var xmlDoc = GetXDocumentOrNull(xml);
            return XmlUtility.GetXPathValue(xmlDoc, xpath);
        }

        private static XDocument GetXDocumentOrNull(string xml)
        {
            return (xml != null) ? ParseUtility.ParseXDocument(xml) : null;
        }

        private static XmlDocument GetXmlDocumentOrNull(string xml)
        {
            return (xml != null) ? ParseUtility.ParseXmlDocument(xml) : null;
        }
    }
}
