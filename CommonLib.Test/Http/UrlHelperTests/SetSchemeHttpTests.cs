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
    public static class SetSchemeHttpTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriSchemeHttp_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com").Returns("http://www.google.com/");
            yield return new TestCaseData("https://www.google.com").Returns("http://www.google.com/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriSchemeHttp_TestCases")]
        public static string UrlHelper_SetUriSchemeHttp(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriSchemeHttp(uri).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriSchemeHttp_TestCases")]
        public static string UrlHelper_SetUrlSchemeHttp(string url)
        {
            return UrlHelper.SetUrlSchemeHttp(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriSchemeHttp_TestCases")]
        public static string HttpExtensionMethods_WithSchemeHttp(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithSchemeHttp().ToString();
        }
    }
}
