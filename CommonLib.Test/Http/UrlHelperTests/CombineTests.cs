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
    public static class CombineTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_Combine_uri_uri_TestCases()
        {
            yield return new TestCaseData(null, "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", null).Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com/", "").Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com", "/hello/world").Returns("http://www.google.com/hello/world");
            yield return new TestCaseData("http://www.google.com/", "/hello/world").Returns("http://www.google.com/hello/world");
            yield return new TestCaseData("http://www.google.com/other/path", "hello/world").Returns("http://www.google.com/other/path/hello/world");
            yield return new TestCaseData("http://www.google.com/", "path/").Returns("http://www.google.com/path/");
            yield return new TestCaseData("../relative/path", "hello").Returns("../relative/path/hello");
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_uri_uri_TestCases")]
        public static string UrlHelper_Combine_uri_uri(string fooUrl, string barUrl)
        {
            var foo = TestUtility.GetUriFromString(fooUrl);
            var bar = TestUtility.GetUriFromString(barUrl);
            return UrlHelper.Combine(foo, bar).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_uri_uri_TestCases")]
        public static string HttpExtensionMethods_CombineWith_uri_uri(string fooUrl, string barUrl)
        {
            var foo = TestUtility.GetUriFromString(fooUrl);
            var bar = TestUtility.GetUriFromString(barUrl);
            return foo.CombineWith(bar).ToString();
        }

        private static IEnumerable<TestCaseData> UrlHelper_Combine_baseUrl_path_TestCases()
        {
            yield return new TestCaseData(null, "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", null).Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com/", "").Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com/", "path").Returns("http://www.google.com/path");
            yield return new TestCaseData("http://www.google.com/", "path/").Returns("http://www.google.com/path/");
            yield return new TestCaseData("../relative/path", "hello").Returns("../relative/path/hello");
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_baseUrl_path_TestCases")]
        public static string UrlHelper_Combine_baseUrl_path(string baseUrl, string path)
        {
            return UrlHelper.Combine(baseUrl, path);
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_baseUrl_path_TestCases")]
        public static string UrlHelper_Combine_baseUri_path(string baseUrl, string path)
        {
            var uri = TestUtility.GetUriFromString(baseUrl);
            return UrlHelper.Combine(uri, path).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_baseUrl_path_TestCases")]
        public static string HttpExtensionMethods_CombineWith_baseUrl_path(string baseUrl, string path)
        {
            var uri = TestUtility.GetUriFromString(baseUrl);
            return uri.CombineWith(path).ToString();
        }

        private static IEnumerable<TestCaseData> UrlHelper_Combine_baseUrl_path1_path2_TestCases()
        {
            yield return new TestCaseData(null, new[] { "", "" }).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/", null).Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com/", new[] { "", "weird" }).Returns("http://www.google.com/weird");
            yield return new TestCaseData("http://www.google.com/", new[] { "path1", "path2" }).Returns("http://www.google.com/path1/path2");
            yield return new TestCaseData("http://www.google.com/", new[] { "path1", "path2/" }).Returns("http://www.google.com/path1/path2/");
            yield return new TestCaseData("../relative/path", new[] { "path1", "path2/" }).Returns("../relative/path/path1/path2/");
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_baseUrl_path1_path2_TestCases")]
        public static string UrlHelper_Combine_baseUrl_path1_path2(string baseUrl, string[] paths)
        {
            return UrlHelper.Combine(baseUrl, paths);
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_baseUrl_path1_path2_TestCases")]
        public static string UrlHelper_Combine_baseUri_path1_path2(string baseUrl, string[] paths)
        {
            var uri = TestUtility.GetUriFromString(baseUrl);
            return UrlHelper.Combine(uri, paths).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_Combine_baseUrl_path1_path2_TestCases")]
        public static string HttpExtensionMethods_CombineWith_baseUri_path1_path2(string baseUrl, string[] paths)
        {
            var uri = TestUtility.GetUriFromString(baseUrl);
            return uri.CombineWith(paths).ToString();
        }
    }
}
