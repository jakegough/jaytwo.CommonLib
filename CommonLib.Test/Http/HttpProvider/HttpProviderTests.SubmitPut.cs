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
        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_TestCases()
        {
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitPut(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitPut(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitPut(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitPut(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new Uri(url).SubmitPut()));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitPut()));

            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit((HttpWebRequest)null, "put"))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit((Uri)null, "put"))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit((string)null, "put"))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit(url, "put")));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit(new Uri(url), "put")));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put")));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.Submit(url, "put")));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.Submit(new Uri(url), "put")));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put")));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new Uri(url).Submit("put")));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => (WebRequest.Create(url) as HttpWebRequest).Submit("put")));

            yield return new TestCaseData(new Func<string, HttpWebResponse>(url =>
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "put";
                return new HttpClient().Submit(request);
            }));

            yield return new TestCaseData(new Func<string, HttpWebResponse>(url =>
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "put";
                return HttpProvider.Submit(request);
            }));

            yield return new TestCaseData(new Func<string, HttpWebResponse>(url =>
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "put";
                return request.Submit();
            }));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_TestCases")]
        public static void HttpProvider_SubmitPut(Func<string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
            using (var response = submitMethod(url))
            {
                var responseString = HttpHelper.GetContentAsString(response);
                Console.WriteLine(responseString);
                HttpHelper.VerifyResponseStatusOK(response);

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
            }
        }

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_with_content_TestCases()
        {
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(url, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(url, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new Uri(url).SubmitPut(content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(content)));

            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit((string)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit((Uri)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit((HttpWebRequest)null, "put", content))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit(url, "put", content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.Submit(url, "put", content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.Submit(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new Uri(url).Submit("put", content)));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", content)));

            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(url, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(new Uri(url), Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(url, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(new Uri(url), Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new Uri(url).SubmitPut(Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(Encoding.UTF8.GetBytes(content))));

            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit((string)null, "put", Encoding.UTF8.GetBytes(content)))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit((Uri)null, "put", Encoding.UTF8.GetBytes(content)))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit((HttpWebRequest)null, "put", Encoding.UTF8.GetBytes(content)))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit(url, "put", Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit(new Uri(url), "put", Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.Submit(url, "put", Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.Submit(new Uri(url), "put", Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => new Uri(url).Submit("put", Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", Encoding.UTF8.GetBytes(content))));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_with_content_TestCases")]
        public static void HttpProvider_SubmitPut_with_content(Func<string, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_with_content_contentType_TestCases()
        {
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(url, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(url, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new Uri(url).SubmitPut(content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(content, contentType)));

            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((string)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((Uri)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((HttpWebRequest)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(url, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(new Uri(url), "put", content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(url, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(new Uri(url), "put", content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new Uri(url).Submit("put", content, contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", content, contentType)));

            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(url, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(new Uri(url), Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(url, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(new Uri(url), Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new Uri(url).SubmitPut(Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(Encoding.UTF8.GetBytes(content), contentType)));

            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((string)null, "put", Encoding.UTF8.GetBytes(content), contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((Uri)null, "put", Encoding.UTF8.GetBytes(content), contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((HttpWebRequest)null, "put", Encoding.UTF8.GetBytes(content), contentType))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(url, "put", Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(new Uri(url), "put", Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(url, "put", Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(new Uri(url), "put", Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => new Uri(url).Submit("put", Encoding.UTF8.GetBytes(content), contentType)));
            yield return new TestCaseData(new Func<string, string, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", Encoding.UTF8.GetBytes(content), contentType)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_with_content_contentType_TestCases")]
        public static void HttpProvider_SubmitPut_with_content_contentType(Func<string, string, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_with_form_TestCases()
        {
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new Uri(url).SubmitPut(content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(content)));

            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().Submit((string)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().Submit((Uri)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().Submit((HttpWebRequest)null, "put", content))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().Submit(url, "put", content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().Submit(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.Submit(url, "put", content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.Submit(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => new Uri(url).Submit("put", content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_with_form_TestCases")]
        public static void HttpProvider_SubmitPut_with_form(Func<string, NameValueCollection, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_with_stream_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(url, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(url, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new Uri(url).SubmitPut(content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(content)));

            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().Submit((string)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().Submit((Uri)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().Submit((HttpWebRequest)null, "put", content))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().Submit(url, "put", content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().Submit(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.Submit(url, "put", content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.Submit(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => new Uri(url).Submit("put", content)));
            yield return new TestCaseData(new Func<string, Stream, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_with_stream_TestCases")]
        public static void HttpProvider_SubmitPut_with_stream(Func<string, Stream, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_with_stream_contentType_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(url, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(url, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(new Uri(url), content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new Uri(url).SubmitPut(content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(content, contentType)));

            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((string)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((Uri)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit((HttpWebRequest)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(url, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(new Uri(url), "put", content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(url, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(new Uri(url), "put", content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => new Uri(url).Submit("put", content, contentType)));
            yield return new TestCaseData(new Func<string, Stream, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", content, contentType)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_with_stream_contentType_TestCases")]
        public static void HttpProvider_SubmitPut_with_stream_contentType(Func<string, Stream, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_with_stream_contentLength_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().SubmitPut(url, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().SubmitPut(new Uri(url), content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.SubmitPut(url, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.SubmitPut(new Uri(url), content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new Uri(url).SubmitPut(content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(content, contentLength)));

            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().Submit((string)null, "put", content, contentLength))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().Submit((Uri)null, "put", content, contentLength))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().Submit((HttpWebRequest)null, "put", content, contentLength))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().Submit(url, "put", content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().Submit(new Uri(url), "put", content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.Submit(url, "put", content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.Submit(new Uri(url), "put", content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => new Uri(url).Submit("put", content, contentLength)));
            yield return new TestCaseData(new Func<string, Stream, long, HttpWebResponse>((url, content, contentLength) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", content, contentLength)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_with_stream_contentLength_TestCases")]
        public static void HttpProvider_SubmitPut_with_stream_contentLength(Func<string, Stream, long, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPut_with_stream_contentLength_contentType_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().SubmitPut(url, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().SubmitPut(new Uri(url), content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.SubmitPut(url, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.SubmitPut(new Uri(url), content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.SubmitPut(WebRequest.Create(url) as HttpWebRequest, content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new Uri(url).SubmitPut(content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitPut(content, contentLength, contentType)));

            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().Submit((string)null, "put", content, contentLength, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().Submit((Uri)null, "put", content, contentLength, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().Submit((HttpWebRequest)null, "put", content, contentLength, contentType))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().Submit(url, "put", content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().Submit(new Uri(url), "put", content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new HttpClient().Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.Submit(url, "put", content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.Submit(new Uri(url), "put", content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => HttpProvider.Submit(WebRequest.Create(url) as HttpWebRequest, "put", content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => new Uri(url).Submit("put", content, contentLength, contentType)));
            yield return new TestCaseData(new Func<string, Stream, long, string, HttpWebResponse>((url, content, contentLength, contentType) => (WebRequest.Create(url) as HttpWebRequest).Submit("put", content, contentLength, contentType)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPut_with_stream_contentLength_contentType_TestCases")]
        public static void HttpProvider_SubmitPut_with_stream_contentLength_contentType(Func<string, Stream, long, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPutJson_with_object_TestCases()
        {
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitPutJson(url, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitPutJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitPutJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitPutJson(url, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitPutJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitPutJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new Uri(url).SubmitPutJson(content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPutJson(content)));

            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitJson((string)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitJson((Uri)null, "put", content))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitJson((HttpWebRequest)null, "put", content))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitJson(url, "put", content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitJson(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new HttpClient().SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitJson(url, "put", content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitJson(new Uri(url), "put", content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => HttpProvider.SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => new Uri(url).SubmitJson("put", content)));
            yield return new TestCaseData(new Func<string, object, HttpWebResponse>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitJson("put", content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPutJson_with_object_TestCases")]
        public static void HttpProvider_SubmitPutJson_with_object(Func<string, object, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
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

        private static IEnumerable<TestCaseData> HttpProvider_SubmitPutJson_with_object_contentType_TestCases()
        {
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitJson((string)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitJson((Uri)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitJson((HttpWebRequest)null, "put", content, contentType))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitJson(url, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitJson(new Uri(url), "put", content, contentType)));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => new HttpClient().SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitJson(url, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitJson(new Uri(url), "put", content, contentType)));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => HttpProvider.SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType)));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => new Uri(url).SubmitJson("put", content, contentType)));
            yield return new TestCaseData(new Func<string, object, string, HttpWebResponse>((url, content, contentType) => (WebRequest.Create(url) as HttpWebRequest).SubmitJson("put", content, contentType)));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitPutJson_with_object_contentType_TestCases")]
        public static void HttpProvider_SubmitPutJson_with_object_contentType(Func<string, object, string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
            var content = new { hello = "world" };
            var contentJson = new JavaScriptSerializer().Serialize(content);
            var contentType = "application/custom";
            using (var response = submitMethod(url, content, contentType))
            {
                var responseString = response.DownloadString();
                Console.WriteLine(responseString);
                response.VerifyResponseStatusOK();

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(contentJson, result["data"].ToString());
            }
        }
    }
}
