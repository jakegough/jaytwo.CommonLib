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
        public string DownloadString(string url)
        {
            var request = CreateRequest(url);
            return DownloadString(request);
        }

        public string DownloadString(Uri uri)
        {
            var request = CreateRequest(uri);
            return DownloadString(request);
        }

        public string DownloadString(HttpWebRequest request)
        {
            using (var response = Submit(request, HttpMethod.GET))
            {
                return DownloadString(response);
            }
        }

        public virtual string DownloadString(HttpWebResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            if (response.ContentLength > MaximumDownloadContentLength)
            {
                throw new ContentTooLargeException(response.ContentLength, null, response);
            }

            var result = HttpHelper.GetContentAsString(response);

            try
            {
                HttpHelper.VerifyResponseStatusSuccess(response);
            }
            catch (UnexpectedStatusCodeException exception)
            {
                throw DownloadException.Create(exception, response, result);
            }

            return result;
        }
    }
}
