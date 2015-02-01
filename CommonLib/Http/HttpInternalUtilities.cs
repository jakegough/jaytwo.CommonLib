using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Text;
using System.Net;
using jaytwo.Common.Http.Exceptions;

namespace jaytwo.Common.Http
{
    internal static class HttpInternalUtilities
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

        public static IDictionary<string, object> ToDictionary(NameValueCollection collection)
        {
            var result = new Dictionary<string, object>();

            foreach (var key in collection.AllKeys)
            {
                var values = collection.GetValues(key);

                if (values.Length > 1)
                {
                    result.Add(key, values);
                }
                else
                {
                    result.Add(key, values[0]);
                }
            }

            return result;
        }

        public static IDictionary<string, object> ToDictionaryWithStringComparer(IDictionary<string, object> dictionary, StringComparer stringComparer)
        {
            var result = new Dictionary<string, object>(stringComparer);

            foreach (var item in dictionary)
            {
                var innerDictionary = item.Value as IDictionary<string, object>;
                if (innerDictionary != null)
                {
                    result.Add(item.Key, ToDictionaryWithStringComparer(innerDictionary, stringComparer));
                }
                else
                {
                    result.Add(item.Key, item.Value);
                }
            }

            return result;
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
