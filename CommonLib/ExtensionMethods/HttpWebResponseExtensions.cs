using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Globalization;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class HttpWebResponseExtensions
	{
		public static string GetFileName(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			var attachmentFilenameRegex = new Regex(
				@"attachment;\s*filename=""(?<FILENAME>[^""]+)""",
				RegexOptions.IgnoreCase);

			string contentDisposition = httpWebResponse.GetResponseHeader("Content-Disposition");
			var contentDispositionMatch = attachmentFilenameRegex.Match(contentDisposition);

			if (contentDispositionMatch.Success)
			{
				return contentDispositionMatch.Groups["FILENAME"].Value.Trim();
			}
			else
			{
				return httpWebResponse.ResponseUri.GetFileNameWithoutQuery();
			}
		}

		public static string GetEtag(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			return httpWebResponse.GetResponseHeader("ETag");
		}

		private static bool IsContentEncodingMatch(this HttpWebResponse httpWebResponse, string encoding)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			return httpWebResponse.ContentEncoding.ToUpperInvariant().Contains(encoding.ToUpperInvariant());
		}

		public static bool IsDeflate(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			return httpWebResponse.IsContentEncodingMatch("deflate");
		}

		public static bool IsGzip(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			return httpWebResponse.IsContentEncodingMatch("gzip");
		}

		public static HttpWebResponse VerifyResponseStatusOK(this HttpWebResponse httpWebResponse)
		{
			return VerifyResponseStatus(httpWebResponse, HttpStatusCode.OK);
		}

		public static HttpWebResponse VerifyResponseStatus(this HttpWebResponse httpWebResponse, HttpStatusCode statusCode)
		{
			return VerifyResponseStatus(httpWebResponse, new HttpStatusCode[] { statusCode });
		}

		public static HttpWebResponse VerifyResponseStatus(this HttpWebResponse httpWebResponse, HttpStatusCode[] statusCodes)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			if (!statusCodes.Contains(httpWebResponse.StatusCode))
			{
				int statusCodeInt = (int)httpWebResponse.StatusCode;
				string message = string.Format(CultureInfo.InvariantCulture, "Unexpected HTTP Status Code: {0} ({1})", statusCodeInt, httpWebResponse.StatusCode);
				throw new WebException(message, null, WebExceptionStatus.ProtocolError, httpWebResponse);
			}

			return httpWebResponse;
		}

		public static Stream GetContent(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			var resposneStream = httpWebResponse.GetResponseStream();

			if (httpWebResponse.IsDeflate())
			{
				// consume the first two bytes 
				//http://stackoverflow.com/questions/8354811/decoding-git-objects-block-length-does-not-match-with-its-complement-error
				resposneStream.ReadBytes(2);

				return resposneStream.Deflate(CompressionMode.Decompress);
			}
			else if (httpWebResponse.IsGzip())
			{
				return resposneStream.Gzip(CompressionMode.Decompress);
			}
			else
			{
				return resposneStream;
			}
		}

		public static byte[] GetContentBytes(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			using (var content = httpWebResponse.GetContent())
			{
				return content.GetBytes();
			}
		}

		private static Regex contentTypeCharsetRegex = new Regex(@"charset=(?<CHARSET>[^;]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public static Encoding GetEncoding(this HttpWebResponse httpWebResponse)
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

		public static TextReader GetContentAsReader(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			var encoding = httpWebResponse.GetEncoding();
			return httpWebResponse.GetContentAsReader(encoding);
		}

		public static TextReader GetContentAsReader(this HttpWebResponse httpWebResponse, Encoding encoding)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			return httpWebResponse
				.GetContent()
				.GetReader(encoding);
		}

		public static XmlReader GetContentAsXmlReader(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			var encoding = httpWebResponse.GetEncoding();
			return httpWebResponse.GetContentAsXmlReader(encoding);
		}

		public static XmlReader GetContentAsXmlReader(this HttpWebResponse httpWebResponse, Encoding encoding)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			return httpWebResponse
				.GetContent()
				.GetXmlReader(encoding);
		}

		public static string GetContentAsString(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			using (var reader = httpWebResponse.GetContentAsReader())
			{
				return reader.ReadToEnd();
			}
		}

		public static string GetContentAsString(this HttpWebResponse httpWebResponse, Encoding encoding)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			using (var reader = httpWebResponse.GetContentAsReader(encoding))
			{
				return reader.ReadToEnd();
			}
		}

		public static Image GetContentAsImage(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			using (var content = httpWebResponse.GetContent())
			{
				return Image.FromStream(content);
			}
		}

		public static XmlDocument GetContentAsXmlDocument(this HttpWebResponse httpWebResponse)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			using (var reader = httpWebResponse.GetContentAsXmlReader())
			{
				return reader.GetXmlDocument();
			}
		}

		public static XmlDocument GetContentAsXmlDocument(this HttpWebResponse httpWebResponse, Encoding encoding)
		{
			if (httpWebResponse == null)
			{
				throw new ArgumentNullException("httpWebResponse");
			}

			using (var reader = httpWebResponse.GetContentAsXmlReader(encoding))
			{
				return reader.GetXmlDocument();
			}
		}
	}
}
