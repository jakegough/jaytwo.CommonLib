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
    public static class GetFileNameAndQueryTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_GetFileNameAndQuery_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("x").Throws(typeof(ArgumentException));
            yield return new TestCaseData("../").Returns("");
            yield return new TestCaseData("../foo").Returns("foo");
            yield return new TestCaseData("../foo/bar?").Returns("bar?");
            yield return new TestCaseData("../foo/bar?foo=bar").Returns("bar?foo=bar");
            yield return new TestCaseData("http://www.google.com/").Returns("");
            yield return new TestCaseData("http://www.google.com/foo").Returns("foo");
            yield return new TestCaseData("http://www.google.com/foo/bar?").Returns("bar?");
            yield return new TestCaseData("http://www.google.com/foo/bar?foo=bar").Returns("bar?foo=bar");
        }

        [Test]
        [TestCaseSource("UrlHelper_GetFileNameAndQuery_TestCases")]
        public static string UrlHelper_GetFileNameAndQuery_url(string url)
        {
            return UrlHelper.GetFileNameAndQuery(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_GetFileNameAndQuery_TestCases")]
        public static string UrlHelper_GetFileNameAndQuery_uri(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.GetFileNameAndQuery(uri);
        }

        [Test]
        [TestCaseSource("UrlHelper_GetFileNameAndQuery_TestCases")]
        public static string HttpExtensionMethods_GetFileNameAndQuery_uri(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.GetFileNameAndQuery();
        }
    }
}
