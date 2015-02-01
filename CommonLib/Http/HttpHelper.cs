using jaytwo.Common.IO;
using jaytwo.Common.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace jaytwo.Common.Http
{
    public static class HttpHelper
    {
        private static readonly Regex _attachmentFilenameRegex = new Regex(@"attachment;\s*filename=""(?<FILENAME>[^""]+)""",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string GetFileName(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            string contentDisposition = httpWebResponse.GetResponseHeader("Content-Disposition");
            var contentDispositionMatch = _attachmentFilenameRegex.Match(contentDisposition);

            if (contentDispositionMatch.Success)
            {
                return contentDispositionMatch.Groups["FILENAME"].Value.Trim();
            }
            else
            {
                return UrlHelper.GetFileNameWithoutQuery(httpWebResponse.ResponseUri);
            }
        }

        public static string GetEtag(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            return httpWebResponse.GetResponseHeader("ETag");
        }

        private static bool IsContentEncodingMatch(HttpWebResponse httpWebResponse, string encoding)
        {
            return httpWebResponse.ContentEncoding.ToUpperInvariant().Contains(encoding.ToUpperInvariant());
        }

        public static bool IsDeflate(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            return IsContentEncodingMatch(httpWebResponse, "deflate");
        }

        public static bool IsGzip(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            return IsContentEncodingMatch(httpWebResponse, "gzip");
        }

        public static void VerifyResponseStatusSuccess(HttpWebResponse httpWebResponse)
        {
            VerifyResponseStatus(httpWebResponse, InternalHttpHelpers.IsHttpStatusSuccess);
        }

        public static void VerifyResponseStatusOK(HttpWebResponse httpWebResponse)
        {
            VerifyResponseStatus(httpWebResponse, HttpStatusCode.OK);
        }

        public static void VerifyResponseStatus(HttpWebResponse httpWebResponse, HttpStatusCode statusCode)
        {
            VerifyResponseStatus(httpWebResponse, new HttpStatusCode[] { statusCode });
        }

        public static void VerifyResponseStatus(HttpWebResponse httpWebResponse, params HttpStatusCode[] statusCodes)
        {
            VerifyResponseStatus(httpWebResponse, x =>
            {
                foreach (var statusCode in statusCodes)
                {
                    if (statusCode == x)
                    {
                        return true;
                    }
                }
                return false;
            });
        }

        private delegate bool VerifyResponseStatusDelegate(HttpStatusCode statusCode);
        private static void VerifyResponseStatus(HttpWebResponse httpWebResponse, VerifyResponseStatusDelegate verifyMethod)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            if (!verifyMethod.Invoke(httpWebResponse.StatusCode))
            {
                throw new UnexpectedStatusCodeException(httpWebResponse.StatusCode, null, httpWebResponse);
            }
        }

        public static Stream GetContent(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            var resposneStream = httpWebResponse.GetResponseStream();

            if (IsDeflate(httpWebResponse))
            {
                // consume the first two bytes 
                //http://stackoverflow.com/questions/8354811/decoding-git-objects-block-length-does-not-match-with-its-complement-error
                resposneStream.ReadByte();
                resposneStream.ReadByte();

                return new DeflateStream(resposneStream, CompressionMode.Decompress);
            }
            else if (IsGzip(httpWebResponse))
            {
                return new GZipStream(resposneStream, CompressionMode.Decompress);
            }
            else
            {
                return resposneStream;
            }
        }

        public static byte[] GetContentBytes(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            using (var content = GetContent(httpWebResponse))
            {
                return StreamUtility.GetBytesFromStream(content);
            }
        }

        private static Regex contentTypeCharsetRegex = new Regex(@"charset=(?<CHARSET>[^;]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Encoding GetEncoding(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            var contentTypeCharset = contentTypeCharsetRegex.Match(httpWebResponse.ContentType).Groups["CHARSET"].Value.Trim('"');

            return (!string.IsNullOrEmpty(contentTypeCharset))
                ? Encoding.GetEncoding(contentTypeCharset)
                : null;
        }

        public static TextReader GetContentAsReader(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            var encoding = GetEncoding(httpWebResponse);

            if (encoding != null)
            {
                return GetContentAsReader(httpWebResponse, encoding);
            }
            else
            {
                var stream = GetContent(httpWebResponse);
                var result = new StreamReader(stream);
                return result;
            }
        }

        public static TextReader GetContentAsReader(HttpWebResponse httpWebResponse, Encoding encoding)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            var stream = GetContent(httpWebResponse);
            var result = new StreamReader(stream, encoding);
            return result;
        }

        public static string GetContentAsString(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            using (var reader = GetContentAsReader(httpWebResponse))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GetContentAsString(HttpWebResponse httpWebResponse, Encoding encoding)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            using (var reader = GetContentAsReader(httpWebResponse, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        public static Image GetContentAsImage(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
            {
                throw new ArgumentNullException("httpWebResponse");
            }

            using (var content = GetContent(httpWebResponse))
            {
                return Image.FromStream(content);
            }
        }

		public static void SetBasicAuthenticationHeader(HttpWebRequest httpWebRequest, string userName, string password)
		{
			var userInfo = userName + ":" + password;
			SetBasicAuthenticationHeader(httpWebRequest, userInfo);
		}

		public static void SetBasicAuthenticationHeader(HttpWebRequest httpWebRequest, string userInfo)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException("httpWebRequest");
			}

			var authStringBytes = Encoding.UTF8.GetBytes(userInfo);
			var authBase64string = Convert.ToBase64String(authStringBytes);

			httpWebRequest.Headers["Authorization"] = string.Format(CultureInfo.InvariantCulture, "Basic {0}", authBase64string);
		}
    }
}
