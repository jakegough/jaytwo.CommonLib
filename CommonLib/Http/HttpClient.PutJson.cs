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
        public string PutJson(string url, object content)
        {
            var request = CreateRequest(url);
            return PutJson(request, content);
        }

        public string PutJson(Uri uri, object content)
        {
            var request = CreateRequest(uri);
            return PutJson(request, content);
        }

        public string PutJson(HttpWebRequest request, object content)
        {
            using (var response = SubmitJson(request, HttpMethod.PUT, content))
            {
                return DownloadString(response);
            }
        }

        public string PutJson(string url, NameValueCollection content)
        {
            var request = CreateRequest(url);
            return PutJson(request, content);
        }

        public string PutJson(Uri uri, NameValueCollection content)
        {
            var request = CreateRequest(uri);
            return PutJson(request, content);
        }

        public string PutJson(HttpWebRequest request, NameValueCollection content)
        {
            using (var response = SubmitJson(request, HttpMethod.PUT, content))
            {
                return DownloadString(response);
            }
        }
    }
}
