using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;

namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {
        public HttpWebResponse SubmitPutJson(string url, object content)
        {
            return SubmitJson(url, HttpMethod.PUT, content);
        }
        public HttpWebResponse SubmitPutJson(Uri uri, object content)
        {
            return SubmitJson(uri, HttpMethod.PUT, content);
        }
        public HttpWebResponse SubmitPutJson(HttpWebRequest request, object content)
        {
            return SubmitJson(request, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPutJson(string url, NameValueCollection content)
        {
            return SubmitJson(url, HttpMethod.PUT, content);
        }
        public HttpWebResponse SubmitPutJson(Uri uri, NameValueCollection content)
        {
            return SubmitJson(uri, HttpMethod.PUT, content);
        }
        public HttpWebResponse SubmitPutJson(HttpWebRequest request, NameValueCollection content)
        {
            return SubmitJson(request, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(string url)
        {
            return Submit(url, HttpMethod.PUT);
        }

        public HttpWebResponse SubmitPut(string url, NameValueCollection content)
        {
            return Submit(url, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(string url, string content)
        {
            return Submit(url, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(string url, string content, string contentType)
        {
            return Submit(url, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(string url, byte[] content)
        {
            return Submit(url, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(string url, byte[] content, string contentType)
        {
            return Submit(url, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(Uri uri)
        {
            return Submit(uri, HttpMethod.PUT);
        }

        public HttpWebResponse SubmitPut(Uri uri, NameValueCollection content)
        {
            return Submit(uri, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(Uri uri, string content)
        {
            return Submit(uri, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(Uri uri, string content, string contentType)
        {
            return Submit(uri, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(Uri uri, byte[] content)
        {
            return Submit(uri, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(Uri uri, byte[] content, string contentType)
        {
            return Submit(uri, HttpMethod.PUT, content, contentType);
        }


        public HttpWebResponse SubmitPut(HttpWebRequest request)
        {
            return Submit(request, HttpMethod.PUT);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, NameValueCollection content)
        {
            return Submit(request, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, string content)
        {
            return Submit(request, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, string content, string contentType)
        {
            return Submit(request, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, byte[] content)
        {
            return Submit(request, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, byte[] content, string contentType)
        {
            return Submit(request, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(string url, Stream content)
        {
            return Submit(url, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(string url, Stream content, string contentType)
        {
            return Submit(url, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(string url, Stream content, long contentLength)
        {
            return Submit(url, HttpMethod.PUT, content, contentLength);
        }

        public HttpWebResponse SubmitPut(string url, Stream content, long contentLength, string contentType)
        {
            return Submit(url, HttpMethod.PUT, content, contentLength, contentType);
        }

        public HttpWebResponse SubmitPut(Uri uri, Stream content)
        {
            return Submit(uri, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(Uri uri, Stream content, string contentType)
        {
            return Submit(uri, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(Uri uri, Stream content, long contentLength)
        {
            return Submit(uri, HttpMethod.PUT, content, contentLength);
        }

        public HttpWebResponse SubmitPut(Uri uri, Stream content, long contentLength, string contentType)
        {
            return Submit(uri, HttpMethod.PUT, content, contentLength, contentType);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, Stream content)
        {
            return Submit(request, HttpMethod.PUT, content);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, Stream content, string contentType)
        {
            return Submit(request, HttpMethod.PUT, content, contentType);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, Stream content, long contentLength)
        {
            return Submit(request, HttpMethod.PUT, content, contentLength);
        }

        public HttpWebResponse SubmitPut(HttpWebRequest request, Stream content, long contentLength, string contentType)
        {
            return Submit(request, HttpMethod.PUT, content, contentLength, contentType);
        }

    }
}
