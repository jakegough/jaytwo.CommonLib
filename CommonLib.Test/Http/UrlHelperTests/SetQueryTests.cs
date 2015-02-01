using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Http.UrlHelperTests
{
    public static partial class SetQueryTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_SetUriScheme_TestCases()
        {
            yield return new TestCaseData(null, new NameValueCollection() { { "hello", "word" }, { "this", "that" } }).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com", null).Returns("http://www.google.com/");
            yield return new TestCaseData("http://www.google.com", new NameValueCollection() { { "hello", "world" }, { "this", "that" } }).Returns("http://www.google.com/?hello=world&this=that");
            yield return new TestCaseData("https://www.google.com/path", new NameValueCollection() { { "hello", "world" }, { "this", "that" } }).Returns("https://www.google.com/path?hello=world&this=that");
            yield return new TestCaseData("../some/path", new NameValueCollection() { { "hello", "world" }, { "this", "that" } }).Returns("../some/path?hello=world&this=that");
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriScheme_TestCases")]
        public static string UrlHelper_SetUriQuery(string url, NameValueCollection query)
        {
            var uri = TestUtility.GetUriFromString(url);
            return UrlHelper.SetUriQuery(uri, query).ToString();
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriScheme_TestCases")]
        public static string UrlHelper_SetUrlScheme(string url, NameValueCollection query)
        {
            return UrlHelper.SetUrlQuery(url, query);
        }

        [Test]
        [TestCaseSource("UrlHelper_SetUriScheme_TestCases")]
        public static string HttpExtensionMethods_WithQuery(string url, NameValueCollection query)
        {
            var uri = TestUtility.GetUriFromString(url);
            return uri.WithQuery(query).ToString();
        }
    }
}
