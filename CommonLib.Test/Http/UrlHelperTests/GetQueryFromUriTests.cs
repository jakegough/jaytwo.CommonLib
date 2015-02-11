using jaytwo.Common.Extensions;
using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Http.UrlHelperTests
{
	public static class GetQueryFromUriTests
    {
		private static IEnumerable<TestCaseData> UrlHelper_GetQuery_TestCases()
		{
			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
			yield return new TestCaseData("http://www.google.com/resource").Returns("");
			yield return new TestCaseData("http://www.google.com/resource?").Returns("");
			yield return new TestCaseData("http://www.google.com/resource?hello=world").Returns("hello=world");
			yield return new TestCaseData("http://www.google.com/resource?hello=world&hello=john").Returns("hello=world&hello=john");
			yield return new TestCaseData("../relative/path").Returns("");
			yield return new TestCaseData("../relative/path?").Returns("");
			yield return new TestCaseData("../relative/path?hello=world").Returns("hello=world");
		}

		[Test]
		[TestCaseSource("UrlHelper_GetQuery_TestCases")]
		public static string UrlHelper_GetQueryFromUri(string url)
		{
			var uri = TestUtility.GetUriFromString(url);
			return UrlHelper.GetQueryFromUri(uri);
		}

		[Test]
		[TestCaseSource("UrlHelper_GetQuery_TestCases")]
		public static string UrlHelper_GetQueryFromPathOrUrl(string url)
		{
			return UrlHelper.GetQueryFromPathOrUrl(url);
		}

		[Test]
		[TestCaseSource("UrlHelper_GetQuery_TestCases")]
		public static string HttpExtensionMethods_GetQuery_uri(string url)
		{
			var uri = TestUtility.GetUriFromString(url);
			return uri.GetQuery();
		}

		[Test]
		[TestCaseSource("UrlHelper_GetQuery_TestCases")]
		public static string UrlHelper_GetQueryFromUriAsNameValueCollection(string url)
		{
			var uri = TestUtility.GetUriFromString(url);
			return UrlHelper.GetQueryFromUriAsNameValueCollection(uri).ToPercentEncodedQueryString();
		}

		[Test]
		[TestCaseSource("UrlHelper_GetQuery_TestCases")]
		public static string UrlHelper_GetQueryFromPathOrUrlAsNameValueCollection(string url)
		{
			return UrlHelper.GetQueryFromPathOrUrlAsNameValueCollection(url).ToPercentEncodedQueryString();
		}

		[Test]
		[TestCaseSource("UrlHelper_GetQuery_TestCases")]
		public static string HttpExtensionMethods_GetQueryAsNameValueCollection(string url)
		{
			var uri = TestUtility.GetUriFromString(url);
			return uri.GetQueryAsNameValueCollection().ToPercentEncodedQueryString();
		}

    }
}
