using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace jaytwo.Common.Http
{
    public static class HttpProvider
    {
        private static HttpClient _httpClient;

        static HttpProvider()
        {
            ResetClient();
        }

        public static void ResetClient()
        {
            SetHttpClient(new HttpClient());
        }

        public static void SetHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static string Delete(string url)
        {
            return _httpClient.Delete(url);
        }

        public static string Delete(Uri uri)
        {
            return _httpClient.Delete(uri);
        }

        public static string Delete(HttpWebRequest request)
        {
            return _httpClient.Delete(request);
        }

        public static byte[] DownloadBytes(string url)
        {
            return _httpClient.DownloadBytes(url);
        }

        public static byte[] DownloadBytes(Uri uri)
        {
            return _httpClient.DownloadBytes(uri);
        }

        public static byte[] DownloadBytes(HttpWebRequest request)
        {
            return _httpClient.DownloadBytes(request);
        }

        public static byte[] DownloadBytes(HttpWebResponse response)
        {
            return _httpClient.DownloadBytes(response);
        }

        public static Image DownloadImage(string url)
        {
            return _httpClient.DownloadImage(url);
        }

        public static Image DownloadImage(Uri uri)
        {
            return _httpClient.DownloadImage(uri);
        }

        public static Image DownloadImage(HttpWebRequest request)
        {
            return _httpClient.DownloadImage(request);
        }

        public static Image DownloadImage(HttpWebResponse response)
        {
            return _httpClient.DownloadImage(response);
        }

        public static string DownloadString(string url)
        {
            return _httpClient.DownloadString(url);
        }

        public static string DownloadString(Uri uri)
        {
            return _httpClient.DownloadString(uri);
        }

        public static string DownloadString(HttpWebRequest request)
        {
            return _httpClient.DownloadString(request);
        }

        public static string DownloadString(HttpWebResponse response)
        {
            return _httpClient.DownloadString(response);
        }

        public static string Post(string url, string content)
        {
            return _httpClient.Post(url, content);
        }

        public static string Post(Uri uri, string content)
        {
            return _httpClient.Post(uri, content);
        }

        public static string Post(HttpWebRequest request, string content)
        {
            return _httpClient.Post(request, content);
        }

        public static string Post(string url, NameValueCollection content)
        {
            return _httpClient.Post(url, content);
        }

        public static string Post(Uri uri, NameValueCollection content)
        {
            return _httpClient.Post(uri, content);
        }

        public static string Post(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.Post(request, content);
        }

        public static string Post(string url, byte[] content)
        {
            return _httpClient.Post(url, content);
        }

        public static string Post(Uri uri, byte[] content)
        {
            return _httpClient.Post(uri, content);
        }

        public static string Post(HttpWebRequest request, byte[] content)
        {
            return _httpClient.Post(request, content);
        }

        public static string Post(string url, Stream content)
        {
            return _httpClient.Post(url, content);
        }

        public static string Post(Uri uri, Stream content)
        {
            return _httpClient.Post(uri, content);
        }

        public static string Post(HttpWebRequest request, Stream content)
        {
            return _httpClient.Post(request, content);
        }

        public static string PostJson(string url, object content)
        {
            return _httpClient.PostJson(url, content);
        }

        public static string PostJson(Uri uri, object content)
        {
            return _httpClient.PostJson(uri, content);
        }

        public static string PostJson(HttpWebRequest request, object content)
        {
            return _httpClient.PostJson(request, content);
        }

        public static string PostJson(string url, NameValueCollection content)
        {
            return _httpClient.PostJson(url, content);
        }

        public static string PostJson(Uri uri, NameValueCollection content)
        {
            return _httpClient.PostJson(uri, content);
        }

        public static string PostJson(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.PostJson(request, content);
        }

        public static string Put(string url, string content)
        {
            return _httpClient.Put(url, content);
        }

        public static string Put(Uri uri, string content)
        {
            return _httpClient.Put(uri, content);
        }

        public static string Put(HttpWebRequest request, string content)
        {
            return _httpClient.Put(request, content);
        }

        public static string Put(string url, NameValueCollection content)
        {
            return _httpClient.Put(url, content);
        }

        public static string Put(Uri uri, NameValueCollection content)
        {
            return _httpClient.Put(uri, content);
        }

        public static string Put(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.Put(request, content);
        }

        public static string Put(string url, byte[] content)
        {
            return _httpClient.Put(url, content);
        }

        public static string Put(Uri uri, byte[] content)
        {
            return _httpClient.Put(uri, content);
        }

        public static string Put(HttpWebRequest request, byte[] content)
        {
            return _httpClient.Put(request, content);
        }

        public static string Put(string url, Stream content)
        {
            return _httpClient.Put(url, content);
        }

        public static string Put(Uri uri, Stream content)
        {
            return _httpClient.Put(uri, content);
        }

        public static string Put(HttpWebRequest request, Stream content)
        {
            return _httpClient.Put(request, content);
        }

        public static string PutJson(string url, object content)
        {
            return _httpClient.PutJson(url, content);
        }

        public static string PutJson(Uri uri, object content)
        {
            return _httpClient.PutJson(uri, content);
        }

        public static string PutJson(HttpWebRequest request, object content)
        {
            return _httpClient.PutJson(request, content);
        }

        public static string PutJson(string url, NameValueCollection content)
        {
            return _httpClient.PutJson(url, content);
        }

        public static string PutJson(Uri uri, NameValueCollection content)
        {
            return _httpClient.PutJson(uri, content);
        }

        public static string PutJson(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.PutJson(request, content);
        }

        public static HttpWebResponse SubmitPostJson(string url, object content)
        {
            return _httpClient.SubmitPostJson(url, content);
        }
        public static HttpWebResponse SubmitPostJson(Uri uri, object content)
        {
            return _httpClient.SubmitPostJson(uri, content);
        }
        public static HttpWebResponse SubmitPostJson(HttpWebRequest request, object content)
        {
            return _httpClient.SubmitPostJson(request, content);
        }

        public static HttpWebResponse SubmitPostJson(string url, NameValueCollection content)
        {
            return _httpClient.SubmitPostJson(url, content);
        }
        public static HttpWebResponse SubmitPostJson(Uri uri, NameValueCollection content)
        {
            return _httpClient.SubmitPostJson(uri, content);
        }
        public static HttpWebResponse SubmitPostJson(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.SubmitPostJson(request, content);
        }

        public static HttpWebResponse SubmitPutJson(string url, object content)
        {
            return _httpClient.SubmitPutJson(url, content);
        }
        public static HttpWebResponse SubmitPutJson(Uri uri, object content)
        {
            return _httpClient.SubmitPutJson(uri, content);
        }
        public static HttpWebResponse SubmitPutJson(HttpWebRequest request, object content)
        {
            return _httpClient.SubmitPutJson(request, content);
        }

        public static HttpWebResponse SubmitPutJson(string url, NameValueCollection content)
        {
            return _httpClient.SubmitPutJson(url, content);
        }
        public static HttpWebResponse SubmitPutJson(Uri uri, NameValueCollection content)
        {
            return _httpClient.SubmitPutJson(uri, content);
        }
        public static HttpWebResponse SubmitPutJson(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.SubmitPutJson(request, content);
        }

        public static HttpWebResponse SubmitJson(string url, string method, NameValueCollection content)
        {
            return _httpClient.SubmitJson(url, method, content);
        }

        public static HttpWebResponse SubmitJson(Uri uri, string method, NameValueCollection content)
        {
            return _httpClient.SubmitJson(uri, method, content);
        }

        public static HttpWebResponse SubmitJson(string url, string method, NameValueCollection content, string contentType)
        {
            return _httpClient.SubmitJson(url, method, content, contentType);
        }

        public static HttpWebResponse SubmitJson(Uri uri, string method, NameValueCollection content, string contentType)
        {
            return _httpClient.SubmitJson(uri, method, content, contentType);
        }

        public static HttpWebResponse SubmitJson(HttpWebRequest request, string method, NameValueCollection content, string contentType)
        {
            return _httpClient.SubmitJson(request, method, content, contentType);
        }

        public static HttpWebResponse SubmitJson(HttpWebRequest request, string method, NameValueCollection content)
        {
            return _httpClient.SubmitJson(request, method, content);
        }

        public static HttpWebResponse SubmitJson(string url, string method, object content)
        {
            return _httpClient.SubmitJson(url, method, content);
        }

        public static HttpWebResponse SubmitJson(Uri uri, string method, object content)
        {
            return _httpClient.SubmitJson(uri, method, content);
        }

        public static HttpWebResponse SubmitJson(string url, string method, object content, string contentType)
        {
            return _httpClient.SubmitJson(url, method, content, contentType);
        }

        public static HttpWebResponse SubmitJson(Uri uri, string method, object content, string contentType)
        {
            return _httpClient.SubmitJson(uri, method, content, contentType);
        }

        public static HttpWebResponse SubmitJson(HttpWebRequest request, string method, object content)
        {
            return _httpClient.SubmitJson(request, method, content);
        }

        public static HttpWebResponse SubmitJson(HttpWebRequest request, string method, object content, string contentType)
        {
            return _httpClient.SubmitJson(request, method, content, contentType);
        }

        public static HttpWebResponse SubmitGet(string url)
        {
            return _httpClient.SubmitGet(url);
        }

        public static HttpWebResponse SubmitHead(string url)
        {
            return _httpClient.SubmitHead(url);
        }

        public static HttpWebResponse SubmitDelete(string url)
        {
            return _httpClient.SubmitDelete(url);
        }

        public static HttpWebResponse SubmitPost(string url)
        {
            return _httpClient.SubmitPost(url);
        }

        public static HttpWebResponse SubmitPost(string url, NameValueCollection content)
        {
            return _httpClient.SubmitPost(url, content);
        }

        public static HttpWebResponse SubmitPost(string url, string content)
        {
            return _httpClient.SubmitPost(url, content);
        }

        public static HttpWebResponse SubmitPost(string url, string content, string contentType)
        {
            return _httpClient.SubmitPost(url, content, contentType);
        }

        public static HttpWebResponse SubmitPost(string url, byte[] content)
        {
            return _httpClient.SubmitPost(url, content);
        }

        public static HttpWebResponse SubmitPost(string url, byte[] content, string contentType)
        {
            return _httpClient.SubmitPost(url, content, contentType);
        }

        public static HttpWebResponse SubmitPut(string url)
        {
            return _httpClient.SubmitPut(url);
        }

        public static HttpWebResponse SubmitPut(string url, NameValueCollection content)
        {
            return _httpClient.SubmitPut(url, content);
        }

        public static HttpWebResponse SubmitPut(string url, string content)
        {
            return _httpClient.SubmitPut(url, content);
        }

        public static HttpWebResponse SubmitPut(string url, string content, string contentType)
        {
            return _httpClient.SubmitPut(url, content, contentType);
        }

        public static HttpWebResponse SubmitPut(string url, byte[] content)
        {
            return _httpClient.SubmitPut(url, content);
        }

        public static HttpWebResponse SubmitPut(string url, byte[] content, string contentType)
        {
            return _httpClient.SubmitPut(url, content, contentType);
        }

        public static HttpWebResponse Submit(string url, string method)
        {
            return _httpClient.Submit(url, method);
        }

        public static HttpWebResponse Submit(string url, string method, NameValueCollection content)
        {
            return _httpClient.Submit(url, method, content);
        }

        public static HttpWebResponse Submit(string url, string method, string content)
        {
            return _httpClient.Submit(url, method, content);
        }

        public static HttpWebResponse Submit(string url, string method, string content, string contentType)
        {
            return _httpClient.Submit(url, method, content, contentType);
        }

        public static HttpWebResponse Submit(string url, string method, byte[] content)
        {
            return _httpClient.Submit(url, method, content);
        }

        public static HttpWebResponse Submit(string url, string method, byte[] content, string contentType)
        {
            return _httpClient.Submit(url, method, content, contentType);
        }

        public static HttpWebResponse SubmitGet(Uri uri)
        {
            return _httpClient.SubmitGet(uri);
        }

        public static HttpWebResponse SubmitHead(Uri uri)
        {
            return _httpClient.SubmitHead(uri);
        }

        public static HttpWebResponse SubmitDelete(Uri uri)
        {
            return _httpClient.SubmitDelete(uri);
        }

        public static HttpWebResponse SubmitPost(Uri uri)
        {
            return _httpClient.SubmitPost(uri);
        }

        public static HttpWebResponse SubmitPost(Uri uri, NameValueCollection content)
        {
            return _httpClient.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(Uri uri, string content)
        {
            return _httpClient.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(Uri uri, string content, string contentType)
        {
            return _httpClient.SubmitPost(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPost(Uri uri, byte[] content)
        {
            return _httpClient.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(Uri uri, byte[] content, string contentType)
        {
            return _httpClient.SubmitPost(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPut(Uri uri)
        {
            return _httpClient.SubmitPut(uri);
        }

        public static HttpWebResponse SubmitPut(Uri uri, NameValueCollection content)
        {
            return _httpClient.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(Uri uri, string content)
        {
            return _httpClient.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(Uri uri, string content, string contentType)
        {
            return _httpClient.SubmitPut(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPut(Uri uri, byte[] content)
        {
            return _httpClient.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(Uri uri, byte[] content, string contentType)
        {
            return _httpClient.SubmitPut(uri, content, contentType);
        }

        public static HttpWebResponse Submit(Uri uri, string method)
        {
            return _httpClient.Submit(uri, method);
        }

        public static HttpWebResponse Submit(Uri uri, string method, NameValueCollection content)
        {
            return _httpClient.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(Uri uri, string method, string content)
        {
            return _httpClient.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(Uri uri, string method, string content, string contentType)
        {
            return _httpClient.Submit(uri, method, content, contentType);
        }

        public static HttpWebResponse Submit(Uri uri, string method, byte[] content)
        {
            return _httpClient.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(Uri uri, string method, byte[] content, string contentType)
        {
            return _httpClient.Submit(uri, method, content, contentType);
        }

        public static HttpWebResponse SubmitGet(HttpWebRequest request)
        {
            return _httpClient.SubmitGet(request);
        }

        public static HttpWebResponse SubmitHead(HttpWebRequest request)
        {
            return _httpClient.SubmitHead(request);
        }

        public static HttpWebResponse SubmitDelete(HttpWebRequest request)
        {
            return _httpClient.SubmitDelete(request);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request)
        {
            return _httpClient.SubmitPost(request);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, string content)
        {
            return _httpClient.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, string content, string contentType)
        {
            return _httpClient.SubmitPost(request, content, contentType);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, byte[] content)
        {
            return _httpClient.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, byte[] content, string contentType)
        {
            return _httpClient.SubmitPost(request, content, contentType);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request)
        {
            return _httpClient.SubmitPut(request);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, NameValueCollection content)
        {
            return _httpClient.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, string content)
        {
            return _httpClient.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, string content, string contentType)
        {
            return _httpClient.SubmitPut(request, content, contentType);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, byte[] content)
        {
            return _httpClient.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, byte[] content, string contentType)
        {
            return _httpClient.SubmitPut(request, content, contentType);
        }

        public static HttpWebResponse Submit(HttpWebRequest request)
        {
            return _httpClient.Submit(request);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method)
        {
            return _httpClient.Submit(request, method);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, string content)
        {
            return _httpClient.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, NameValueCollection content)
        {
            return _httpClient.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, string content, string contentType)
        {
            return _httpClient.Submit(request, method, content, contentType);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, byte[] content)
        {
            return _httpClient.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, byte[] content, string contentType)
        {
            return _httpClient.Submit(request, method, content, contentType);
        }

        public static HttpWebResponse SubmitPost(string url, Stream content)
        {
            return _httpClient.SubmitPost(url, content);
        }

        public static HttpWebResponse SubmitPost(string url, Stream content, string contentType)
        {
            return _httpClient.SubmitPost(url, content, contentType);
        }

        public static HttpWebResponse SubmitPost(string url, Stream content, long contentLength)
        {
            return _httpClient.SubmitPost(url, content, contentLength);
        }

        public static HttpWebResponse SubmitPost(string url, Stream content, long contentLength, string contentType)
        {
            return _httpClient.SubmitPost(url, content, contentLength, contentType);
        }

        public static HttpWebResponse SubmitPost(Uri uri, Stream content)
        {
            return _httpClient.SubmitPost(uri, content);
        }

        public static HttpWebResponse SubmitPost(Uri uri, Stream content, string contentType)
        {
            return _httpClient.SubmitPost(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPost(Uri uri, Stream content, long contentLength)
        {
            return _httpClient.SubmitPost(uri, content, contentLength);
        }

        public static HttpWebResponse SubmitPost(Uri uri, Stream content, long contentLength, string contentType)
        {
            return _httpClient.SubmitPost(uri, content, contentLength, contentType);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, Stream content)
        {
            return _httpClient.SubmitPost(request, content);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, Stream content, string contentType)
        {
            return _httpClient.SubmitPost(request, content, contentType);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, Stream content, long contentLength)
        {
            return _httpClient.SubmitPost(request, content, contentLength);
        }

        public static HttpWebResponse SubmitPost(HttpWebRequest request, Stream content, long contentLength, string contentType)
        {
            return _httpClient.SubmitPost(request, content, contentLength, contentType);
        }

        public static HttpWebResponse SubmitPut(string url, Stream content)
        {
            return _httpClient.SubmitPut(url, content);
        }

        public static HttpWebResponse SubmitPut(string url, Stream content, string contentType)
        {
            return _httpClient.SubmitPut(url, content, contentType);
        }

        public static HttpWebResponse SubmitPut(string url, Stream content, long contentLength)
        {
            return _httpClient.SubmitPut(url, content, contentLength);
        }

        public static HttpWebResponse SubmitPut(string url, Stream content, long contentLength, string contentType)
        {
            return _httpClient.SubmitPut(url, content, contentLength, contentType);
        }

        public static HttpWebResponse SubmitPut(Uri uri, Stream content)
        {
            return _httpClient.SubmitPut(uri, content);
        }

        public static HttpWebResponse SubmitPut(Uri uri, Stream content, string contentType)
        {
            return _httpClient.SubmitPut(uri, content, contentType);
        }

        public static HttpWebResponse SubmitPut(Uri uri, Stream content, long contentLength)
        {
            return _httpClient.SubmitPut(uri, content, contentLength);
        }

        public static HttpWebResponse SubmitPut(Uri uri, Stream content, long contentLength, string contentType)
        {
            return _httpClient.SubmitPut(uri, content, contentLength, contentType);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, Stream content)
        {
            return _httpClient.SubmitPut(request, content);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, Stream content, string contentType)
        {
            return _httpClient.SubmitPut(request, content, contentType);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, Stream content, long contentLength)
        {
            return _httpClient.SubmitPut(request, content, contentLength);
        }

        public static HttpWebResponse SubmitPut(HttpWebRequest request, Stream content, long contentLength, string contentType)
        {
            return _httpClient.SubmitPut(request, content, contentLength, contentType);
        }

        public static HttpWebResponse Submit(string url, string method, Stream content)
        {
            return _httpClient.Submit(url, method, content);
        }

        public static HttpWebResponse Submit(string url, string method, Stream content, string contentType)
        {
            return _httpClient.Submit(url, method, content, contentType);
        }

        public static HttpWebResponse Submit(string url, string method, Stream content, long contentLength)
        {
            return _httpClient.Submit(url, method, content, contentLength);
        }

        public static HttpWebResponse Submit(string url, string method, Stream content, long contentLength, string contentType)
        {
            return _httpClient.Submit(url, method, content, contentLength, contentType);
        }

        public static HttpWebResponse Submit(Uri uri, string method, Stream content)
        {
            return _httpClient.Submit(uri, method, content);
        }

        public static HttpWebResponse Submit(Uri uri, string method, Stream content, string contentType)
        {
            return _httpClient.Submit(uri, method, content, contentType);
        }

        public static HttpWebResponse Submit(Uri uri, string method, Stream content, long contentLength)
        {
            return _httpClient.Submit(uri, method, content, contentLength);
        }

        public static HttpWebResponse Submit(Uri uri, string method, Stream content, long contentLength, string contentType)
        {
            return _httpClient.Submit(uri, method, content, contentLength, contentType);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, Stream content)
        {
            return _httpClient.Submit(request, method, content);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, Stream content, string contentType)
        {
            return _httpClient.Submit(request, method, content, contentType);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, Stream content, long contentLength)
        {
            return _httpClient.Submit(request, method, content, contentLength);
        }

        public static HttpWebResponse Submit(HttpWebRequest request, string method, Stream content, long contentLength, string contentType)
        {
            return _httpClient.Submit(request, method, content, contentLength, contentType);
        }

        public static HttpWebRequest CreateRequest(string url)
        {
            return _httpClient.CreateRequest(url);
        }

        public static HttpWebRequest CreateRequest(Uri uri)
        {
            return _httpClient.CreateRequest(uri);
        }
    }
}
