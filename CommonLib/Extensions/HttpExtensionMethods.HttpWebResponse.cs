#if GTENET35

using jaytwo.Common.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace jaytwo.Common.Extensions
{
	public static partial class UriExtensions
	{
		public static string GetFileName(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetFileName(httpWebResponse);
		}

		public static string GetEtag(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetEtag(httpWebResponse);
		}

		public static bool IsDeflate(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.IsDeflate(httpWebResponse);
		}

		public static bool IsGzip(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.IsGzip(httpWebResponse);
		}

		public static T VerifyResponseStatusOK<T>(this T httpWebResponse) where T : HttpWebResponse
		{
			HttpHelper.VerifyResponseStatusOK(httpWebResponse);
			return httpWebResponse;
		}

		public static T VerifyResponseStatusSuccess<T>(this T httpWebResponse) where T : HttpWebResponse
		{
			HttpHelper.VerifyResponseStatusSuccess(httpWebResponse);
			return httpWebResponse;
		}

		public static T VerifyResponseStatus<T>(this T httpWebResponse, HttpStatusCode statusCode) where T : HttpWebResponse
		{
			HttpHelper.VerifyResponseStatus(httpWebResponse, statusCode);
			return httpWebResponse;
		}

		public static T VerifyResponseStatus<T>(this T httpWebResponse, params HttpStatusCode[] statusCodes) where T : HttpWebResponse
		{
			HttpHelper.VerifyResponseStatus(httpWebResponse, statusCodes);
			return httpWebResponse;
		}

		public static Stream GetContent(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetContent(httpWebResponse);
		}

		public static Encoding GetEncoding(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetEncoding(httpWebResponse);
		}

		public static TextReader GetContentAsReader(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetContentAsReader(httpWebResponse);
		}

		public static TextReader GetContentAsReader(this HttpWebResponse httpWebResponse, Encoding encoding)
		{
			return HttpHelper.GetContentAsReader(httpWebResponse, encoding);
		}

		public static byte[] GetContentBytes(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetContentBytes(httpWebResponse);
		}

		public static string GetContentAsString(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetContentAsString(httpWebResponse);
		}

		public static string GetContentAsString(this HttpWebResponse httpWebResponse, Encoding encoding)
		{
			return HttpHelper.GetContentAsString(httpWebResponse, encoding);
		}

		public static Image GetContentAsImage(this HttpWebResponse httpWebResponse)
		{
			return HttpHelper.GetContentAsImage(httpWebResponse);
		}

		public static byte[] DownloadBytes(this HttpWebResponse httpWebResponse)
		{
			return HttpProvider.DownloadBytes(httpWebResponse);
		}

		public static Image DownloadImage(this HttpWebResponse httpWebResponse)
		{
			return HttpProvider.DownloadImage(httpWebResponse);
		}

		public static string DownloadString(this HttpWebResponse httpWebResponse)
		{
			return HttpProvider.DownloadString(httpWebResponse);
		}
	}
}

#endif