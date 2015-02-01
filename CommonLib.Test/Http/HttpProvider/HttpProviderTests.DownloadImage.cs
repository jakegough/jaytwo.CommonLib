using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
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
        private static IEnumerable<TestCaseData> HttpProvider_DownloadImage_TestCases()
        {
            yield return new TestCaseData(new Func<string, Image>(url => new HttpClient().DownloadImage(url)));
            yield return new TestCaseData(new Func<string, Image>(url => new HttpClient().DownloadImage(new Uri(url))));
            yield return new TestCaseData(new Func<string, Image>(url => new HttpClient().DownloadImage(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, Image>(url => new HttpClient().DownloadImage(HttpProvider.SubmitGet(WebRequest.Create(url) as HttpWebRequest))));
            yield return new TestCaseData(new Func<string, Image>(url => HttpProvider.DownloadImage(url)));
            yield return new TestCaseData(new Func<string, Image>(url => HttpProvider.DownloadImage(new Uri(url))));
            yield return new TestCaseData(new Func<string, Image>(url => HttpProvider.DownloadImage(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, Image>(url => HttpProvider.DownloadImage(HttpProvider.SubmitGet(WebRequest.Create(url) as HttpWebRequest))));
            yield return new TestCaseData(new Func<string, Image>(url => new Uri(url).DownloadImage()));
            yield return new TestCaseData(new Func<string, Image>(url => (WebRequest.Create(url) as HttpWebRequest).DownloadImage()));
            yield return new TestCaseData(new Func<string, Image>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitGet().DownloadImage()));
        }

        [Test]
        [TestCaseSource("HttpProvider_DownloadImage_TestCases")]
        public static void HttpProvider_DownloadImage(Func<string, Image> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/image/jpeg";
            var responseImage = submitMethod(url);
            Assert.AreNotEqual(0, responseImage.Height);
            Assert.AreNotEqual(0, responseImage.Width);
        }
    }
}
