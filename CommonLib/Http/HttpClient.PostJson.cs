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
        public string PostJson(string url, object content)
        {
            var request = CreateRequest(url);
            return PostJson(request, content);
        }

        public string PostJson(Uri uri, object content)
        {
            var request = CreateRequest(uri);
            return PostJson(request, content);
        }

        public string PostJson(HttpWebRequest request, object content)
        {
            using (var response = SubmitJson(request, HttpMethod.POST, content))
            {
                return DownloadString(response);
            }
        }

        public string PostJson(string url, NameValueCollection content)
        {
            var request = CreateRequest(url);
            return PostJson(request, content);
        }

        public string PostJson(Uri uri, NameValueCollection content)
        {
            var request = CreateRequest(uri);
            return PostJson(request, content);
        }

        public string PostJson(HttpWebRequest request, NameValueCollection content)
        {
            using (var response = SubmitJson(request, HttpMethod.POST, content))
            {
                return DownloadString(response);
            }
        }
    }
}
