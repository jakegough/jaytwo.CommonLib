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
        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_TestCases()
        {
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitPost(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitPost(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitPost(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitPost(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest)));

            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new Uri(url).SubmitPost()));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitPost()));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_TestCases")]
        public static void HttpProvider_SubmitPost(Func<string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            using (var response = submitMethod(url))
            {
                var responseString = HttpHelper.GetContentAsString(response);
                Console.WriteLine(responseString);
                HttpHelper.VerifyResponseStatusOK(response);

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_with_content_TestCases()
        {
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(url, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(url, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new Uri(url).SubmitPost(content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(url, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(new Uri(url), Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(url, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(new Uri(url), Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new Uri(url).SubmitPost(Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(Encoding.UTF8.GetBytes(content))));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_with_content_TestCases")]
        public static void HttpProvider_SubmitPost_with_content(Func<string, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var content = "hello world";
            //var contentType = "application/custom";
            using (var response = submitMethod(url, content))
            {
                var responseString = HttpHelper.GetContentAsString(response);
                Console.WriteLine(responseString);
                HttpHelper.VerifyResponseStatusOK(response);

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(content, result["data"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_with_content_contentType_TestCases()
        {
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(url, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(url, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new Uri(url).SubmitPost(content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(content, contentType)));

            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(url, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(new Uri(url), Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(url, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(new Uri(url), Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new Uri(url).SubmitPost(Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(Encoding.UTF8.GetBytes(content), contentType)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_with_content_contentType_TestCases")]
        public static void HttpProvider_SubmitPost_with_content_contentType(Func<string, string, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var content = "hello world";
            var contentType = "application/custom";
            using (var response = submitMethod(url, content, contentType))
            {
                var responseString = HttpHelper.GetContentAsString(response);
                Console.WriteLine(responseString);
                HttpHelper.VerifyResponseStatusOK(response);

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(content, result["data"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_with_form_TestCases()
        {
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new Uri(url).SubmitPost(content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_with_form_TestCases")]
        public static void HttpProvider_SubmitPost_with_form(Func<string, NameValueCollection, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var form = new NameValueCollection() { { "hello", "world" } };

            using (var response = submitMethod(url, form))
            {
                var responseString = HttpHelper.GetContentAsString(response);
                Console.WriteLine(responseString);
                HttpHelper.VerifyResponseStatusOK(response);

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual("world", result["form"]["hello"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_with_stream_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(url, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(url, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new Uri(url).SubmitPost(content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_with_stream_TestCases")]
        public static void HttpProvider_SubmitPost_with_stream(Func<string, Stream, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var content = "hello world";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            using (var response = submitMethod(url, stream))
            {
                var responseString = response.DownloadString();
                Console.WriteLine(responseString);
                response.VerifyResponseStatusOK();

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(content, result["data"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_with_stream_contentType_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(url, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(url, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new Uri(url).SubmitPost(content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(content, contentType)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_with_stream_contentType_TestCases")]
        public static void HttpProvider_SubmitPost_with_stream_contentType(Func<string, Stream, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var contentType = "application/custom";
            var content = "hello world";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            using (var response = submitMethod(url, stream, contentType))
            {
                var responseString = response.DownloadString();
                Console.WriteLine(responseString);
                response.VerifyResponseStatusOK();

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(content, result["data"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_with_stream_contentLength_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().SubmitPost(url, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().SubmitPost(new Uri(url), content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.SubmitPost(url, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.SubmitPost(new Uri(url), content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new Uri(url).SubmitPost(content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(content, contentLength)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_with_stream_contentLength_TestCases")]
        public static void HttpProvider_SubmitPost_with_stream_contentLength(Func<string, Stream, long, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            //var contentType = "application/custom";
            var content = "hello world";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            using (var response = submitMethod(url, stream, content.Length))
            {
                var responseString = response.DownloadString();
                Console.WriteLine(responseString);
                response.VerifyResponseStatusOK();

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(content, result["data"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPost_with_stream_contentLength_contentType_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().SubmitPost(url, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().SubmitPost(new Uri(url), content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.SubmitPost(url, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.SubmitPost(new Uri(url), content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.SubmitPost(WebRequest.Create(url) as HttpWebRequest, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new Uri(url).SubmitPost(content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPost(content, contentLength, contentType)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPost_with_stream_contentLength_contentType_TestCases")]
        public static void HttpProvider_SubmitPost_with_stream_contentLength_contentType(Func<string, Stream, long, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var contentType = "application/custom";
            var content = "hello world";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            using (var response = submitMethod(url, stream, content.Length, contentType))
            {
                var responseString = response.DownloadString();
                Console.WriteLine(responseString);
                response.VerifyResponseStatusOK();

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(content, result["data"].ToString());
            }
        }


        private static IEnumerable<TestCaseData> HttpProvider_SubmitPostJson_with_object_TestCases()
        {
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitPostJson(url, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitPostJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitPostJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitPostJson(url, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitPostJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitPostJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new Uri(url).SubmitPostJson(content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPostJson(content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPostJson_with_object_TestCases")]
        public static void HttpProvider_SubmitPostJson_with_object(Func<string, object, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var content = new { hello = "world" };
            var contentJson = new JavaScriptSerializer().Serialize(content);

            using (var response = submitMethod(url, content))
            {
                var responseString = response.DownloadString();
                Console.WriteLine(responseString);
                response.VerifyResponseStatusOK();

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(contentJson, result["data"].ToString());
            }
        }
    }
}
