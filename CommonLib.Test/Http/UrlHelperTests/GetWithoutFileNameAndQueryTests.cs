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
    public static class GetWithoutFileNameAndQueryTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_GetUriWithoutFileNameAndQueryTests_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("x").Throws(typeof(ArgumentException));
            yield return new TestCaseData("http://www.google.com/resource").Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com/resource?").Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com/path/resource?hello=world").Returns("http://www.google.com/path/");
            yield return new TestCaseData("../relative/path").Returns("../relative/");
            yield return new TestCaseData("../relative/path?").Returns("../relative/");
            yield return new TestCaseData("../relative/path/resource?hello=world").Returns("../relative/path/");
        }

        [Test]
        [TestCaseSource("UrlHelper_GetUriWithoutFileNameAndQueryTests_TestCases")]
        public static string UrlHelper_GetUriWithoutFileNameAndQuery(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.GetUriWithoutFileNameAndQuery(uri).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_GetUriWithoutFileNameAndQueryTests_TestCases")]
        public static string UrlHelper_GetPathOrUrlWithoutFileNameAndQuery(string url)
        {
            return UrlHelper.GetPathOrUrlWithoutFileNameAndQuery(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_GetUriWithoutFileNameAndQueryTests_TestCases")]
        public static string HttpExtensionMethods_WithoutFileNameAndQuery(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithoutFileNameAndQuery().ToString();
        }

    }
}
