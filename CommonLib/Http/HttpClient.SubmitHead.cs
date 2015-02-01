using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {
        public HttpWebResponse SubmitHead(string url)
        {
            return Submit(url, HttpMethod.HEAD);
        }

        public HttpWebResponse SubmitHead(Uri uri)
        {
            return Submit(uri, HttpMethod.HEAD);
        }

        public HttpWebResponse SubmitHead(HttpWebRequest request)
        {
            return Submit(request, HttpMethod.HEAD);
        }
    }
}
