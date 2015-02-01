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
    public static class SetQueryStringParameterTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriQueryStringParameter_TestCases()
        {
            yield return new TestCaseData(null, "", "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", "", "value").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", null, "value").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", "hello", "world").Returns("http://www.google.com/?hello=world");
            yield return new TestCaseData("http://www.google.com/?hello=john", "hello", "world").Returns("http://www.google.com/?hello=world");
            yield return new TestCaseData("../relative/path", "hello", "world").Returns("../relative/path?hello=world");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string UrlHelper_SetUriQueryStringParameter(string url, string key, string value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriQueryStringParameter(uri, key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string HttpExtensionMethods_WithQueryStringParameter(string url, string key, string value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithQueryStringParameter(key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string UrlHelper_SetUriQueryStringParameter_generic(string url, string key, string value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriQueryStringParameter<string>(uri, key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string HttpExtensionMethods_WithQueryStringParameter_generi(string url, string key, string value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithQueryStringParameter<string>(key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string UrlHelper_SetUriQueryStringParameter_object(string url, string key, object value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriQueryStringParameter(uri, key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string HttpExtensionMethods_WithQueryStringParameter_object(string url, string key, object value)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithQueryStringParameter(key, value).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string UrlHelper_SetUrlQueryStringParameter(string url, string key, string value)
        {
            return UrlHelper.SetUrlQueryStringParameter(url, key, value);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string UrlHelper_SetUrlQueryStringParameter_generic(string url, string key, string value)
        {
            return UrlHelper.SetUrlQueryStringParameter<string>(url, key, value);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriQueryStringParameter_TestCases")]
        public static string UrlHelper_SetUrlQueryStringParameter_object(string url, string key, object value)
        {
            return UrlHelper.SetUrlQueryStringParameter(url, key, value);
        }
    }
}
