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
    public static class SetPortHttpTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriPortHttp_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com:123").Returns("http://www.google.com/");
            yield return new TestCaseData("https://www.google.com:123").Returns("https://www.google.com:80/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortHttp_TestCases")]
        public static string UrlHelper_SetUriPortHttp(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriPortHttp(uri).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortHttp_TestCases")]
        public static string UrlHelper_SetUrlPortHttp(string url)
        {
            return UrlHelper.SetUrlPortHttp(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortHttp_TestCases")]
        public static string HttpExtensionMethods_WithPortHttp(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithPortHttp().ToString();
        }
    }
}
