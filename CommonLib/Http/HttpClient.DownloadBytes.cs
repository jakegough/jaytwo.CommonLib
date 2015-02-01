using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using System.Globalization;

namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {

        public byte[] DownloadBytes(string url)
        {
            var request = CreateRequest(url);
            return DownloadBytes(request);
        }

        public byte[] DownloadBytes(Uri uri)
        {
            var request = CreateRequest(uri);
            return DownloadBytes(request);
        }

        public byte[] DownloadBytes(HttpWebRequest request)
        {
            using (var response = Submit(request, HttpMethod.GET))
            {
                return DownloadBytes(response);
            }
        }

        public virtual byte[] DownloadBytes(HttpWebResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            if (response.ContentLength > MaximumDownloadContentLength)
            {
                throw new ContentTooLargeException(response.ContentLength, null, response);
            }

            var result = HttpHelper.GetContentBytes(response);

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
