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
        private static IEnumerable<TestCaseData> HttpProvider_SubmitDelete_TestCases()
        {
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitDelete(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitDelete(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitDelete(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitDelete(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitDelete(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitDelete(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new Uri(url).SubmitDelete()));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitDelete()));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitDelete_TestCases")]
        public static void HttpProvider_SubmitDelete(Func<string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/delete";
            using (var response = submitMethod(url))
            {
                var responseString = HttpHelper.GetContentAsString(response);
                Console.WriteLine(responseString);
                HttpHelper.VerifyResponseStatusOK(response);

                var result = JsonConvert.DeserializeObject<JObject>(responseString);
                Assert.AreEqual(url, result["url"].ToString());
            }
        }
    }
}
