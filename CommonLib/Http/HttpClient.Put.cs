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
        public string Put(string url, string content)
        {
            var request = CreateRequest(url);
            return Put(request, content);
        }

        public string Put(Uri uri, string content)
        {
            var request = CreateRequest(uri);
            return Put(request, content);
        }

        public string Put(HttpWebRequest request, string content)
        {
            using (var response = Submit(request, HttpMethod.PUT, content))
            {
                return DownloadString(response);
            }
        }

        public string Put(string url, NameValueCollection content)
        {
            var request = CreateRequest(url);
            return Put(request, content);
        }

        public string Put(Uri uri, NameValueCollection content)
        {
            var request = CreateRequest(uri);
            return Put(request, content);
        }

        public string Put(HttpWebRequest request, NameValueCollection content)
        {
            using (var response = Submit(request, HttpMethod.PUT, content))
            {
                return DownloadString(response);
            }
        }

        public string Put(string url, byte[] content)
        {
            var request = CreateRequest(url);
            return Put(request, content);
        }

        public string Put(Uri uri, byte[] content)
        {
            var request = CreateRequest(uri);
            return Put(request, content);
        }

        public string Put(HttpWebRequest request, byte[] content)
        {
            using (var response = Submit(request, HttpMethod.PUT, content))
            {
                return DownloadString(response);
            }
        }

        public string Put(string url, Stream content)
        {
            var request = CreateRequest(url);
            return Put(request, content);
        }

        public string Put(Uri uri, Stream content)
        {
            var request = CreateRequest(uri);
            return Put(request, content);
        }

        public string Put(HttpWebRequest request, Stream content)
        {
            using (var response = Submit(request, HttpMethod.PUT, content))
            {
                return DownloadString(response);
            }
        }
    }
}
