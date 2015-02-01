using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Http.UrlHelperTests
{
    public static class AddQueryStringParameterTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_AddUriQueryStringParameter_TestCases()
        {
            yield return new TestCaseData(null, "", "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", "", "value").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", null, "value").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", "hello", "world").Returns("http://www.google.com/?hello=world");
            yield return new TestCaseData("http://www.google.com/?hello=john", "hello", "world").Returns("http://www.google.com/?hello=john&hello=world");
            yield return new TestCaseData("../relative/path", "hello", "world").Returns("../relative/path?hello=world");
        }

        [Test]
        [TestCaseSource("UrlHelper_AddUriQueryStringParameter_TestCases")]
        public static string UrlHelper_AddUriQueryStringParameter(string url, string key, string value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.AddUriQueryStringParameter(uri, key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_AddUriQueryStringParameter_TestCases")]
        public static string UrlHelper_AddUriQueryStringParameter_generic(string url, string key, string value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.AddUriQueryStringParameter<string>(uri, key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_AddUriQueryStringParameter_TestCases")]
        public static string UrlHelper_AddUriQueryStringParameter_object(string url, string key, object value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.AddUriQueryStringParameter(uri, key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_AddUriQueryStringParameter_TestCases")]
        public static string UrlHelper_AddUrlQueryStringParameter(string url, string key, string value)
        {
            return UrlHelper.AddUrlQueryStringParameter(url, key, value);
        }

        [Test]
        [TestCaseSource("UrlHelper_AddUriQueryStringParameter_TestCases")]
        public static string UrlHelper_AddUrlQueryStringParameter_generic(string url, string key, string value)
        {
            return UrlHelper.AddUrlQueryStringParameter<string>(url, key, value);
        }

        [Test]
        [TestCaseSource("UrlHelper_AddUriQueryStringParameter_TestCases")]
        public static string UrlHelper_AddUrlQueryStringParameter_object(string url, string key, object value)
        {
            return UrlHelper.AddUrlQueryStringParameter(url, key, value);
        }
    }
}
