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
    public static class SetPortTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriPort_TestCases()
        {
            yield return new TestCaseData(null, 80).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("www.google.com", null).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData("http://www.google.com:123", null).Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com", 80).Returns("http://www.google.com/");
            yield return new TestCaseData("https://www.google.com", 80).Returns("https://www.google.com:80/");
            yield return new TestCaseData("https://www.google.com", 443).Returns("https://www.google.com/");
            yield return new TestCaseData("http://www.google.com", 443).Returns("http://www.google.com:443/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPort_TestCases")]
        public static string UrlHelper_SetUriPort(string url, int? newPort)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriPort(uri, newPort).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPort_TestCases")]
        public static string UrlHelper_SetUrlPort(string url, int? newPort)
        {
            return UrlHelper.SetUrlPort(url, newPort);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPort_TestCases")]
        public static string HttpExtensionMethods_WithPort(string url, int? newPort)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithPort(newPort).ToString();
        }
    }
}
