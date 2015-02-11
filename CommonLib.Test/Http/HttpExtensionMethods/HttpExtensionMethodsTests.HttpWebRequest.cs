using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Http
{
    [TestFixture]
    public static partial class HttpExtensionMethodsTests
    {
        public static HttpWebRequest CreateRequest(string url)
        {
            return WebRequest.Create(url) as HttpWebRequest;
        }

        public static HttpWebRequest CreateRequest()
        {
            return CreateRequest("http://www.google.com");
        }

        private static IEnumerable<TestCaseData> HttpWebRequest_TestCases()
        {
            yield return new TestCaseData(CreateRequest("http://www.google.com"));
            yield return new TestCaseData(CreateRequest("https://www.google.com"));
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithAcceptGzipDeflateHeader(HttpWebRequest request)
        {
            Assert.AreEqual(
                "gzip,deflate",
                request.WithAcceptGzipDeflateHeader().Headers[HttpRequestHeader.AcceptEncoding]);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithContentLength(HttpWebRequest request)
        {
            var value = 123;
            Assert.AreEqual(
                value,
                request.WithContentLength(value).ContentLength);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithContentType(HttpWebRequest request)
        {
            var value = "random";
            Assert.AreEqual(
                value,
                request.WithContentType(value).ContentType);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithHeader(HttpWebRequest request)
        {
            var value = "random";
            Assert.AreEqual(
                value,
                request.WithHeader(HttpRequestHeader.ContentMd5, value).Headers[HttpRequestHeader.ContentMd5]);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithMethod(HttpWebRequest request)
        {
            var value = "options";
            Assert.AreEqual(
                value,
                request.WithMethod(value).Method);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithUserAgent(HttpWebRequest request)
        {
            var value = "options";
            Assert.AreEqual(
                value,
                request.WithUserAgent(value).UserAgent);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithHeader_string(HttpWebRequest request)
        {
            var value = "options";
            Assert.AreEqual(
                value,
                request.WithHeader("x-jake-foo", value).Headers["x-jake-foo"]);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithCookieContainer(HttpWebRequest request)
        {
            var value = new CookieContainer(123);
            Assert.AreEqual(
                value,
                request.WithCookieContainer(value).CookieContainer);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithProxy(HttpWebRequest request)
        {
            var value = new WebProxy();
            Assert.AreEqual(
                value,
                request.WithProxy(value).Proxy);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithProxy_address(HttpWebRequest request)
        {
            var address = "http://proxy.example/";
            var addressUri = new Uri(address);
            var value = new WebProxy();
            var requestWithProxyAaddress = request.WithProxy(address);
            var proxy = requestWithProxyAaddress.Proxy as WebProxy;

            Assert.AreEqual(
                addressUri,
                proxy.Address);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithBasicAuthentication(HttpWebRequest request)
        {
            var user = "hello";
            var pass = "world";
            var value = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + pass));

            Assert.AreEqual(
                value,
                request.WithBasicAuthentication(user, pass).Headers[HttpRequestHeader.Authorization]);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithCredentials(HttpWebRequest request)
        {
            var user = "hello";
            var pass = "world";
            var domain = "again";

            request = request.WithCredentials(user, pass, domain);
            Assert.AreEqual(
                user,
                (request.Credentials as NetworkCredential).UserName);

            Assert.AreEqual(
                pass,
                (request.Credentials as NetworkCredential).Password);

            Assert.AreEqual(
                domain,
                (request.Credentials as NetworkCredential).Domain);

            request = CreateRequest().WithCredentials(user, pass);
            Assert.AreEqual(
                user,
                (request.Credentials as NetworkCredential).UserName);

            Assert.AreEqual(
                pass,
                (request.Credentials as NetworkCredential).Password);

            Assert.AreEqual(
                string.Empty,
                (request.Credentials as NetworkCredential).Domain);

            request = CreateRequest().WithCredentials(new NetworkCredential(user, pass, domain));
            Assert.AreEqual(
                user,
                (request.Credentials as NetworkCredential).UserName);

            Assert.AreEqual(
                pass,
                (request.Credentials as NetworkCredential).Password);

            Assert.AreEqual(
                domain,
                (request.Credentials as NetworkCredential).Domain);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithCredentials_with_userName_password_domain(HttpWebRequest request)
        {
            var user = "hello";
            var pass = "world";
            var domain = "again";

            request = request.WithCredentials(user, pass, domain);
            Assert.AreEqual(
                user,
                (request.Credentials as NetworkCredential).UserName);

            Assert.AreEqual(
                pass,
                (request.Credentials as NetworkCredential).Password);

            Assert.AreEqual(
                domain,
                (request.Credentials as NetworkCredential).Domain);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithCredentials_with_userName_password(HttpWebRequest request)
        {
            var user = "hello";
            var pass = "world";

            request = request.WithCredentials(user, pass);
            Assert.AreEqual(
                user,
                (request.Credentials as NetworkCredential).UserName);

            Assert.AreEqual(
                pass,
                (request.Credentials as NetworkCredential).Password);

            Assert.AreEqual(
                string.Empty,
                (request.Credentials as NetworkCredential).Domain);
        }

        [Test]
        [TestCaseSource("HttpWebRequest_TestCases")]
        public static void HttpWebRequest_WithCredentials_with_credentials(HttpWebRequest request)
        {
            var user = "hello";
            var pass = "world";
            var domain = "again";

            request = request.WithCredentials(new NetworkCredential(user, pass, domain));
            Assert.AreEqual(
                user,
                (request.Credentials as NetworkCredential).UserName);

            Assert.AreEqual(
                pass,
                (request.Credentials as NetworkCredential).Password);

            Assert.AreEqual(
                domain,
                (request.Credentials as NetworkCredential).Domain);
        }

#if NET_4_5
        private static IEnumerable<TestCaseData> HttpClient_DisableServerCertificateValidation_TestCases()
        {
            //yield return new TestCaseData(CreateRequest("http://www.google.com")); // don't know why, but it times out regular http
            yield return new TestCaseData(CreateRequest("https://www.google.com"));
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
        }

        [Test]
        [TestCaseSource("HttpClient_DisableServerCertificateValidation_TestCases")]
        public static void HttpWebRequest_WithServerCertificateValidationDisabled(HttpWebRequest request)
        {
            request = request.WithServerCertificateValidationDisabled();
            request.DownloadString();
        }

        [Test]
        [TestCaseSource("HttpClient_DisableServerCertificateValidation_TestCases")]
        public static void HttpClient_DisableServerCertificateValidation_true(HttpWebRequest request)
        {
            var client = new HttpClient();
            client.DisableServerCertificateValidation = true;
            client.DownloadString(request);
        }
#endif
    }
}
