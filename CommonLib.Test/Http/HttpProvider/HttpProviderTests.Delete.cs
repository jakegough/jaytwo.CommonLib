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
        private static IEnumerable<TestCaseData> HttpProvider_Delete_TestCases()
        {
            yield return new TestCaseData(new Func<string, string>(url => new HttpClient().Delete(url)));
            yield return new TestCaseData(new Func<string, string>(url => new HttpClient().Delete(new Uri(url))));
            yield return new TestCaseData(new Func<string, string>(url => new HttpClient().Delete(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, string>(url => HttpProvider.Delete(url)));
            yield return new TestCaseData(new Func<string, string>(url => HttpProvider.Delete(new Uri(url))));
            yield return new TestCaseData(new Func<string, string>(url => HttpProvider.Delete(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, string>(url => new Uri(url).Delete()));
            yield return new TestCaseData(new Func<string, string>(url => (WebRequest.Create(url) as HttpWebRequest).Delete()));
        }

        [Test]
        [TestCaseSource("HttpProvider_Delete_TestCases")]
        public static void HttpProvider_Delete(Func<string, string> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/delete";
            var responseString = submitMethod(url);

            var result = JsonConvert.DeserializeObject<JObject>(responseString);
            Assert.AreEqual(url, result["url"].ToString());
        }
    }
}
