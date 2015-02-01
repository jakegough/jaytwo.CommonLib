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
        private static IEnumerable<TestCaseData> HttpProvider_DownloadBytes_TestCases()
        {
            yield return new TestCaseData(new Func<string, byte[]>(url => new HttpClient().DownloadBytes(url)));
            yield return new TestCaseData(new Func<string, byte[]>(url => new HttpClient().DownloadBytes(new Uri(url))));
            yield return new TestCaseData(new Func<string, byte[]>(url => new HttpClient().DownloadBytes(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, byte[]>(url => new HttpClient().DownloadBytes(HttpProvider.SubmitGet(WebRequest.Create(url) as HttpWebRequest))));
            yield return new TestCaseData(new Func<string, byte[]>(url => HttpProvider.DownloadBytes(url)));
            yield return new TestCaseData(new Func<string, byte[]>(url => HttpProvider.DownloadBytes(new Uri(url))));
            yield return new TestCaseData(new Func<string, byte[]>(url => HttpProvider.DownloadBytes(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, byte[]>(url => HttpProvider.DownloadBytes(HttpProvider.SubmitGet(WebRequest.Create(url) as HttpWebRequest))));
            yield return new TestCaseData(new Func<string, byte[]>(url => new Uri(url).DownloadBytes()));
            yield return new TestCaseData(new Func<string, byte[]>(url => (WebRequest.Create(url) as HttpWebRequest).DownloadBytes()));
            yield return new TestCaseData(new Func<string, byte[]>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitGet().DownloadBytes()));
        }

        [Test]
        [TestCaseSource("HttpProvider_DownloadBytes_TestCases")]
        public static void HttpProvider_DownloadBytes(Func<string, byte[]> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/bytes/100";
            var responseBytes = submitMethod(url);
            Assert.AreEqual(100, responseBytes.Length);
        }
    }
}
