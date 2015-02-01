using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace jaytwo.Common.Http
{
    [Serializable]
    public class UnexpectedStatusCodeException : WebException
    {
        public HttpStatusCode StatusCode { get; set; }

        public UnexpectedStatusCodeException(HttpStatusCode statusCode)
            : base(GetMessage(statusCode))
        {
            StatusCode = statusCode;
        }

        public UnexpectedStatusCodeException(HttpStatusCode statusCode, Exception innerException, HttpWebResponse response)
            : base(GetMessage(statusCode), innerException, WebExceptionStatus.ProtocolError, response)
        {
            StatusCode = statusCode;
        }

        protected UnexpectedStatusCodeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static string GetMessage(HttpStatusCode statusCode)
        {
            var result = string.Format(CultureInfo.InvariantCulture, "Unexpected HTTP Status Code: {0} ({1})", (int)statusCode, statusCode);
            return result;
        }
    }
}
