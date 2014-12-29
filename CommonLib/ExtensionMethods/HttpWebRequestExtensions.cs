using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Globalization;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class HttpWebRequestExtensions
	{
		public static T WithAcceptGzipHeader<T>(this T httpWebRequest) where T : HttpWebRequest
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");

			return httpWebRequest;
		}

		public static T WithBasicAuthentication<T>(this T httpWebRequest, string username, string password) where T : HttpWebRequest
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			string authString = string.Format(CultureInfo.InvariantCulture, "{0}:{1}", username, password);
			return httpWebRequest.WithBasicAuthentication(authString);
		}

		public static T WithBasicAuthentication<T>(this T httpWebRequest, string userInfo) where T : HttpWebRequest
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			string authBase64string = userInfo
				.ToByteArray(Encoding.UTF8)
				.ToBase64String();

			httpWebRequest.Headers["Authorization"] = string.Format(CultureInfo.InvariantCulture, "Basic {0}", authBase64string);

			return httpWebRequest;
		}

		public static T WithWindowsAuthentication<T>(this T httpWebRequest, string username, string password) where T : HttpWebRequest
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			httpWebRequest.Credentials = new NetworkCredential(username, password);
			return httpWebRequest;
		}

		public static T WithWindowsAuthentication<T>(this T httpWebRequest, string username, string password, string domain) where T : HttpWebRequest
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			httpWebRequest.Credentials = new NetworkCredential(username, password, domain);
			return httpWebRequest;
		}

		public static HttpWebRequest WithServerCertificateValidationDisabled(this HttpWebRequest httpWebRequest)
		{
			httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
			return httpWebRequest;
		}

		public static HttpWebResponse SubmitPost(this HttpWebRequest httpWebRequest, NameValueCollection form)
		{
			return SubmitPost(httpWebRequest, form, Encoding.UTF8);
		}

		public static HttpWebResponse SubmitPost(this HttpWebRequest httpWebRequest, NameValueCollection form, Encoding encoding)
		{
			if (form == null)
			{
				throw new ArgumentNullException("form");
			}

			var contentType = "application/x-www-form-urlencoded; charset=utf-8";
			var data = form.ToPercentEncodedQueryString();

			return SubmitPost(httpWebRequest, data, contentType, encoding);
		}

		public static HttpWebResponse SubmitPost(this HttpWebRequest httpWebRequest, string data)
		{
			string contentType = "text/plain; charset=utf-8";

			return SubmitPost(httpWebRequest, data, contentType, Encoding.UTF8);
		}

		public static HttpWebResponse SubmitPost(this HttpWebRequest httpWebRequest, string data, string contentType)
		{
			return SubmitPost(httpWebRequest, data, contentType, Encoding.UTF8);
		}

		public static HttpWebResponse SubmitPost(this HttpWebRequest httpWebRequest, string data, string contentType, Encoding encoding)
		{			
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}

			byte[] byteData = (data != null)
				? data.ToByteArray(encoding)
				: new byte[] { };

			return SubmitPost(httpWebRequest, byteData, contentType);
		}

		public static HttpWebResponse SubmitPost(this HttpWebRequest httpWebRequest, byte[] data)
		{
			string contentType = "text/plain; charset=utf-8";

			return SubmitPost(httpWebRequest, data, contentType);
		}

		public static HttpWebResponse SubmitPost(this HttpWebRequest httpWebRequest, byte[] data, string contentType)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			if (data == null)
			{
				throw new ArgumentNullException("data");
			}

			httpWebRequest.ContentType = contentType;

			return httpWebRequest.Submit("POST", data);
		}

		public static HttpWebResponse SubmitGet(this HttpWebRequest httpWebRequest)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			return httpWebRequest.Submit("GET");
		}

		public static HttpWebResponse SubmitHead(this HttpWebRequest httpWebRequest)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			return httpWebRequest.Submit("HEAD");
		}

		public static HttpWebResponse Submit(this HttpWebRequest httpWebRequest, string method, byte[] data)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			if (string.IsNullOrWhiteSpace(method))
			{
				throw new ArgumentNullException("method");
			}

			if (data == null)
			{
				throw new ArgumentNullException("data");
			}

			using (var streamData = new MemoryStream(data))
			{
				return httpWebRequest.Submit(method, streamData, data.LongLength);
			}
		}

		public static HttpWebResponse Submit(this HttpWebRequest httpWebRequest, string method, Stream data, long contentLength)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			if (string.IsNullOrWhiteSpace(method))
			{
				throw new ArgumentNullException("method");
			}

			if (data == null)
			{
				throw new ArgumentNullException("data");
			}

			var requestStreamAction = new Action<Stream>(requestStream =>
			{
				using (requestStream)
				{
					data.CopyTo(requestStream);
				}
			});

			httpWebRequest.ContentLength = contentLength;

			return httpWebRequest.Submit(method, requestStreamAction);
		}

		public static HttpWebResponse Submit(this HttpWebRequest httpWebRequest, string method)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			if (string.IsNullOrWhiteSpace(method))
			{
				throw new ArgumentNullException("method");
			}

			Action<Stream> requestStreamAction = null;
			return httpWebRequest.Submit(method, requestStreamAction);
		}

		public static HttpWebResponse Submit(this HttpWebRequest httpWebRequest, string method, Action<Stream> requestStreamAction)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			if (string.IsNullOrWhiteSpace(method))
			{
				throw new ArgumentNullException("method");
			}

			httpWebRequest.Method = method;

			if (requestStreamAction != null)
			{
				requestStreamAction.Invoke(httpWebRequest.GetRequestStream());
			}

			return httpWebRequest.Submit();
		}

		public static HttpWebResponse Submit(this HttpWebRequest httpWebRequest)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			HttpWebResponse httpWebResponse;

			try
			{
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			}
			catch (WebException webException)
			{
				if (webException.Response != null)
				{
					httpWebResponse = (HttpWebResponse)webException.Response;
				}
				else
				{
					throw;
				}
			}

			return httpWebResponse;
		}
	}
}
