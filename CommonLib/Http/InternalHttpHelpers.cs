using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Text;
using System.Net;

namespace jaytwo.Common.Http
{
    internal static class InternalHttpHelpers
    {
		public static string GetContentTypeOrDefault(HttpWebRequest request, string defaultContentType)
        {
            if (request != null && !string.IsNullOrEmpty(request.ContentType))
            {
                return request.ContentType;
            }
            else
            {
                return defaultContentType;
            }
        }

        public static long GetContentLength(HttpWebRequest request, Stream content)
        {
            long result = -1;

            if (request != null)
            {
                if (content != null && content.CanSeek && request.ContentLength < 0)
                {
                    result = content.Length;
                }
                else
                {
                    result = request.ContentLength;
                }
            }

            return result;
        }

        public static bool IsHttpStatusSuccess(HttpStatusCode statusCode)
        {
            return ((int)statusCode) >= 200 && ((int)statusCode) < 300;
        }

        public static string GetRequestContentTypeWithCharset(string contentType, Encoding encoding)
        {
            if (!string.IsNullOrEmpty(contentType) && encoding != null)
            {
                return string.Format(CultureInfo.InstalledUICulture, "{0}; charset={1}", contentType.TrimEnd(';'), encoding.WebName);
            }
            else
            {
                return contentType;
            }
        }
    }
}
