using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace jaytwo.Common.Test.Http
{
    [TestFixture]
    public static partial class HttpProviderTests
    {
        private static IEnumerable<TestCaseData> HttpProvider_CreateRequest_TestCases()
        {
            yield return new TestCaseData("http://httpbin.org/get");
        }

        [Test]
        [TestCaseSource("HttpProvider_CreateRequest_TestCases")]
        public static void HttpProvider_CreateRequest_uri(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            var request = HttpProvider.CreateRequest(uri);
            Assert.AreEqual(uri, request.RequestUri);
        }

        [Test]
        [TestCaseSource("HttpProvider_CreateRequest_TestCases")]
        public static void HttpExtensionMethods_Uri_CreateHttpWebRequest(string url)
        {
            var uri = TestUtility.GetUriFromString(url);
            var request = uri.CreateHttpWebRequest();
            Assert.AreEqual(uri, request.RequestUri);
        }

        [Test]
        [TestCaseSource("HttpProvider_CreateRequest_TestCases")]
        public static void HttpProvider_CreateRequest_url(string url)
        {
            var request = HttpProvider.CreateRequest(url);
            Assert.AreEqual(url, request.RequestUri.AbsoluteUri);
        }
    }
}
