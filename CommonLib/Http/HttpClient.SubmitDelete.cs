using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {
        public HttpWebResponse SubmitDelete(string url)
        {
            return Submit(url, HttpMethod.DELETE);
        }

        public HttpWebResponse SubmitDelete(Uri uri)
        {
            return Submit(uri, HttpMethod.DELETE);
        }

        public HttpWebResponse SubmitDelete(HttpWebRequest request)
        {
            return Submit(request, HttpMethod.DELETE);
        }
    }
}
