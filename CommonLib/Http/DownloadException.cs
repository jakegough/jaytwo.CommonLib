using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace jaytwo.Common.Http
{
    [Serializable]
    public class DownloadException : WebException
    {
        public string Content { get; set; }

        public DownloadException(string message)
            : base(message)
        {
        }

        public DownloadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DownloadException(string message, Exception innerException, WebExceptionStatus status, HttpWebResponse response)
            : base(message, innerException, status, response)
        {
        }

        protected DownloadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static DownloadException Create(Exception innerException, HttpWebResponse response, byte[] resultContent)
        {
            var encoding = HttpHelper.GetEncoding(response) ?? Encoding.UTF8;
            var resultContentString = encoding.GetString(resultContent);

            return Create(innerException, response, resultContentString);
        }

        public static DownloadException Create(Exception innerException, HttpWebResponse response, string resultContent)
        {
            if (innerException == null)
            {
                throw new ArgumentNullException("innerException");
            }

            var result = new DownloadException(innerException.Message, innerException, WebExceptionStatus.ProtocolError, response);
            result.Content = resultContent;

            throw result;
        }
    }
}
