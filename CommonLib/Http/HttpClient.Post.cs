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
        public string Post(string url, string content)
        {
            var request = CreateRequest(url);
            return Post(request, content);
        }

        public string Post(Uri uri, string content)
        {
            var request = CreateRequest(uri);
            return Post(request, content);
        }

        public string Post(HttpWebRequest request, string content)
        {
            using (var response = Submit(request, HttpMethod.POST, content))
            {
                return DownloadString(response);
            }
        }

        public string Post(string url, NameValueCollection content)
        {
            var request = CreateRequest(url);
            return Post(request, content);
        }

        public string Post(Uri uri, NameValueCollection content)
        {
            var request = CreateRequest(uri);
            return Post(request, content);
        }

        public string Post(HttpWebRequest request, NameValueCollection content)
        {
            using (var response = Submit(request, HttpMethod.POST, content))
            {
                return DownloadString(response);
            }
        }

        public string Post(string url, byte[] content)
        {
            var request = CreateRequest(url);
            return Post(request, content);
        }

        public string Post(Uri uri, byte[] content)
        {
            var request = CreateRequest(uri);
            return Post(request, content);
        }

        public string Post(HttpWebRequest request, byte[] content)
        {
            using (var response = Submit(request, HttpMethod.POST, content))
            {
                return DownloadString(response);
            }
        }
        public string Post(string url, Stream content)
        {
            var request = CreateRequest(url);
            return Post(request, content);
        }

        public string Post(Uri uri, Stream content)
        {
            var request = CreateRequest(uri);
            return Post(request, content);
        }

        public string Post(HttpWebRequest request, Stream content)
        {
            using (var response = Submit(request, HttpMethod.POST, content))
            {
                return DownloadString(response);
            }
        }
    }
}
