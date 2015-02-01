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
    public static class GetQueryStringParameterTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_GetQueryStringParameter_TestCases()
        {
            yield return new TestCaseData(null, "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/resource", "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/resource", null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/resource", "hello").Returns(null);
            yield return new TestCaseData("http://www.google.com/resource?hello=world", "hello").Returns("world");
            yield return new TestCaseData("http://www.google.com/resource?a=b&hello=john", "a").Returns("b");
            yield return new TestCaseData("http://www.google.com/resource?a=b&hello=john&hello=world", "hello").Returns("john,world");
            yield return new TestCaseData("../relative/path", "hello").Returns(null);
            yield return new TestCaseData("../relative/path?hello=world", "hello").Returns("world");
        }

        [Test]
        [TestCaseSource("UrlHelper_GetQueryStringParameter_TestCases")]
        public static string UrlHelper_GetQueryStringParameterFromUri(string url, string parameterName)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.GetQueryStringParameterFromUri(uri, parameterName);
        }

        [Test]
        [TestCaseSource("UrlHelper_GetQueryStringParameter_TestCases")]
        public static string UrlHelper_GetQueryStringParameterFromPathOrUrl(string url, string parameterName)
        {
            return UrlHelper.GetQueryStringParameterFromPathOrUrl(url, parameterName);
        }

        [Test]
        [TestCaseSource("UrlHelper_GetQueryStringParameter_TestCases")]
        public static string HttpExtensionMethods_GetQueryStringParameter(string url, string parameterName)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.GetQueryStringParameter(parameterName);
        }
    }
}
