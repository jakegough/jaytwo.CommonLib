using jaytwo.Common.Collections;
using jaytwo.Common.Appendix;
using jaytwo.Common.System;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace jaytwo.Common.Http
{
    public static class UrlHelper
    {
        public static string Combine(string baseUrl, string path)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("baseUrl");
            }

            return baseUrl.TrimEnd('/') + "/" + (path ?? string.Empty).TrimStart('/');
        }

        public static string Combine(string baseUrl, params string[] pathSegments)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("baseUrl");
            }

            var result = baseUrl;

            if (pathSegments != null)
            {
                foreach (var pathSegment in pathSegments)
                {
                    result = Combine(result, pathSegment);
                }
            }

            return result;
        }

        public static Uri Combine(Uri baseUri, string path)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }

            if (baseUri.IsAbsoluteUri)
            {
                return new Uri(Combine(baseUri.AbsoluteUri, path), UriKind.Absolute);
            }
            else
            {
                return new Uri(Combine(baseUri.ToString(), path), UriKind.Relative);
            }
        }

        public static Uri Combine(Uri baseUri, params string[] pathSegments)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }

            if (baseUri.IsAbsoluteUri)
            {
                return new Uri(Combine(baseUri.AbsoluteUri, pathSegments), UriKind.Absolute);
            }
            else
            {
                return new Uri(Combine(baseUri.ToString(), pathSegments), UriKind.Relative);
            }
        }

        public static Uri Combine(Uri baseUri, Uri pathUri)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }

            if (pathUri != null)
            {
                return Combine(baseUri, pathUri.ToString());
            }
            else
            {
                return CopyUri(baseUri);
            }
        }

        public static Uri CopyUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (uri.IsAbsoluteUri)
            {
                return new Uri(uri.AbsoluteUri, UriKind.Absolute);
            }
            else
            {
                return new Uri(uri.ToString(), UriKind.Relative);
            }
        }

        public static string GetQueryStringParameterFromUri(Uri uri, string key)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            if (uri.IsAbsoluteUri)
            {
                return GetQueryStringParameterFromPathOrUrl(uri.AbsoluteUri, key);
            }
            else
            {
                return GetQueryStringParameterFromPathOrUrl(uri.ToString(), key);
            }
        }

        public static string GetQueryStringParameterFromPathOrUrl(string pathOrUrl, string key)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var result = GetQueryFromPathOrUrlAsNameValueCollection(pathOrUrl)[key];
            return result;
        }

        public static Uri SetUriScheme(Uri uri, string newScheme)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (newScheme == null)
            {
                throw new ArgumentNullException("newScheme");
            }

            if (string.IsNullOrEmpty(newScheme))
            {
                throw new ArgumentException("newScheme cannot be empty");
            }

            if (!uri.IsAbsoluteUri)
            {
                throw new InvalidOperationException("Uri must be absolute to set scheme.");
            }

            var builder = new UriBuilder(uri);
            builder.Scheme = newScheme;

            Uri result;

            if (uri.IsDefaultPort)
            {
                var resultUrl = builder.Uri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.UriEscaped);
                result = new Uri(resultUrl, UriKind.Absolute);
            }
            else
            {
                result = builder.Uri;
            }

            return result;


        }

        public static string SetUrlScheme(string url, string newScheme)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new InvalidOperationException("Uri must be absolute to set scheme.");
            }

            var uri = new Uri(url);
            var result = SetUriScheme(uri, newScheme).AbsoluteUri;
            return result;
        }

        public static Uri SetUriSchemeHttp(Uri uri)
        {
            return SetUriScheme(uri, "http");
        }

        public static string SetUrlSchemeHttp(string url)
        {
            return SetUrlScheme(url, "http");
        }

        public static Uri SetUriSchemeHttps(Uri uri)
        {
            return SetUriScheme(uri, "https");
        }

        public static string SetUrlSchemeHttps(string url)
        {
            return SetUrlScheme(url, "https");
        }

        public static Uri SetUriHost(Uri uri, string newHost)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (newHost == null)
            {
                throw new ArgumentNullException("newHost");
            }

            if (string.IsNullOrEmpty(newHost))
            {
                throw new ArgumentException("newHost cannot be empty");
            }

            if (!uri.IsAbsoluteUri)
            {
                throw new InvalidOperationException("Uri must be absolute to set host.");
            }

            var builder = new UriBuilder(uri);
            builder.Host = newHost;
            return builder.Uri;
        }

        public static Uri SetUriHost(Uri uri, string newHost, int? newPort)
        {
            var result = uri;
            result = SetUriHost(result, newHost);
            result = SetUriPort(result, newPort);
            return result;
        }

        public static string SetUrlHost(string url, string newHost)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new InvalidOperationException("Uri must be absolute to set host.");
            }

            var uri = new Uri(url);
            var result = SetUriHost(uri, newHost).AbsoluteUri;
            return result;
        }

        public static string SetUrlHost(string url, string newHost, int? newPort)
        {
            var result = url;
            result = SetUrlHost(result, newHost);
            result = SetUrlPort(result, newPort);
            return result;
        }

        public static Uri SetUriPort(Uri uri, int? newPort)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (!uri.IsAbsoluteUri)
            {
                throw new InvalidOperationException("Uri must be absolute to set port.");
            }

            Uri result;

            if (newPort.HasValue)
            {
                var builder = new UriBuilder(uri);
                builder.Port = newPort.Value;
                return builder.Uri;
            }
            else
            {
                var url = uri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.UriEscaped);
                result = new Uri(url, UriKind.Absolute);
            }

            return result;
        }

        public static string SetUrlPort(string url, int? newPort)
        {
            if (url == null)
            {
                throw new ArgumentNullException("newPort");
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new InvalidOperationException("Uri must be absolute to set port.");
            }

            var uri = new Uri(url);
            var result = SetUriPort(uri, newPort).AbsoluteUri;
            return result;
        }

        public static Uri SetUriPortHttp(Uri uri)
        {
            return SetUriPort(uri, 80);
        }

        public static string SetUrlPortHttp(string url)
        {
            return SetUrlPort(url, 80);
        }

        public static Uri SetUriPortHttps(Uri uri)
        {
            return SetUriPort(uri, 443);
        }

        public static string SetUrlPortHttps(string url)
        {
            return SetUrlPort(url, 443);
        }

        public static Uri SetUriPortDefault(Uri uri)
        {
            return SetUriPort(uri, null);
        }

        public static string SetUrlPortDefault(string url)
        {
            return SetUrlPort(url, null);
        }

        public static Uri SetUriQuery(Uri uri, NameValueCollection queryStringData)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (uri.IsAbsoluteUri)
            {
                return new Uri(SetUrlQuery(uri.AbsoluteUri, queryStringData), UriKind.Absolute);
            }
            else
            {
                return new Uri(SetUrlQuery(uri.ToString(), queryStringData), UriKind.Relative);
            }
        }

        public static string SetUrlQuery(string pathOrUrl, NameValueCollection queryStringData)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            var baseUrl = GetPathOrUrlWithoutQuery(pathOrUrl);

            var queryStringResult = (queryStringData != null && queryStringData.AllKeys.Length > 0)
				? "?" + CollectionUtility.ToPercentEncodedQueryString(queryStringData)
                : string.Empty;

            string result;

            if (Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute))
            {
                result = new Uri(baseUrl).AbsoluteUri + queryStringResult;
            }
            else
            {
                result = baseUrl + queryStringResult;
            }

            return result;
        }

        public static Uri AddUriQueryStringParameter<T>(Uri uri, string key, T value)
        {
            var valueString = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            return AddUriQueryStringParameter(uri, key, valueString);
        }

        public static Uri AddUriQueryStringParameter(Uri uri, string key, object value)
        {
            return AddUriQueryStringParameter<object>(uri, key, value);
        }

        public static Uri AddUriQueryStringParameter(Uri uri, string key, string value)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (uri.IsAbsoluteUri)
            {
                return new Uri(AddUrlQueryStringParameter(uri.AbsoluteUri, key, value), UriKind.Absolute);
            }
            else
            {
                return new Uri(AddUrlQueryStringParameter(uri.ToString(), key, value), UriKind.Relative);
            }
        }

        public static string AddUrlQueryStringParameter<T>(string pathOrUrl, string key, T value)
        {
            var valueString = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            return AddUrlQueryStringParameter(pathOrUrl, key, valueString);
        }

        public static string AddUrlQueryStringParameter(string pathOrUrl, string key, object value)
        {
            return AddUrlQueryStringParameter<object>(pathOrUrl, key, value);
        }

        public static string AddUrlQueryStringParameter(string pathOrUrl, string key, string value)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var query = GetQueryFromPathOrUrlAsNameValueCollection(pathOrUrl);
            query.Add(key, value);

            var result = SetUrlQuery(pathOrUrl, query);
            return result;
        }

        public static string SetUrlQueryStringParameter<T>(string pathOrUrl, string key, T value)
        {
            var valueString = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            return SetUrlQueryStringParameter(pathOrUrl, key, valueString);
        }

        public static string SetUrlQueryStringParameter(string pathOrUrl, string key, object value)
        {
            return SetUrlQueryStringParameter<object>(pathOrUrl, key, value);
        }

        public static string SetUrlQueryStringParameter(string pathOrUrl, string key, string value)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var query = GetQueryFromPathOrUrlAsNameValueCollection(pathOrUrl);
            query.Set(key, value);

            var result = SetUrlQuery(pathOrUrl, query);
            return result;
        }

        public static string RemoveUrlQueryStringParameter(string pathOrUrl, string key)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var query = GetQueryFromPathOrUrlAsNameValueCollection(pathOrUrl);
            query.Remove(key);

            var result = SetUrlQuery(pathOrUrl, query);
            return result;
        }

        public static Uri SetUriQueryStringParameter<T>(Uri uri, string key, T value)
        {
            var valueString = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            return SetUriQueryStringParameter(uri, key, valueString);
        }

        public static Uri SetUriQueryStringParameter(Uri uri, string key, object value)
        {
            return SetUriQueryStringParameter<object>(uri, key, value);
        }

        public static Uri SetUriQueryStringParameter(Uri uri, string key, string value)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (uri.IsAbsoluteUri)
            {
                return new Uri(SetUrlQueryStringParameter(uri.AbsoluteUri, key, value), UriKind.Absolute);
            }
            else
            {
                return new Uri(SetUrlQueryStringParameter(uri.ToString(), key, value), UriKind.Relative);
            }
        }

        public static Uri RemoveUriQueryStringParameter(Uri uri, string key)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (uri.IsAbsoluteUri)
            {
                return new Uri(RemoveUrlQueryStringParameter(uri.AbsoluteUri, key), UriKind.Absolute);
            }
            else
            {
                return new Uri(RemoveUrlQueryStringParameter(uri.ToString(), key), UriKind.Relative);
            }
        }

        public static Uri GetUriWithoutQuery(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (uri.IsAbsoluteUri)
            {
                return new Uri(GetPathOrUrlWithoutQuery(uri.AbsoluteUri), UriKind.Absolute);
            }
            else
            {
                return new Uri(GetPathOrUrlWithoutQuery(uri.ToString()), UriKind.Relative);
            }
        }

        public static string GetPathOrUrlWithoutQuery(string pathOrUrl)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            var queryStringStartPosition = pathOrUrl.IndexOf('?');

            var result = (queryStringStartPosition >= 0)
                ? pathOrUrl.Substring(0, queryStringStartPosition)
                : pathOrUrl;

            return result;
        }

        public static string GetQueryFromUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (uri.IsAbsoluteUri)
            {
                return GetQueryFromPathOrUrl(uri.AbsoluteUri);
            }
            else
            {
                return GetQueryFromPathOrUrl(uri.ToString());
            }
        }

        public static string GetQueryFromPathOrUrl(string pathOrUrl)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            var queryStringStartPosition = pathOrUrl.IndexOf('?');

            var result = (queryStringStartPosition >= 0)
                ? pathOrUrl.Substring(queryStringStartPosition + 1)
                : string.Empty;

            return result;
        }

        public static string GetFileNameWithoutQuery(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (uri.IsAbsoluteUri)
            {
                return GetFileNameWithoutQuery(uri.AbsoluteUri);
            }
            else
            {
                return GetFileNameWithoutQuery(uri.ToString());
            }
        }

        public static string GetFileNameWithoutQuery(string pathOrUrl)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            var urlWithoutQuery = GetPathOrUrlWithoutQuery(pathOrUrl);
            return GetFileNameAndQuery(urlWithoutQuery);
        }

        public static string GetFileNameAndQuery(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (uri.IsAbsoluteUri)
            {
                return GetFileNameAndQuery(uri.AbsoluteUri);
            }
            else
            {
                return GetFileNameAndQuery(uri.ToString());
            }
        }

        public static string GetFileNameAndQuery(string pathOrUrl)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            var lastSlashPosition = pathOrUrl.LastIndexOf('/');

            if (lastSlashPosition >= 0)
            {
                return pathOrUrl.Substring(lastSlashPosition + 1);
            }
            else
            {
                throw new ArgumentException("Unable to parse path or url directory from file name.");
            }
        }

        public static Uri GetUriWithoutFileNameAndQuery(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (uri.IsAbsoluteUri)
            {
                return new Uri(GetPathOrUrlWithoutFileNameAndQuery(uri.AbsoluteUri), UriKind.Absolute);
            }
            else
            {
                return new Uri(GetPathOrUrlWithoutFileNameAndQuery(uri.ToString()), UriKind.Relative);
            }
        }

        public static string GetPathOrUrlWithoutFileNameAndQuery(string pathOrUrl)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            var lastSlashPosition = pathOrUrl.LastIndexOf('/');

            if (lastSlashPosition >= 0)
            {
                return pathOrUrl.Substring(0, lastSlashPosition + 1);
            }
            else
            {
                throw new ArgumentException("Unable to parse path or url directory from file name.");
            }
        }

        public static NameValueCollection GetQueryFromPathOrUrlAsNameValueCollection(string pathOrUrl)
        {
            if (pathOrUrl == null)
            {
                throw new ArgumentNullException("pathOrUrl");
            }

            var query = GetQueryFromPathOrUrl(pathOrUrl);
			return InternalScabHelpers.ParseQueryString(query);
        }

        public static NameValueCollection GetQueryFromUriAsNameValueCollection(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            var query = GetQueryFromUri(uri);
			return InternalScabHelpers.ParseQueryString(query);
        }

		private static readonly Regex percentEncoderRegex = new Regex(@"[^A-Za-z0-9_.~]", RegexOptions.Compiled | RegexOptions.CultureInvariant);
		public static string PercentEncode(string value)
		{
            if (value != null)
            {
                return percentEncoderRegex.Replace(value, PercentEncoderMatchEvaluator);
            }
            else
            {
                return null;
            }
		}

		private static readonly Regex percentEncoderPathRegex = new Regex(@"[^A-Za-z0-9_.~/]", RegexOptions.Compiled | RegexOptions.CultureInvariant);
		public static string PercentEncodePath(string value)
		{
			if (value != null)
            {
                return percentEncoderPathRegex.Replace(value, PercentEncoderMatchEvaluator);
            }
            else
            {
                return null;
            }
		}

		private static string PercentEncoderMatchEvaluator(Match match)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(match.Value);

			StringBuilder encoded = new StringBuilder();
			foreach (byte b in bytes)
			{
				encoded.AppendFormat("%{0:X2}", b);
			}

			return encoded.ToString();
		}
    }
}
