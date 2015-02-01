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
        public HttpWebResponse SubmitPostJson(string url, object content)
        {
            return SubmitJson(url, HttpMethod.POST, content);
        }
        public HttpWebResponse SubmitPostJson(Uri uri, object content)
        {
            return SubmitJson(uri, HttpMethod.POST, content);
        }
        public HttpWebResponse SubmitPostJson(HttpWebRequest request, object content)
        {
            return SubmitJson(request, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPostJson(string url, NameValueCollection content)
        {
            return SubmitJson(url, HttpMethod.POST, content);
        }
        public HttpWebResponse SubmitPostJson(Uri uri, NameValueCollection content)
        {
            return SubmitJson(uri, HttpMethod.POST, content);
        }
        public HttpWebResponse SubmitPostJson(HttpWebRequest request, NameValueCollection content)
        {
            return SubmitJson(request, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(string url)
        {
            return Submit(url, HttpMethod.POST);
        }

        public HttpWebResponse SubmitPost(string url, NameValueCollection content)
        {
            return Submit(url, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(string url, string content)
        {
            return Submit(url, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(string url, string content, string contentType)
        {
            return Submit(url, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(string url, byte[] content)
        {
            return Submit(url, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(string url, byte[] content, string contentType)
        {
            return Submit(url, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(Uri uri)
        {
            return Submit(uri, HttpMethod.POST);
        }

        public HttpWebResponse SubmitPost(Uri uri, NameValueCollection content)
        {
            return Submit(uri, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(Uri uri, string content)
        {
            return Submit(uri, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(Uri uri, string content, string contentType)
        {
            return Submit(uri, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(Uri uri, byte[] content)
        {
            return Submit(uri, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(Uri uri, byte[] content, string contentType)
        {
            return Submit(uri, HttpMethod.POST, content, contentType);
        }


        public HttpWebResponse SubmitPost(HttpWebRequest request)
        {
            return Submit(request, HttpMethod.POST);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, NameValueCollection content)
        {
            return Submit(request, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, string content)
        {
            return Submit(request, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, string content, string contentType)
        {
            return Submit(request, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, byte[] content)
        {
            return Submit(request, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, byte[] content, string contentType)
        {
            return Submit(request, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(string url, Stream content)
        {
            return Submit(url, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(string url, Stream content, string contentType)
        {
            return Submit(url, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(string url, Stream content, long contentLength)
        {
            return Submit(url, HttpMethod.POST, content, contentLength);
        }

        public HttpWebResponse SubmitPost(string url, Stream content, long contentLength, string contentType)
        {
            return Submit(url, HttpMethod.POST, content, contentLength, contentType);
        }

        public HttpWebResponse SubmitPost(Uri uri, Stream content)
        {
            return Submit(uri, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(Uri uri, Stream content, string contentType)
        {
            return Submit(uri, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(Uri uri, Stream content, long contentLength)
        {
            return Submit(uri, HttpMethod.POST, content, contentLength);
        }

        public HttpWebResponse SubmitPost(Uri uri, Stream content, long contentLength, string contentType)
        {
            return Submit(uri, HttpMethod.POST, content, contentLength, contentType);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, Stream content)
        {
            return Submit(request, HttpMethod.POST, content);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, Stream content, string contentType)
        {
            return Submit(request, HttpMethod.POST, content, contentType);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, Stream content, long contentLength)
        {
            return Submit(request, HttpMethod.POST, content, contentLength);
        }

        public HttpWebResponse SubmitPost(HttpWebRequest request, Stream content, long contentLength, string contentType)
        {
            return Submit(request, HttpMethod.POST, content, contentLength, contentType);
        }
    }
}
