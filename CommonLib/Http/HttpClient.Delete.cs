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
        public string Delete(string url)
        {
            var request = CreateRequest(url);
            return Delete(request);
        }

        public string Delete(Uri uri)
        {
            var request = CreateRequest(uri);
            return Delete(request);
        }

        public string Delete(HttpWebRequest request)
        {
            using (var response = Submit(request, HttpMethod.DELETE))
            {
                return DownloadString(response);
            }
        }
    }
}
