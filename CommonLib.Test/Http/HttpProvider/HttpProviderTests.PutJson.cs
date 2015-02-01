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
        private static IEnumerable<TestCaseData> HttpProvider_PutJson_with_object_TestCases()
        {
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().PutJson(url, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().PutJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().PutJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.PutJson(url, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.PutJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.PutJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new Uri(url).PutJson(content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).PutJson(content)));

            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitPutJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitPutJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitPutJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitPutJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitPutJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitPutJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new Uri(url).SubmitPutJson(content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPutJson(content).DownloadString()));

            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitJson(url, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitJson(new Uri(url), "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitJson(url, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitJson(new Uri(url), "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new Uri(url).SubmitJson("put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitJson("put", content).DownloadString()));

            var contentType = "application/json";

            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitJson(url, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitJson(new Uri(url), "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitJson(url, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitJson(new Uri(url), "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new Uri(url).SubmitJson("put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitJson("put", content, contentType).DownloadString()));
        }

        [Test]
        [TestCaseSource("HttpProvider_PutJson_with_object_TestCases")]
        public static void HttpProvider_PutJson_with_object(Func<string, object, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
            var content = new { hello = "world" };
            var contentJson = new JavaScriptSerializer().Serialize(content);

            var responseString = submitMethod(url, content);
            Console.WriteLine(responseString);

            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
            //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
            Assert.AreEqual(contentJson, result["data"].ToString());
        }

        private static IEnumerable<TestCaseData> HttpProvider_PutJson_with_form_TestCases()
        {
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().PutJson(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().PutJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().PutJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.PutJson(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.PutJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.PutJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new Uri(url).PutJson(content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).PutJson(content)));

            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitPutJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitPutJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitPutJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitPutJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitPutJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitPutJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new Uri(url).SubmitPutJson(content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPutJson(content).DownloadString()));

            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitJson(url, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitJson(new Uri(url), "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitJson(url, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitJson(new Uri(url), "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new Uri(url).SubmitJson("put", content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitJson("put", content).DownloadString()));

            var contentType = "application/json";

            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitJson(url, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitJson(new Uri(url), "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitJson(url, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitJson(new Uri(url), "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitJson(WebRequest.Create(url) as HttpWebRequest, "put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new Uri(url).SubmitJson("put", content, contentType).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitJson("put", content, contentType).DownloadString()));
        }

        [Test]
        [TestCaseSource("HttpProvider_PutJson_with_form_TestCases")]
        public static void HttpProvider_PutJson_with_form(Func<string, NameValueCollection, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/put";
            var form = new NameValueCollection() { { "hello", "world" } };

            var responseString = submitMethod(url, form);
            Console.WriteLine(responseString);

            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
            //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
            Assert.AreEqual("world", result["json"]["hello"].ToString());
        }
    }
}
