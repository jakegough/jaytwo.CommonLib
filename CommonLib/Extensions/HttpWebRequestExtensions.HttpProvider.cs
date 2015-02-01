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
        public static string Delete(this HttpWebRequest request)
        {
            return HttpProvider.Delete(request);
        }

        public static byte[] DownloadBytes(this HttpWebRequest request)
        {
            return HttpProvider.DownloadBytes(request);
        }

        public static Image DownloadImage(this HttpWebRequest request)
        {
            return HttpProvider.DownloadImage(request);
        }

        public static string DownloadString(this HttpWebRequest request)
        {
            return HttpProvider.DownloadString(request);
        }

        public static string Post(this HttpWebRequest request, string content)
        {
            return HttpProvider.Post(request, content);
        }

        public static string Post(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.Post(request, content);
        }

        public static string Post(this HttpWebRequest request, byte[] content)
        {
            return HttpProvider.Post(request, content);
        }

        public static string Post(this HttpWebRequest request, Stream content)
        {
            return HttpProvider.Post(request, content);
        }

        public static string PostJson(this HttpWebRequest request, object content)
        {
            return HttpProvider.PostJson(request, content);
        }

        public static string PostJson(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.PostJson(request, content);
        }

        public static string Put(this HttpWebRequest request, string content)
        {
            return HttpProvider.Put(request, content);
        }

        public static string Put(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.Put(request, content);
        }

        public static string Put(this HttpWebRequest request, byte[] content)
        {
            return HttpProvider.Put(request, content);
        }

        public static string Put(this HttpWebRequest request, Stream content)
        {
            return HttpProvider.Put(request, content);
        }

        public static string PutJson(this HttpWebRequest request, object content)
        {
            return HttpProvider.PutJson(request, content);
        }

        public static string PutJson(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.PutJson(request, content);
        }

        public static HttpWebResponse SubmitPostJson(this HttpWebRequest request, object content)
        {
            return HttpProvider.SubmitPostJson(request, content);
        }

        public static HttpWebResponse SubmitPutJson(this HttpWebRequest request, object content)
        {
            return HttpProvider.SubmitPutJson(request, content);
        }

        public static HttpWebResponse SubmitPostJson(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.SubmitPostJson(request, content);
        }

        public static HttpWebResponse SubmitPutJson(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.SubmitPutJson(request, content);
        }

        public static HttpWebResponse SubmitJson(this HttpWebRequest request, string method, NameValueCollection content)
        {
            return HttpProvider.SubmitJson(request, method, content);
        }

        public static HttpWebResponse SubmitJson(this HttpWebRequest request, string method, NameValueCollection content, string contentType)
        {
            return HttpProvider.SubmitJson(request, method, content, contentType);
        }

        public static HttpWebResponse SubmitJson(this HttpWebRequest request, string method, object content)
        {
            return HttpProvider.SubmitJson(request, method, content);
        }

        public static HttpWebResponse SubmitJson(this HttpWebRequest request, string method, object content, string contentType)
        {
            return HttpProvider.SubmitJson(request, method, content, contentType);
        }

        public static HttpWebResponse SubmitGet(this HttpWebRequest request)
        {
            return HttpProvider.SubmitGet(request);
        }

        public static HttpWebResponse SubmitHead(this HttpWebRequest request)
        {
            return HttpProvider.SubmitHead(request);
        }

        public static HttpWebResponse SubmitDelete(this HttpWebRequest request)
        {
            return HttpProvider.SubmitDelete(request);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request)
        {
            return HttpProvider.SubmitPost(request);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, string content)
        {
            return HttpProvider.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, string content, string contentType)
        {
            return HttpProvider.SubmitPost(request, content, contentType);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, byte[] content)
        {
            return HttpProvider.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, byte[] content, string contentType)
        {
            return HttpProvider.SubmitPost(request, content, contentType);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request)
        {
            return HttpProvider.SubmitPut(request);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, NameValueCollection content)
        {
            return HttpProvider.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, string content)
        {
            return HttpProvider.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, string content, string contentType)
        {
            return HttpProvider.SubmitPut(request, content, contentType);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, byte[] content)
        {
            return HttpProvider.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, byte[] content, string contentType)
        {
            return HttpProvider.SubmitPut(request, content, contentType);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request)
        {
            return HttpProvider.Submit(request);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method)
        {
            return HttpProvider.Submit(request, method);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, string content)
        {
            return HttpProvider.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, NameValueCollection content)
        {
            return HttpProvider.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, string content, string contentType)
        {
            return HttpProvider.Submit(request, method, content, contentType);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, byte[] content)
        {
            return HttpProvider.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, byte[] content, string contentType)
        {
            return HttpProvider.Submit(request, method, content, contentType);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, Stream content)
        {
            return HttpProvider.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, Stream content, string contentType)
        {
            return HttpProvider.SubmitPost(request, content, contentType);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, Stream content, long contentLength)
        {
            return HttpProvider.SubmitPost(request, content, contentLength);
        }

        public static HttpWebResponse SubmitPost(this HttpWebRequest request, Stream content, long contentLength, string contentType)
        {
            return HttpProvider.SubmitPost(request, content, contentLength, contentType);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, Stream content)
        {
            return HttpProvider.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, Stream content, string contentType)
        {
            return HttpProvider.SubmitPut(request, content, contentType);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, Stream content, long contentLength)
        {
            return HttpProvider.SubmitPut(request, content, contentLength);
        }

        public static HttpWebResponse SubmitPut(this HttpWebRequest request, Stream content, long contentLength, string contentType)
        {
            return HttpProvider.SubmitPut(request, content, contentLength, contentType);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, Stream content)
        {
            return HttpProvider.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, Stream content, string contentType)
        {
            return HttpProvider.Submit(request, method, content, contentType);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, Stream content, long contentLength)
        {
            return HttpProvider.Submit(request, method, content, contentLength);
        }

        public static HttpWebResponse Submit(this HttpWebRequest request, string method, Stream content, long contentLength, string contentType)
        {
            return HttpProvider.Submit(request, method, content, contentLength, contentType);
        }
    }
}