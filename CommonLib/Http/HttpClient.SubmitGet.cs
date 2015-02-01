using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {
        public HttpWebResponse SubmitGet(string url)
        {
            return Submit(url, HttpMethod.GET);
        }

        public HttpWebResponse SubmitGet(Uri uri)
        {
            return Submit(uri, HttpMethod.GET);
        }

        public HttpWebResponse SubmitGet(HttpWebRequest request)
        {
            return Submit(request, HttpMethod.GET);
        }
    }
}
