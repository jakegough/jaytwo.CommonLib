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
        private static IEnumerable<TestCaseData> HttpProvider_DownloadString_TestCases()
        {
            yield return new TestCaseData(new Func<string, string>(url => new HttpClient().DownloadString(url)));
            yield return new TestCaseData(new Func<string, string>(url => new HttpClient().DownloadString(new Uri(url))));
            yield return new TestCaseData(new Func<string, string>(url => new HttpClient().DownloadString(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, string>(url => new HttpClient().DownloadString(HttpProvider.SubmitGet(WebRequest.Create(url) as HttpWebRequest))));
            yield return new TestCaseData(new Func<string, string>(url => HttpProvider.DownloadString(url)));
            yield return new TestCaseData(new Func<string, string>(url => HttpProvider.DownloadString(new Uri(url))));
            yield return new TestCaseData(new Func<string, string>(url => HttpProvider.DownloadString(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, string>(url => HttpProvider.DownloadString(HttpProvider.SubmitGet(WebRequest.Create(url) as HttpWebRequest))));
            yield return new TestCaseData(new Func<string, string>(url => new Uri(url).DownloadString()));
            yield return new TestCaseData(new Func<string, string>(url => (WebRequest.Create(url) as HttpWebRequest).DownloadString()));
            yield return new TestCaseData(new Func<string, string>(url => (WebRequest.Create(url) as HttpWebRequest).Submit().DownloadString()));
            yield return new TestCaseData(new Func<string, string>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitGet().DownloadString()));
        }

        [Test]
        [TestCaseSource("HttpProvider_DownloadString_TestCases")]
        public static void HttpProvider_DownloadString(Func<string, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/get";
            var responseString = submitMethod(url);

            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
        }
    }
}
