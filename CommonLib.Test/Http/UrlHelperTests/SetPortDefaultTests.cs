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
    public static class SetPortDefaultTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriPortDefault_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com:123").Returns("http://www.google.com/");
            yield return new TestCaseData("https://www.google.com:123").Returns("https://www.google.com/");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortDefault_TestCases")]
        public static string UrlHelper_SetUriPortDefault(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriPortDefault(uri).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortDefault_TestCases")]
        public static string UrlHelper_SetUrlPortDefault(string url)
        {
            return UrlHelper.SetUrlPortDefault(url);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriPortDefault_TestCases")]
        public static string HttpExtensionMethods_WithPortDefault(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithPortDefault().ToString();
        }
    }
}
