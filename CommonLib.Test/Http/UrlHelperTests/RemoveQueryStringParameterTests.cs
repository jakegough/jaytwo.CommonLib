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
    public static class RemoveQueryStringParameterTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_RemoveUrlQueryStringParameter_TestCases()
        {
            yield return new TestCaseData(null, "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/resource", "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/resource", null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/resource", "hello").Returns("http://www.google.com/resource");
            yield return new TestCaseData("http://www.google.com/resource?hello=world", "hello").Returns("http://www.google.com/resource");
            yield return new TestCaseData("http://www.google.com/resource?a=b&hello=john", "hello").Returns("http://www.google.com/resource?a=b");
            yield return new TestCaseData("http://www.google.com/resource?a=b&hello=john&hello=world", "hello").Returns("http://www.google.com/resource?a=b");
            yield return new TestCaseData("http://www.google.com/?hello=world", "hello").Returns("http://www.google.com/");
            yield return new TestCaseData("../relative/path", "hello").Returns("../relative/path");
            yield return new TestCaseData("../relative/path?hello=world", "hello").Returns("../relative/path");
        }

        [Test]
        [TestCaseSource("UrlHelper_RemoveUrlQueryStringParameter_TestCases")]
        public static string UrlHelper_RemoveUrlQueryStringParameter(string url, string key)
        {
            return UrlHelper.RemoveUrlQueryStringParameter(url, key);
        }

        [Test]
        [TestCaseSource("UrlHelper_RemoveUrlQueryStringParameter_TestCases")]
        public static string UrlHelper_RemoveUriQueryStringParameter(string url, string key)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.RemoveUriQueryStringParameter(uri, key).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_RemoveUrlQueryStringParameter_TestCases")]
        public static string HttpExtensionMethods_WithoutQueryStringParameter(string url, string key)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithoutQueryStringParameter(key).ToString();
        }
    }
}
