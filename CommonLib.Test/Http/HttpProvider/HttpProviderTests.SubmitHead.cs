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
        private static IEnumerable<TestCaseData> HttpProvider_SubmitHead_TestCases()
        {
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitHead(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitHead(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new HttpClient().SubmitHead(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitHead(url)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitHead(new Uri(url))));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => HttpProvider.SubmitHead(WebRequest.Create(url) as HttpWebRequest)));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => new Uri(url).SubmitHead()));
            yield return new TestCaseData(new Func<string, HttpWebResponse>(url => (WebRequest.Create(url) as HttpWebRequest).SubmitHead()));
        }

        [Test]
        [TestCaseSource("HttpProvider_SubmitHead_TestCases")]
        public static void HttpProvider_SubmitHead(Func<string, HttpWebResponse> submitMethod)
        {
            // http://httpbin.org/
            var url = "http://httpbin.org/get";
            using (var response = submitMethod(url))
            {
                var responseString = HttpHelper.GetContentAsString(response);
                Console.WriteLine(responseString);
                HttpHelper.VerifyResponseStatusOK(response);

                Assert.IsNullOrEmpty(responseString);
            }
        }
    }
}
