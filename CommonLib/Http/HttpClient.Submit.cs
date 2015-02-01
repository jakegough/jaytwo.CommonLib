using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using jaytwo.Common.System;
using jaytwo.Common.Collections;


namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {
        public HttpWebResponse SubmitJson(string url, string method, NameValueCollection content)
        {
            var request = CreateRequest(url);
            return SubmitJson(request, method, content);
        }

        public HttpWebResponse SubmitJson(Uri uri, string method, NameValueCollection content)
        {
            var request = CreateRequest(uri);
            return SubmitJson(request, method, content);
        }

        public HttpWebResponse SubmitJson(string url, string method, NameValueCollection content, string contentType)
        {
            var request = CreateRequest(url);
            return SubmitJson(request, method, content, contentType);
        }

        public HttpWebResponse SubmitJson(Uri uri, string method, NameValueCollection content, string contentType)
        {
            var request = CreateRequest(uri);
            return SubmitJson(request, method, content, contentType);
        }

        public HttpWebResponse SubmitJson(HttpWebRequest request, string method, NameValueCollection content)
        {
            var contentDictionary = GetNameValueCollectionAsDictionaryOrNull(content);
            return SubmitJson(request, method, contentDictionary);
        }

        public HttpWebResponse SubmitJson(HttpWebRequest request, string method, NameValueCollection content, string contentType)
        {
            var contentDictionary = GetNameValueCollectionAsDictionaryOrNull(content);
            return SubmitJson(request, method, contentDictionary, contentType);
        }

        public HttpWebResponse SubmitJson(string url, string method, object content)
        {
            var request = CreateRequest(url);
            return SubmitJson(request, method, content);
        }

        public HttpWebResponse SubmitJson(Uri uri, string method, object content)
        {
            var request = CreateRequest(uri);
            return SubmitJson(request, method, content);
        }

        public HttpWebResponse SubmitJson(string url, string method, object content, string contentType)
        {
            var request = CreateRequest(url);
            return SubmitJson(request, method, content, contentType);
        }

        public HttpWebResponse SubmitJson(Uri uri, string method, object content, string contentType)
        {
            var request = CreateRequest(uri);
            return SubmitJson(request, method, content, contentType);
        }

        public HttpWebResponse SubmitJson(HttpWebRequest request, string method, object content)
        {
            var contentType = InternalHttpHelpers.GetContentTypeOrDefault(request, ContentType.application_json);
            return SubmitJson(request, method, content, contentType);
        }

        public HttpWebResponse SubmitJson(HttpWebRequest request, string method, object content, string contentType)
        {
            var contentString = GetJsonContentStringOrNull(content);
            var contentBytes = GetStringRequestContentBytesOrNull(contentString);
            return Submit(request, method, contentBytes, contentType);
        }

        public HttpWebResponse Submit(string url, string method)
        {
            var request = CreateRequest(url);
            return Submit(request, method);
        }

        public HttpWebResponse Submit(string url, string method, NameValueCollection content)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(string url, string method, string content)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(string url, string method, string content, string contentType)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(string url, string method, byte[] content)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(string url, string method, byte[] content, string contentType)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(Uri uri, string method)
        {
            var request = CreateRequest(uri);
            return Submit(request, method);
        }

        public HttpWebResponse Submit(Uri uri, string method, NameValueCollection content)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(Uri uri, string method, string content)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(Uri uri, string method, string content, string contentType)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(Uri uri, string method, byte[] content)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(Uri uri, string method, byte[] content, string contentType)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            byte[] content = null;
            return Submit(request, request.Method, content, request.ContentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            byte[] content = null;
            return Submit(request, method, content, request.ContentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method, NameValueCollection content)
        {
            var contentString = GetNameValueCollectionContentStringOrNull(content);
            var contentType = InternalHttpHelpers.GetContentTypeOrDefault(request, ContentType.application_x_www_form_urlencoded);
            return Submit(request, method, contentString, contentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method, string content)
        {
            var contentType = InternalHttpHelpers.GetContentTypeOrDefault(request, ContentType.text_plain);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method, string content, string contentType)
        {
            var contentBytes = GetStringRequestContentBytesOrNull(content);
            return Submit(request, method, contentBytes, contentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method, byte[] content)
        {
            var contentType = InternalHttpHelpers.GetContentTypeOrDefault(request, ContentType.application_octet_stream);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(string url, string method, Stream content)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(string url, string method, Stream content, string contentType)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(string url, string method, Stream content, long contentLength)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content, contentLength);
        }

        public HttpWebResponse Submit(string url, string method, Stream content, long contentLength, string contentType)
        {
            var request = CreateRequest(url);
            return Submit(request, method, content, contentLength, contentType);
        }

        public HttpWebResponse Submit(Uri uri, string method, Stream content)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content);
        }

        public HttpWebResponse Submit(Uri uri, string method, Stream content, string contentType)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content, contentType);
        }

        public HttpWebResponse Submit(Uri uri, string method, Stream content, long contentLength)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content, contentLength);
        }

        public HttpWebResponse Submit(Uri uri, string method, Stream content, long contentLength, string contentType)
        {
            var request = CreateRequest(uri);
            return Submit(request, method, content, contentLength, contentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method, Stream content)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var contentLength = InternalHttpHelpers.GetContentLength(request, content);
            return Submit(request, method, content, contentLength, request.ContentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method, Stream content, string contentType)
        {
            var contentLength = InternalHttpHelpers.GetContentLength(request, content);
            return Submit(request, method, content, contentLength, contentType);
        }

        public HttpWebResponse Submit(HttpWebRequest request, string method, Stream content, long contentLength)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            return Submit(request, method, content, contentLength, request.ContentType);
        }

        internal byte[] GetStringRequestContentBytesOrNull(string content)
        {
            if (content != null)
            {
                return RequestEncoding.GetBytes(content);
            }
            else
            {
                return null;
            }
        }

        internal string GetNameValueCollectionContentStringOrNull(NameValueCollection content)
        {
            if (content != null)
            {
				return CollectionUtility.ToPercentEncodedQueryString(content);
            }
            else
            {
                return null;
            }
        }

        internal IDictionary<string, string> GetNameValueCollectionAsDictionaryOrNull(NameValueCollection content)
        {
            if (content != null)
            {
                return CollectionUtility.ToDictionary(content);
            }
            else
            {
                return null;
            }
        }

        internal string GetJsonContentStringOrNull(object content)
        {
            if (content != null)
            {
                return SerializeToJson(content);
            }
            else
            {
                return null;
            }
        }
    }
}
