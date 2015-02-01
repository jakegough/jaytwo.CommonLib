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
        private static IEnumerable<TestCaseData> HttpProvider_PostJson_with_object_TestCases()
        {
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().PostJson(url, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().PostJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().PostJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.PostJson(url, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.PostJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.PostJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new Uri(url).PostJson(content)));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).PostJson(content)));

            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitPostJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitPostJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new HttpClient().SubmitPostJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitPostJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitPostJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => HttpProvider.SubmitPostJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => new Uri(url).SubmitPostJson(content).DownloadString()));
            yield return new TestCaseData(new Func<string, object, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPostJson(content).DownloadString()));
        }

        [Test]
        [TestCaseSource("HttpProvider_PostJson_with_object_TestCases")]
        public static void HttpProvider_PostJson_with_object(Func<string, object, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
            var content = new { hello = "world" };
            var contentJson = new JavaScriptSerializer().Serialize(content);

            var responseString = submitMethod(url, content);
            Console.WriteLine(responseString);

            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
            //Assert.AreEqual("application/custom; charset=utf-8", result["headers"]["Content-Type"].ToString());
            Assert.AreEqual(contentJson, result["data"].ToString());
        }

        private static IEnumerable<TestCaseData> HttpProvider_PostJson_with_form_TestCases()
        {
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().PostJson(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().PostJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().PostJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.PostJson(url, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.PostJson(new Uri(url), content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.PostJson(WebRequest.Create(url) as HttpWebRequest, content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new Uri(url).PostJson(content)));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).PostJson(content)));

            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitPostJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitPostJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new HttpClient().SubmitPostJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitPostJson(url, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitPostJson(new Uri(url), content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => HttpProvider.SubmitPostJson(WebRequest.Create(url) as HttpWebRequest, content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => new Uri(url).SubmitPostJson(content).DownloadString()));
            yield return new TestCaseData(new Func<string, NameValueCollection, string>((url, content) => (WebRequest.Create(url) as HttpWebRequest).SubmitPostJson(content).DownloadString()));
        }

        [Test]
        [TestCaseSource("HttpProvider_PostJson_with_form_TestCases")]
        public static void HttpProvider_PostJson_with_form(Func<string, NameValueCollection, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/post";
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
