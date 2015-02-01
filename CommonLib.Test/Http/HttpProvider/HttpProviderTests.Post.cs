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
        private static IEnumerable<TestCaseData> HttpProvider_Post_with_content_TestCases()
        {
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new HttpClient().Post(url, content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new HttpClient().Post(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new HttpClient().Post(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => HttpProvider.Post(url, content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => HttpProvider.Post(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => HttpProvider.Post(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new Uri(url).Post(content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Post(content)));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new HttpClient().Post(url, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new HttpClient().Post(new Uri(url), Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new HttpClient().Post(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => HttpProvider.Post(url, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => HttpProvider.Post(new Uri(url), Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => HttpProvider.Post(WebRequest.Create(url) as HttpWebRequest, Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => new Uri(url).Post(Encoding.UTF8.GetBytes(content))));
            yield return new TestCaseData(new Func<string, string, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Post(Encoding.UTF8.GetBytes(content))));
        }

        [Test]
        [TestCaseSource("HttpProvider_Post_with_content_TestCases")]
        public static void HttpProvider_Post_with_content(Func<string, string, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var content = "hello world";
            //var contentType = "application/custom";

            var responseString = submitMethod(url, content);
            Console.WriteLine(responseString);

            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
            //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
            Assert.AreEqual(content, result["data"].ToString());
        }

        private static IEnumerable<TestCaseData> HttpProvider_Post_with_form_TestCases()
        {
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().Post(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().Post(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().Post(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.Post(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.Post(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.Post(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new Uri(url).Post(content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Post(content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_Post_with_form_TestCases")]
        public static void HttpProvider_Post_with_form(Func<string, NameValueCollection, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var form = new NameValueCollection() { { "hello", "world" } };

            var responseString = submitMethod(url, form);
            Console.WriteLine(responseString);

            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
            //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
            Assert.AreEqual("world", result["form"]["hello"].ToString());
        }

        private static IEnumerable<TestCaseData> HttpProvider_Post_with_stream_TestCases()
        {
            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => new HttpClient().Post(url, content)));
            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => new HttpClient().Post(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => new HttpClient().Post(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => HttpProvider.Post(url, content)));
            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => HttpProvider.Post(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => HttpProvider.Post(WebRequest.Create(url) as HttpWebRequest, content)));

            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => new Uri(url).Post(content)));
            yield return new TestCaseData(new Func<string, Stream, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).Post(content)));
        }

        [Test]
        [TestCaseSource("HttpProvider_Post_with_stream_TestCases")]
        public static void HttpProvider_Post_with_stream(Func<string, Stream, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var content = "hello world";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                var responseString = submitMethod(url, stream);
                Console.WriteLine(responseString);

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
                //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
                Assert.AreEqual(content, result["data"].ToString());
            }
        }
    }
}
