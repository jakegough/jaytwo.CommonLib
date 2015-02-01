using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Http.UrlHelperTests
{
    [TestFixture]
    public static partial class UrlHelperTests
    {
        private static IEnumerable<TestCaseData> UrlHelper_CopyUri_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://www.google.com/some/path.ext?query=value");
            yield return new TestCaseData("../some/path.ext?query=value");
        }

        [Test]
        [TestCaseSource("UrlHelper_CopyUri_TestCases")]
        public static void UrlHelper_CopyUri(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            var copy = UrlHelper.CopyUri(uri);
            Assert.AreNotSame(uri, copy);
            Assert.AreEqual(uri, copy);
        }

        [Test]
        [TestCaseSource("UrlHelper_CopyUri_TestCases")]
        public static void HttpExtensionMethods_Uri_Copy(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            var copy = uri.Copy();
            Assert.AreNotSame(uri, copy);
            Assert.AreEqual(uri, copy);
        }

        [Test]
        public static void UrlHelper_PercentEncode()
        {
            Assert.AreEqual("this%26that%3Dfoo%2Fother%5Cnot", UrlHelper.PercentEncode(@"this&that=foo/other\not"));
            Assert.AreEqual(null, UrlHelper.PercentEncode(null));            
        }

        [Test]
        public static void UrlHelper_PercentEncodePath()
        {
            Assert.AreEqual("this%26that%3Dfoo/other%5Cnot", UrlHelper.PercentEncodePath(@"this&that=foo/other\not"));
            Assert.AreEqual(null, UrlHelper.PercentEncodePath(null));
        }

    }
}