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
    public static class SetSchemeHttpsTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriSchemeHttps_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com").Returns("https://www.google.com/");
            yield return new TestCaseData("https://www.google.com").Returns("https://www.google.com/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriSchemeHttps_TestCases")]
        public static string UrlHelper_SetUriSchemeHttps(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriSchemeHttps(uri).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriSchemeHttps_TestCases")]
        public static string UrlHelper_SetUrlSchemeHttps(string url)
        {
            return UrlHelper.SetUrlSchemeHttps(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriSchemeHttps_TestCases")]
        public static string HttpExtensionMethods_WithSchemeHttps(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithSchemeHttps().ToString();
        }
    }
}
