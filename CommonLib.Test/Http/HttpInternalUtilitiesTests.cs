using jaytwo.Common.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jaytwo.Common.Http;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using jaytwo.Common.IO;
using jaytwo.Common.Collections;

namespace jaytwo.Common.Test.Http
{
    [TestFixture]
    public static class InternalHttpHelpersTests
    {
        private static IEnumerable<TestCaseData> InternalHttpHelpers_IsHttpStatusSuccess_TestCases()
        {
            yield return new TestCaseData(HttpStatusCode.OK).Returns(true);
            yield return new TestCaseData(HttpStatusCode.PartialContent).Returns(true);
            yield return new TestCaseData(HttpStatusCode.MovedPermanently).Returns(false);
        }

        [Test]
        [TestCaseSource("InternalHttpHelpers_IsHttpStatusSuccess_TestCases")]
        public static bool InternalHttpHelpers_IsHttpStatusSuccess(HttpStatusCode statusCode)
        {
            return InternalHttpHelpers.IsHttpStatusSuccess(statusCode);
        }

        private static IEnumerable<TestCaseData> InternalHttpHelpers_GetContentTypeOrDefault_TestCases()
        {
            yield return new TestCaseData(WebRequest.Create("http://www.google.com") as HttpWebRequest, "foo/bar").Returns("foo/bar");

            var requestWithContentType = WebRequest.Create("http://www.google.com") as HttpWebRequest;
            requestWithContentType.ContentType = "radnom/other";
            yield return new TestCaseData(requestWithContentType, "not/thisone").Returns("radnom/other");
        }

        [Test]
        [TestCaseSource("InternalHttpHelpers_GetContentTypeOrDefault_TestCases")]
        public static string InternalHttpHelpers_GetContentTypeOrDefault(HttpWebRequest request, string defaultContentType)
        {
            return InternalHttpHelpers.GetContentTypeOrDefault(request, defaultContentType);
        }

        private static IEnumerable<TestCaseData> InternalHttpHelpers_GetContentLength_TestCases()
        {
            yield return new TestCaseData
                (
                    WebRequest.Create("http://www.google.com") as HttpWebRequest,
                    new MemoryStream(new byte[] { 1, 2, 3, 4, 5 })
                ).Returns(5);

            yield return new TestCaseData
                (
                    WebRequest.Create("http://www.google.com") as HttpWebRequest,
                    HttpHelper.GetContent(HttpProvider.SubmitGet("http://www.google.com"))
                ).Returns(-1);

            var foo = WebRequest.Create("http://www.google.com") as HttpWebRequest;
            foo.ContentLength = 102;

            yield return new TestCaseData
                (
                    foo,
                    HttpHelper.GetContent(HttpProvider.SubmitGet("http://www.google.com"))
                ).Returns(102);

            yield return new TestCaseData
                (
                    foo,
                    null
                ).Returns(102);
        }

        [Test]
        [TestCaseSource("InternalHttpHelpers_GetContentLength_TestCases")]
        public static long InternalHttpHelpers_GetContentLength(HttpWebRequest request, Stream content)
        {
            using (content)
            {
                return InternalHttpHelpers.GetContentLength(request, content);
            }
        }

        private static IEnumerable<TestCaseData> InternalHttpHelpers_GetRequestContentTypeWithCharset_TestCases()
        {
            yield return new TestCaseData("text/plain", Encoding.UTF8).Returns("text/plain; charset=utf-8");
            yield return new TestCaseData(null, Encoding.UTF8).Returns(null);
            yield return new TestCaseData("text/plain", null).Returns("text/plain");
            yield return new TestCaseData(null, null).Returns(null);
        }

        [Test]
        [TestCaseSource("InternalHttpHelpers_GetRequestContentTypeWithCharset_TestCases")]
        public static string InternalHttpHelpers_GetRequestContentTypeWithCharset(string contentType, Encoding encoding)
        {
            return InternalHttpHelpers.GetRequestContentTypeWithCharset(contentType, encoding);
        }

        private static IEnumerable<TestCaseData> InternalHttpHelpers_GetDownloadExceptionStringContent_TestCases()
        {
            var utf8text = "喜び (Joy)";
            var utf8Bytes = Encoding.UTF8.GetBytes(utf8text);
            yield return new TestCaseData(Encoding.ASCII, utf8Bytes).Returns("?????? (Joy)");
            yield return new TestCaseData(Encoding.UTF8, utf8Bytes).Returns(utf8text);

            //http://stackoverflow.com/questions/1301402/example-invalid-utf8-string
            var invalidUtf8bytes = new byte[] { 0xA0, 0xA1 }; //Invalid Sequence Identifier
            yield return new TestCaseData(Encoding.UTF8, invalidUtf8bytes).Returns("(2 bytes)");
        }

        [Test]
		public static void CollectionUtility_CreateDictionary()
        {
            var collection = new NameValueCollection()
			{
				{ "hello", "world"},
				{ "hello2", "world2"}
			};

            collection.Add("hello", "again");

            var dictionary = CollectionUtility.ToDictionary(collection);
            foreach (var key in collection.AllKeys)
            {
                var collectionValues = collection.GetValues(key);
                var dictionaryValue = dictionary[key];

				Assert.AreEqual(collectionValues[collectionValues.Length - 1], dictionaryValue);
            }
        }

		private static IEnumerable<TestCaseData> CollectionUtility_GetPercentEncodedQueryString_TestCases()
        {
            yield return new TestCaseData(new NameValueCollection() { { "captain", "jean-luc picard" }, { "first officer", "william t. riker" } }).Returns("captain=jean%2Dluc%20picard&first%20officer=william%20t.%20riker");
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
        }

        [Test]
		[TestCaseSource("CollectionUtility_GetPercentEncodedQueryString_TestCases")]
		public static string CollectionUtility_GetPercentEncodedQueryString(NameValueCollection value)
        {
            return CollectionUtility.ToPercentEncodedQueryString(value);
        }

        [Test]
		public static void StreamUtility_GetBytesFromStream()
        {
            var originalBytes = Encoding.UTF8.GetBytes("hello world");
            using (var stream = new MemoryStream(originalBytes))
            {
				var resultBytes = StreamUtility.GetBytesFromStream(stream);
                CollectionAssert.AreEqual(originalBytes, resultBytes);
            }
        }
    }
}
