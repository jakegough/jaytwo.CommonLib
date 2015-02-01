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
    public static class GetWithoutQueryTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_GetUriWithoutQuery_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/resource").Returns("http://www.google.com/resource");
            yield return new TestCaseData("http://www.google.com/resource?").Returns("http://www.google.com/resource");
            yield return new TestCaseData("http://www.google.com/resource?hello=world").Returns("http://www.google.com/resource");
            yield return new TestCaseData("../relative/path").Returns("../relative/path");
            yield return new TestCaseData("../relative/path?").Returns("../relative/path");
            yield return new TestCaseData("../relative/path?hello=world").Returns("../relative/path");
        }

        [Test]
        [TestCaseSource("UrlHelper_GetUriWithoutQuery_TestCases")]
        public static string UrlHelper_GetUriWithoutQuery(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.GetUriWithoutQuery(uri).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_GetUriWithoutQuery_TestCases")]
        public static string UrlHelper_GetPathOrUrlWithoutQuery(string url)
        {
            return UrlHelper.GetPathOrUrlWithoutQuery(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_GetUriWithoutQuery_TestCases")]
        public static string HttpExtensionMethods_WithoutQuery(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithoutQuery().ToString();
        }

    }
}
