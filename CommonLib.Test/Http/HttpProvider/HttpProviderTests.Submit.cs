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
        [Test]
        public static void HttpProvider_DownloadMaximumContentLength_exceeded()
        {
            var httpClient = new HttpClient();
            httpClient.MaximumDownloadContentLength = 100;
            Assert.Throws<ContentTooLargeException>(() => httpClient.DownloadBytes("http://httpbin.org/bytes/101"));
            Assert.Throws<ContentTooLargeException>(() => httpClient.DownloadString("http://httpbin.org/bytes/101"));
        }

        [Test]
        public static void HttpProvider_put_null_content()
        {
            var httpClient = new HttpClient();
            httpClient.DownloadString(httpClient.Submit("http://httpbin.org/put", "put", (string)null));
            httpClient.DownloadString(httpClient.Submit("http://httpbin.org/put", "put", (NameValueCollection)null));

            httpClient.DownloadString(httpClient.SubmitJson("http://httpbin.org/put", "put", (object)null));
            httpClient.DownloadString(httpClient.SubmitJson("http://httpbin.org/put", "put", (NameValueCollection)null));
        }

        private static IEnumerable<TestCaseData> HttpProvider_Submit_url_method_content_TestCases()
        {
            yield return new TestCaseData("http://httpbin.org/put", "put", "hello");
            yield return new TestCaseData("http://httpbin.org/put", null, "hello").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/put", "", "hello").Throws(typeof(ArgumentException));
        }

        [Test]
        [TestCaseSource("HttpProvider_Submit_url_method_content_TestCases")]
        public static void HttpProvider_put_null_method(string url, string method, string content)
        {
            var result = HttpProvider.DownloadString(HttpProvider.Submit(url, method, content));
            Assert.IsNotNull(result);
        }

        [Test]
        public static void HttpProvider_HostNotFound()
        {
            Assert.Throws<WebException>(() => new HttpClient().DownloadString("http://random-domain-without-tld/"));
        }

        [Test]
        public static void HttpHelper_GetContent_gzip()
        {
            var gzipContent = HttpProvider.DownloadString("http://httpbin.org/gzip");
            Assert.IsNotNullOrEmpty(gzipContent);
        }

        [Test]
        public static void HttpHelper_GetContent_deflate()
        {
            var deflateContent = HttpProvider.DownloadString("http://httpbin.org/deflate");
            Assert.IsNotNullOrEmpty(deflateContent);
        }

        [Test]
        public static void HttpHelper_submit_request_with_custom_content_type()
        {
            var url = "http://httpbin.org/put";
            var request = HttpProvider.CreateRequest(url);
            request.ContentType = "application/custom";

            var content = "hello world";
            var responseString = HttpProvider.Put(request, content);
            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
            Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
            Assert.AreEqual(content, result["data"].ToString());
        }
    }
}
