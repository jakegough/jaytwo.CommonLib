using jaytwo.Common.Extensions;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using System.Drawing;
using jaytwo.Common.System;
using jaytwo.Common.IO;

namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {
		public static readonly int DefaultMaximumDownloadContentLength = 32 * 1024 * 1024;

        private static class ContentType
        {
            public const string application_x_www_form_urlencoded = "application/x-www-form-urlencoded";
            public const string application_octet_stream = "application/octet-stream";
            public const string application_json = "application/json";
            public const string text_plain = "text/plain";
        }

        private static class HttpMethod
        {
            public const string HEAD = "HEAD";
            public const string GET = "GET";
            public const string PUT = "PUT";
            public const string POST = "POST";
            public const string DELETE = "DELETE";
        }

        public Encoding RequestEncoding { get; set; }
        public IWebProxy Proxy { get; set; }
        public string UserAgent { get; set; }
        public CookieContainer CookieContainer { get; set; }
#if GTENET45
        public bool DisableServerCertificateValidation { get; set; }
#endif
        public long MaximumDownloadContentLength { get; set; }

        public HttpClient()
        {
            RequestEncoding = Encoding.UTF8;
			MaximumDownloadContentLength = DefaultMaximumDownloadContentLength;
        }

        public virtual HttpWebRequest CreateRequest(string url)
        {
            var uri = new Uri(url);
            return CreateRequest(uri);
        }

        public virtual HttpWebRequest CreateRequest(Uri uri)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(uri);

            return request;
        }

        protected virtual string SerializeToJson(object content)
        {
            return new JavaScriptSerializer().Serialize(content);
        }

        public virtual HttpWebResponse Submit(HttpWebRequest request, string method, Stream content, long contentLength, string contentType)
        {
            ValidateAndPrepareRequest(request, method, contentType);

            request.ContentLength = contentLength;

            if (content != null)
            {
                using (var requestStream = request.GetRequestStream())
                {
					StreamUtility.CopyStreamToStream(content, requestStream);
                }
            }

            return GetResponse(request);
        }

        public virtual HttpWebResponse Submit(HttpWebRequest request, string method, byte[] content, string contentType)
        {
            ValidateAndPrepareRequest(request, method, contentType);

            request.ContentLength = (content != null) ? content.Length : 0;

            if (content != null)
            {
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(content, 0, content.Length);
                }
            }

            return GetResponse(request);
        }


        private void ValidateAndPrepareRequest(HttpWebRequest request, string method, string contentType)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
            else if (string.IsNullOrEmpty(method))
            {
                throw new ArgumentException("method must have a value");
            }

            request.Proxy = Proxy;
            request.UserAgent = UserAgent;
            request.CookieContainer = CookieContainer;

#if GTENET45
            if (DisableServerCertificateValidation)
            {
                request.WithServerCertificateValidationDisabled();
            }
#endif

            request.Method = method;
            request.ContentType = InternalHttpHelpers.GetRequestContentTypeWithCharset(contentType, RequestEncoding);
        }

        private static HttpWebResponse GetResponse(HttpWebRequest request)
        {
            HttpWebResponse result;

            try
            {
                result = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    result = (HttpWebResponse)webException.Response;
                }
                else
                {
                    throw;
                }
            }

            return result;
        }
    }
}
