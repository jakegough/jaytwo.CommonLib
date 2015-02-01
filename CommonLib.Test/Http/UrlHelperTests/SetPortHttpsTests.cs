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
    public static class SetPortHttpsTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriPortHttps_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com:123").Returns("http://www.google.com:443/");
            yield return new TestCaseData("https://www.google.com:123").Returns("https://www.google.com/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortHttps_TestCases")]
        public static string UrlHelper_SetUriPortHttps(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriPortHttps(uri).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortHttps_TestCases")]
        public static string UrlHelper_SetUrlPortHttps(string url)
        {
            return UrlHelper.SetUrlPortHttps(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortHttps_TestCases")]
        public static string HttpExtensionMethods_WithPortHttps(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithPortHttps().ToString();
        }
    }
}
