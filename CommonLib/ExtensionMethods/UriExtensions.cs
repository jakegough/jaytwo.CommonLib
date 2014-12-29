using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Collections.Specialized;
using jaytwo.CommonLib.Web;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class UriExtensions
	{
		public static Uri AddQueryStringParameter(this Uri uri, string key, string value)
		{
			return UrlUtility.AddUriQueryStringParameter(uri, key, value);
		}

		public static Uri AddQueryStringParameter<T>(this Uri uri, string key, T value)
		{
			return UrlUtility.AddUriQueryStringParameter<T>(uri, key, value);
		}

		public static Uri AddQueryStringParameter(this Uri uri, string key, object value)
		{
			return UrlUtility.AddUriQueryStringParameter(uri, key, value);
		}

		public static Uri CombineWith(this Uri uri, string path)
		{
			return UrlUtility.Combine(uri, path);
		}

		public static Uri CombineWith(this Uri uri, params string[] pathSegments)
		{
			return UrlUtility.Combine(uri, pathSegments);
		}

		public static Uri CombineWith(this Uri uri, Uri pathUri)
		{
			return UrlUtility.Combine(uri, pathUri);
		}

		public static Uri Copy(this Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}

			if (uri.IsAbsoluteUri)
			{
				return new Uri(uri.AbsoluteUri, UriKind.Absolute);
			}
			else
			{
				return new Uri(uri.ToString(), UriKind.Relative);
			}
		}

		public static WebRequest CreateWebRequest(this Uri uri)
		{
			return WebRequest.Create(uri);
		}

		public static HttpWebRequest CreateHttpWebRequest(this Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}

			var result = uri.CreateWebRequest() as HttpWebRequest;

			if (!string.IsNullOrEmpty(uri.UserInfo))
			{
				result.WithBasicAuthentication(uri.UserInfo);
			}

			return result;
		}

		public static string GetFileNameAndQuery(this Uri uri)
		{
			return UrlUtility.GetFileNameAndQuery(uri);
		}

		public static string GetFileNameWithoutQuery(this Uri uri)
		{
			return UrlUtility.GetFileNameWithoutQuery(uri);
		}

		public static string GetQuery(this Uri uri)
		{
			return UrlUtility.GetQueryFromUri(uri);
		}

		public static NameValueCollection GetQueryAsNameValueCollection(this Uri uri)
		{
			return UrlUtility.GetQueryFromUriAsNameValueCollection(uri);
		}

		public static string GetQueryStringParameter(this Uri uri, string key)
		{
			return UrlUtility.GetQueryStringParameterFromUri(uri, key);
		}

		public static HttpWebResponse HttpGet(this Uri uri)
		{
			return uri.CreateHttpWebRequest().SubmitGet();
		}

		public static HttpWebResponse HttpHead(this Uri uri)
		{
			return uri.CreateHttpWebRequest().SubmitHead();
		}

		public static Uri RemoveQueryStringParameter(this Uri uri, string key)
		{
			return UrlUtility.RemoveUriQueryStringParameter(uri, key);
		}

		public static Uri SetHost(this Uri uri, string newHost)
		{
			return UrlUtility.SetUriHost(uri, newHost);
		}

		public static Uri SetHost(this Uri uri, string newHost, int? newPort)
		{
			return UrlUtility.SetUriHost(uri, newHost, newPort);
		}

		public static Uri SetPort(this Uri uri, int? newPort)
		{
			return UrlUtility.SetUriPort(uri, newPort);
		}

		public static Uri SetPortHttp(this Uri uri)
		{
			return UrlUtility.SetUriPortHttp(uri);
		}

		public static Uri SetPortHttps(this Uri uri)
		{
			return UrlUtility.SetUriPortHttps(uri);
		}

		public static Uri SetPortDefault(this Uri uri)
		{
			return UrlUtility.SetUriPortDefault(uri);
		}

		public static Uri SetQuery(this Uri uri, NameValueCollection queryStringData)
		{
			return UrlUtility.SetUriQuery(uri, queryStringData);
		}

		public static Uri SetQueryStringParameter<T>(this Uri uri, string key, T value)
		{
			return UrlUtility.SetUriQueryStringParameter<T>(uri, key, value);
		}

		public static Uri SetQueryStringParameter(this Uri uri, string key, object value)
		{
			return UrlUtility.SetUriQueryStringParameter(uri, key, value);
		}

		public static Uri SetQueryStringParameter(this Uri uri, string key, string value)
		{
			return UrlUtility.SetUriQueryStringParameter(uri, key, value);
		}

		public static Uri SetScheme(this Uri uri, string newScheme)
		{
			return UrlUtility.SetUriScheme(uri, newScheme);
		}

		public static Uri SetSchemeHttp(this Uri uri)
		{
			return UrlUtility.SetUriSchemeHttp(uri);
		}

		public static Uri SetSchemeHttps(this Uri uri)
		{
			return UrlUtility.SetUriSchemeHttps(uri);
		}

		public static Uri WithoutFileNameAndQuery(this Uri uri)
		{
			return UrlUtility.GetUriWithoutFileNameAndQuery(uri);
		}

		public static Uri WithoutQuery(this Uri uri)
		{
			return UrlUtility.GetUriWithoutQuery(uri);
		}		
	}
}
