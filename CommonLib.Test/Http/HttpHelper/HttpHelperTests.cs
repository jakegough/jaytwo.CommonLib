using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.IO;

namespace jaytwo.Common.Test.Http
{
    [TestFixture]
    public static class HttpHelperTests
    {
        private static IEnumerable<TestCaseData> HttpHelper_GetFileName_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/response-headers?Content-Disposition=attachment%3B%20filename%3D%22fname.ext%22").Returns("fname.ext");
            yield return new TestCaseData("http://httpbin.org/get").Returns("get");
        }

        [Test]
        [TestCaseSource("HttpHelper_GetFileName_TestCases")]
        public static string HttpHelper_GetFileName(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return HttpHelper.GetFileName(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetFileName_TestCases")]
        public static string HttpExtensionMethods_HttpWebResponse_GetFileName(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return response.GetFileName();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_GetEtag_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/response-headers?ETag=foo").Returns("foo");
        }

        [Test]
        [TestCaseSource("HttpHelper_GetEtag_TestCases")]
        public static string HttpHelper_GetEtag(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return HttpHelper.GetEtag(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetEtag_TestCases")]
        public static string HttpExtensionMethods_HttpWebResponse_GetEtag(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return response.GetEtag();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_IsDeflate_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/deflate").Returns(true);
            yield return new TestCaseData("http://httpbin.org/get").Returns(false);
        }

        [Test]
        [TestCaseSource("HttpHelper_IsDeflate_TestCases")]
        public static bool HttpHelper_IsDeflate(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return HttpHelper.IsDeflate(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_IsDeflate_TestCases")]
        public static bool HttpExtensionMethods_HttpWebResponse_IsDeflate(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return response.IsDeflate();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_IsGzip_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/gzip").Returns(true);
            yield return new TestCaseData("http://httpbin.org/get").Returns(false);
        }

        [Test]
        [TestCaseSource("HttpHelper_IsGzip_TestCases")]
        public static bool HttpHelper_IsGzip(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return HttpHelper.IsGzip(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_IsGzip_TestCases")]
        public static bool HttpExtensionMethods_HttpWebResponse_IsGzip(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return response.IsGzip();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_VerifyResponseStatusSuccess_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/get");
            yield return new TestCaseData("http://httpbin.org/status/205");
            yield return new TestCaseData("http://httpbin.org/status/404").Throws(typeof(UnexpectedStatusCodeException));
            yield return new TestCaseData("http://httpbin.org/status/500").Throws(typeof(UnexpectedStatusCodeException));
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatusSuccess_TestCases")]
        public static void HttpHelper_VerifyResponseStatusSuccess(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                HttpHelper.VerifyResponseStatusSuccess(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatusSuccess_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_VerifyResponseStatusSuccess(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.VerifyResponseStatusSuccess();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_throws_DownloadException_TestCases()
        {
            yield return new TestCaseData("http://httpbin.org/get");
            yield return new TestCaseData("http://httpbin.org/status/404").Throws(typeof(DownloadException));
            yield return new TestCaseData("http://httpbin.org/status/500").Throws(typeof(DownloadException));
        }

        [Test]
        [TestCaseSource("HttpHelper_throws_DownloadException_TestCases")]
        public static void HttpHelper_DownloadString_throws_DownloadException(string url)
        {
            var result = HttpProvider.DownloadString(url);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCaseSource("HttpHelper_throws_DownloadException_TestCases")]
        public static void HttpHelper_DownloadBytes_throws_DownloadException(string url)
        {
            var result = HttpProvider.DownloadBytes(url);
            Assert.IsNotNull(result);
        }

        private static IEnumerable<TestCaseData> HttpHelper_VerifyResponseStatusOK_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/get");
            yield return new TestCaseData("http://httpbin.org/status/205").Throws(typeof(UnexpectedStatusCodeException));
            yield return new TestCaseData("http://httpbin.org/status/404").Throws(typeof(UnexpectedStatusCodeException));
            yield return new TestCaseData("http://httpbin.org/status/500").Throws(typeof(UnexpectedStatusCodeException));
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatusOK_TestCases")]
        public static void HttpHelper_VerifyResponseStatusOK(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                HttpHelper.VerifyResponseStatusOK(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatusOK_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_VerifyResponseStatusOK(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.VerifyResponseStatusOK();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_VerifyResponseStatus_TestCases()
        {
            yield return new TestCaseData(null, HttpStatusCode.OK).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/status/404", HttpStatusCode.NotFound);
            yield return new TestCaseData("http://httpbin.org/get", HttpStatusCode.NotFound).Throws(typeof(UnexpectedStatusCodeException));
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatus_TestCases")]
        public static void HttpHelper_VerifyResponseStatus_array(string url, HttpStatusCode statusCode)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                HttpHelper.VerifyResponseStatus(response, new[] { statusCode });
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatus_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_VerifyResponseStatus_array(string url, HttpStatusCode statusCode)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.VerifyResponseStatus(new[] { statusCode });
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatus_TestCases")]
        public static void HttpHelper_VerifyResponseStatus(string url, HttpStatusCode statusCode)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                HttpHelper.VerifyResponseStatus(response, statusCode);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_VerifyResponseStatus_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_VerifyResponseStatus(string url, HttpStatusCode statusCode)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.VerifyResponseStatus(statusCode);
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_GetContent_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/bytes/100");
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContent_TestCases")]
        public static void HttpHelper_GetContent(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var content = HttpHelper.GetContent(response))
            {
                var bytes = StreamUtility.GetBytesFromStream(content);
                Assert.AreEqual(response.ContentLength, bytes.Length);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContent_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_GetContent(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var content = response.GetContent())
            {
				var bytes = StreamUtility.GetBytesFromStream(content);
                Assert.AreEqual(response.ContentLength, bytes.Length);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContent_TestCases")]
        public static void HttpHelper_GetContentBytes(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                HttpHelper.GetContentBytes(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContent_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_GetContentBytes(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.GetContentBytes();
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContent_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_DownloadBytes(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.DownloadBytes();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_GetContentAsImage_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/image/png");
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsImage_TestCases")]
        public static void HttpHelper_GetContentAsImage(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var image = HttpHelper.GetContentAsImage(response))
            {
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsImage_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_GetContentAsImage(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var image = response.GetContentAsImage())
            {
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsImage_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_DownloadImage(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var image = response.DownloadImage())
            {
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_GetContentAsReader_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/encoding/utf8");
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsReader_TestCases")]
        public static void HttpHelper_GetContentAsReader(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var reader = HttpHelper.GetContentAsReader(response))
            {
                reader.ReadToEnd();
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsReader_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_GetContentAsReader(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var reader = response.GetContentAsReader())
            {
                reader.ReadToEnd();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_GetContentAsReader_with_encoding_TestCases()
        {
            yield return new TestCaseData(null, Encoding.UTF8).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/encoding/utf8", null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/encoding/utf8", Encoding.UTF8);
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsReader_with_encoding_TestCases")]
        public static void HttpHelper_GetContentAsReader_with_encoding(string url, Encoding encoding)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var reader = HttpHelper.GetContentAsReader(response, encoding))
            {
                reader.ReadToEnd();
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsReader_with_encoding_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_GetContentAsReader_with_encoding(string url, Encoding encoding)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            using (var reader = response.GetContentAsReader(encoding))
            {
                reader.ReadToEnd();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_Encoding_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/get").Returns(null);
            yield return new TestCaseData("http://httpbin.org/encoding/utf8").Returns(Encoding.UTF8);
        }

        [Test]
        [TestCaseSource("HttpHelper_Encoding_TestCases")]
        public static Encoding HttpHelper_Encoding(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return HttpHelper.GetEncoding(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_Encoding_TestCases")]
        public static Encoding HttpExtensionMethods_HttpWebResponse_GetEncoding(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                return response.GetEncoding();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_GetContentAsString_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/encoding/utf8");
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsString_TestCases")]
        public static void HttpHelper_GetContentAsString(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                HttpHelper.GetContentAsString(response);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsString_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_GetContentAsString(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.GetContentAsString();
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsString_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_DownloadString(string url)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.DownloadString();
            }
        }

        private static IEnumerable<TestCaseData> HttpHelper_GetContentAsString_with_encoding_TestCases()
        {
            yield return new TestCaseData(null, Encoding.UTF8).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("http://httpbin.org/encoding/utf8", Encoding.UTF8);
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsString_with_encoding_TestCases")]
        public static void HttpHelper_GetContentAsString_with_encoding(string url, Encoding encoding)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                HttpHelper.GetContentAsString(response, encoding);
            }
        }

        [Test]
        [TestCaseSource("HttpHelper_GetContentAsString_with_encoding_TestCases")]
        public static void HttpExtensionMethods_HttpWebResponse_GetContentAsString_with_encoding(string url, Encoding encoding)
        {
            using (var response = TestUtility.GetResponseFromUrl(url))
            {
                response.GetContentAsString(encoding);
            }
        }
    }
}
