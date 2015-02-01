using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace jaytwo.Common.Http
{
    [Serializable]
    public class ContentTooLargeException : WebException
    {
        public long ContentLength { get; private set; }

        public ContentTooLargeException(long contentLength)
            : base(GetMessage(contentLength))
        {
            ContentLength = contentLength;
        }

        public ContentTooLargeException(long contentLength, Exception innerException)
            : base(GetMessage(contentLength), innerException)
        {
            ContentLength = contentLength;
        }

        public ContentTooLargeException(long contentLength, Exception innerException, HttpWebResponse response)
            : base(GetMessage(contentLength), innerException, WebExceptionStatus.MessageLengthLimitExceeded, response)
        {
        }

        protected ContentTooLargeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static string GetMessage(long contentLength)
        {
            var result = string.Format(CultureInfo.InvariantCulture, "Content Too Large ({0} bytes)", contentLength);
            return result;
        }
    }
}
