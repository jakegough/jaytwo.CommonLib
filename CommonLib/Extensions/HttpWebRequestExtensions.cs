using jaytwo.Common.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace jaytwo.Common.Extensions
{
	public static partial class HttpWebRequestExtensions
    {
        public static T WithAcceptGzipDeflateHeader<T>(this T httpWebRequest) where T : HttpWebRequest
        {
            return WithHeader(httpWebRequest, HttpRequestHeader.AcceptEncoding, "gzip,deflate");
        }

        public static T WithBasicAuthentication<T>(this T httpWebRequest, string userName, string password) where T : HttpWebRequest
        {
			HttpHelper.SetBasicAuthenticationHeader(httpWebRequest, userName, password);
			return httpWebRequest;
        }

        public static T WithCredentials<T>(this T httpWebRequest, ICredentials credentials) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.Credentials = credentials;
            return httpWebRequest;
        }

        public static T WithCredentials<T>(this T httpWebRequest, string userName, string password) where T : HttpWebRequest
        {
            return WithCredentials(httpWebRequest, new NetworkCredential(userName, password));
        }

        public static T WithCredentials<T>(this T httpWebRequest, string userName, string password, string domain) where T : HttpWebRequest
        {
            return WithCredentials(httpWebRequest, new NetworkCredential(userName, password, domain));
        }

        public static T WithContentLength<T>(this T httpWebRequest, long contentLength) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.ContentLength = contentLength;
            return httpWebRequest;
        }

        public static T WithContentType<T>(this T httpWebRequest, string contentType) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.ContentType = contentType;
            return httpWebRequest;
        }

        public static T WithCookieContainer<T>(this T httpWebRequest, CookieContainer cookieContainer) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.CookieContainer = cookieContainer;
            return httpWebRequest;
        }

        public static T WithMethod<T>(this T httpWebRequest, string method) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.Method = method;
            return httpWebRequest;
        }

        public static T WithProxy<T>(this T httpWebRequest, IWebProxy proxy) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.Proxy = proxy;
            return httpWebRequest;
        }

		public static T WithProxy<T>(this T httpWebRequest, string address) where T : HttpWebRequest
		{
			var proxy = new WebProxy(address);
			return WithProxy(httpWebRequest, proxy);
		}

        public static T WithUserAgent<T>(this T httpWebRequest, string userAgent) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.UserAgent = userAgent;
            return httpWebRequest;
        }

        public static T WithHeader<T>(this T httpWebRequest, string header, string value) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.Headers[header] = value;
            return httpWebRequest;
        }

        public static T WithHeader<T>(this T httpWebRequest, HttpRequestHeader header, string value) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.Headers[header] = value;
            return httpWebRequest;
        }

#if GTENET45
        public static T WithServerCertificateValidationDisabled<T>(this T httpWebRequest) where T : HttpWebRequest
        {
            if (httpWebRequest == null)
            {
                throw new ArgumentNullException("httpWebRequest");
            }

            httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            return httpWebRequest;
        }
#endif
    }
}