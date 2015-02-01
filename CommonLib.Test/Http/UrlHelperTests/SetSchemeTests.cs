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
    public static class SetSchemeTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriScheme_TestCases()
        {
            yield return new TestCaseData(null, "http").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com", null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com", "").Throws(typeof(ArgumentException));
            yield return new TestCaseData("../some/path", "https").Throws(typeof(InvalidOperationException));
            yield return new TestCaseData("http://www.google.com", "https").Returns("https://www.google.com/");
            yield return new TestCaseData("https://www.google.com", "ftp").Returns("ftp://www.google.com/");
            yield return new TestCaseData("https://www.google.com:123", "ftp").Returns("ftp://www.google.com:123/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriScheme_TestCases")]
        public static string UrlHelper_SetUriScheme(string url, string newScheme)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriScheme(uri, newScheme).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriScheme_TestCases")]
        public static string UrlHelper_SetUrlScheme(string url, string newScheme)
        {
            return UrlHelper.SetUrlScheme(url, newScheme);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriScheme_TestCases")]
        public static string HttpExtensionMethods_WithScheme(string url, string newScheme)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithScheme(newScheme).ToString();
        }
    }
}
