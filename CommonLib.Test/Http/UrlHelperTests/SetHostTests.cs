using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Http.UrlHelperTests
{
    public static class SetHostTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriHost_TestCases()
        {
            yield return new TestCaseData(null, "example").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com", null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com", "").Throws(typeof(ArgumentException));
            yield return new TestCaseData("../some/path", "example").Throws(typeof(InvalidOperationException));
            yield return new TestCaseData("http://www.google.com", "example").Returns("http://example/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriHost_TestCases")]
        public static string UrlHelper_SetUriHost(string url, string newHost)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriHost(uri, newHost).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriHost_TestCases")]
        public static string UrlHelper_SetUrlHost(string url, string newHost)
        {
            return UrlHelper.SetUrlHost(url, newHost).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriHost_TestCases")]
        public static string HttpExtensionMethods_WithHost(string url, string newHost)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithHost(newHost).ToString();
        }

        private static IEnumerable<TestCaseData> UrlHelper_SetUriHost_with_port_TestCases()
        {
            yield return new TestCaseData(null, "example", 123).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com", null, 123).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com", "", 123).Throws(typeof(ArgumentException));
            yield return new TestCaseData("../some/path", "example", 123).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData("http://www.google.com", "example", 123).Returns("http://example:123/");
            yield return new TestCaseData("http://www.google.com:123", "example", null).Returns("http://example/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriHost_with_port_TestCases")]
        public static string UrlHelper_SetUriHost_with_port(string url, string newHost, int? newPort)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriHost(uri, newHost, newPort).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriHost_with_port_TestCases")]
        public static string UrlHelper_SetUrlHost_with_port(string url, string newHost, int? newPort)
        {
            return UrlHelper.SetUrlHost(url, newHost, newPort).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriHost_with_port_TestCases")]
        public static string HttpExtensionMethods_WithHost_with_port(string url, string newHost, int? newPort)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithHost(newHost, newPort).ToString();
        }
    }
}
