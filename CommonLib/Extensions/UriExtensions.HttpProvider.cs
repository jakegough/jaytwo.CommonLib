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
    public static partial class UriExtensions
    {
        public static HttpWebRequest CreateHttpWebRequest(this Uri uri)
        {
            return HttpProvider.CreateRequest(uri);
        }

        public static string Delete(this Uri uri)
        {
            return HttpProvider.Delete(uri);
        }

        public static byte[] DownloadBytes(this Uri uri)
        {
            return HttpProvider.DownloadBytes(uri);
        }

        public static Image DownloadImage(this Uri uri)
        {
            return HttpProvider.DownloadImage(uri);
        }

        public static string DownloadString(this Uri uri)
        {
            return HttpProvider.DownloadString(uri);
        }

        public static string Post(this Uri uri, string content)
        {
            return HttpProvider.Post(uri, content);
        }

        public static string Post(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.Post(uri, content);
        }

        public static string Post(this Uri uri, byte[] content)
        {
            return HttpProvider.Post(uri, content);
        }

        public static string Post(this Uri uri, Stream content)
        {
            return HttpProvider.Post(uri, content);
        }

        public static string PostJson(this Uri uri, object content)
        {
            return HttpProvider.PostJson(uri, content);
        }

        public static string PostJson(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.PostJson(uri, content);
        }

        public static string Put(this Uri uri, string content)
        {
            return HttpProvider.Put(uri, content);
        }

        public static string Put(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.Put(uri, content);
        }

        public static string Put(this Uri uri, byte[] content)
        {
            return HttpProvider.Put(uri, content);
        }

        public static string Put(this Uri uri, Stream content)
        {
            return HttpProvider.Put(uri, content);
        }

        public static string PutJson(this Uri uri, object content)
        {
            return HttpProvider.PutJson(uri, content);
        }

        public static string PutJson(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.PutJson(uri, content);
        }

        public static HttpWebResponse SubmitPostJson(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.SubmitPostJson(uri, content);
        }

        public static HttpWebResponse SubmitPostJson(this Uri uri, object content)
        {
            return HttpProvider.SubmitPostJson(uri, content);
        }

        public static HttpWebResponse SubmitPutJson(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.SubmitPutJson(uri, content);
        }

        public static HttpWebResponse SubmitPutJson(this Uri uri, object content)
        {
            return HttpProvider.SubmitPutJson(uri, content);
        }

        public static HttpWebResponse SubmitJson(this Uri uri, string method, NameValueCollection content)
        {
            return HttpProvider.SubmitJson(uri, method, content);
        }

        public static HttpWebResponse SubmitJson(this Uri uri, string method, NameValueCollection content, string contentType)
        {
            return HttpProvider.SubmitJson(uri, method, content, contentType);
        }

        public static HttpWebResponse SubmitJson(this Uri uri, string method, object content)
        {
            return HttpProvider.SubmitJson(uri, method, content);
        }

        public static HttpWebResponse SubmitJson(this Uri uri, string method, object content, string contentType)
        {
            return HttpProvider.SubmitJson(uri, method, content, contentType);
        }

        public static HttpWebResponse SubmitGet(this Uri uri)
        {
            return HttpProvider.SubmitGet(uri);
        }

        public static HttpWebResponse SubmitHead(this Uri uri)
        {
            return HttpProvider.SubmitHead(uri);
        }

        public static HttpWebResponse SubmitDelete(this Uri uri)
        {
            return HttpProvider.SubmitDelete(uri);
        }

        public static HttpWebResponse SubmitPost(this Uri uri)
        {
            return HttpProvider.SubmitPost(uri);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, string content)
        {
            return HttpProvider.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, string content, string contentType)
        {
            return HttpProvider.SubmitPost(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, byte[] content)
        {
            return HttpProvider.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, byte[] content, string contentType)
        {
            return HttpProvider.SubmitPost(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPut(this Uri uri)
        {
            return HttpProvider.SubmitPut(uri);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, NameValueCollection content)
        {
            return HttpProvider.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, string content)
        {
            return HttpProvider.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, string content, string contentType)
        {
            return HttpProvider.SubmitPut(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, byte[] content)
        {
            return HttpProvider.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, byte[] content, string contentType)
        {
            return HttpProvider.SubmitPut(uri, content, contentType);
        }

        public static HttpWebResponse Submit(this Uri uri, string method)
        {
            return HttpProvider.Submit(uri, method);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, NameValueCollection content)
        {
            return HttpProvider.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, string content)
        {
            return HttpProvider.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, string content, string contentType)
        {
            return HttpProvider.Submit(uri, method, content, contentType);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, byte[] content)
        {
            return HttpProvider.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, byte[] content, string contentType)
        {
            return HttpProvider.Submit(uri, method, content, contentType);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, Stream content)
        {
            return HttpProvider.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, Stream content, string contentType)
        {
            return HttpProvider.SubmitPost(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, Stream content, long contentLength)
        {
            return HttpProvider.SubmitPost(uri, content, contentLength);
        }

        public static HttpWebResponse SubmitPost(this Uri uri, Stream content, long contentLength, string contentType)
        {
            return HttpProvider.SubmitPost(uri, content, contentLength, contentType);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, Stream content)
        {
            return HttpProvider.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, Stream content, string contentType)
        {
            return HttpProvider.SubmitPut(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, Stream content, long contentLength)
        {
            return HttpProvider.SubmitPut(uri, content, contentLength);
        }

        public static HttpWebResponse SubmitPut(this Uri uri, Stream content, long contentLength, string contentType)
        {
            return HttpProvider.SubmitPut(uri, content, contentLength, contentType);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, Stream content)
        {
            return HttpProvider.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, Stream content, string contentType)
        {
            return HttpProvider.Submit(uri, method, content, contentType);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, Stream content, long contentLength)
        {
            return HttpProvider.Submit(uri, method, content, contentLength);
        }

        public static HttpWebResponse Submit(this Uri uri, string method, Stream content, long contentLength, string contentType)
        {
            return HttpProvider.Submit(uri, method, content, contentLength, contentType);
        }
    }
}