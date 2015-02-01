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
        private static IEnumerable<TestCaseData> HttpProvider_SubmitGet_TestCases()
        {
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit((HttpWebRequest)WebRequest.Create(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().Submit((HttpWebRequest)null))).Throws(typeof(ArgumentNullException));

            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitGet(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitGet(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitGet(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitGet(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitGet(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitGet(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new Uri(url).SubmitGet()));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitGet()));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitGet_TestCases")]
        public static void HttpProvider_SubmitGet(Func<string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/get";
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
