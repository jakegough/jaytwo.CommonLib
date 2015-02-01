using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using System.Drawing;

namespace jaytwo.Common.Http
{
    public partial class HttpClient
    {
        public Image DownloadImage(string url)
        {
            var request = CreateRequest(url);
            return DownloadImage(request);
        }

        public Image DownloadImage(Uri uri)
        {
            var request = CreateRequest(uri);
            return DownloadImage(request);
        }

        public Image DownloadImage(HttpWebRequest request)
        {
            using (var response = Submit(request, HttpMethod.GET))
            {
                return DownloadImage(response);
            }
        }

        public Image DownloadImage(HttpWebResponse response)
        {
            var resultBytes = DownloadBytes(response);

            using (var imageStream = new MemoryStream(resultBytes))
            {
                return Image.FromStream(imageStream);
            }
        }
    }
}
