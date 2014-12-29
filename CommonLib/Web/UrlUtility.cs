using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using jaytwo.CommonLib.ExtensionMethods;
using System.Collections.Specialized;
using System.Globalization;

namespace jaytwo.CommonLib.Web
{
	public static class UrlUtility
	{
		public static string Combine(string rootUrl, string path)
		{
			if (string.IsNullOrWhiteSpace(rootUrl))
			{
				throw new ArgumentNullException("rootUrl");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			return rootUrl.TrimEnd('/') + "/" + (path ?? string.Empty).TrimStart('/');
		}

		public static string Combine(string rootUrl, params string[] pathSegments)
		{
			if (string.IsNullOrWhiteSpace(rootUrl))
			{
				throw new ArgumentNullException("rootUrl");
			}

			if (pathSegments == null)
			{
				throw new ArgumentNullException("pathSegments");
			}

			var result = rootUrl;

			foreach (var pathSegment in pathSegments)
			{
				result = Combine(result, pathSegment);
			}

			return result;
		}

		public static Uri Combine(Uri rootUri, string path)
		{
			if (rootUri == null)
			{
				throw new ArgumentNullException("rootUri");
			}

			if (string.IsNullOrWhiteSpace(path))
			{
				throw new ArgumentNullException("path");
			}

			if (rootUri.IsAbsoluteUri)
			{
				return new Uri(Combine(rootUri.AbsoluteUri, path), UriKind.Absolute);
			}
			else
			{
				return new Uri(Combine(rootUri.ToString(), path), UriKind.Relative);
			}
		}

		public static Uri Combine(Uri rootUri, params string[] pathSegments)
		{
			if (rootUri == null)
			{
				throw new ArgumentNullException("rootUri");
			}

			if (pathSegments == null)
			{
				throw new ArgumentNullException("pathSegments");
			}

			if (rootUri.IsAbsoluteUri)
			{
				return new Uri(Combine(rootUri.AbsoluteUri, pathSegments), UriKind.Absolute);
			}
			else
			{
				return new Uri(Combine(rootUri.ToString(), pathSegments), UriKind.Relative);
			}
		}

		public static Uri Combine(Uri rootUri, Uri pathUri)
		{
			if (rootUri == null)
			{
				throw new ArgumentNullException("rootUri");
			}

			if (pathUri == null)
			{
				throw new ArgumentNullException("pathUri");
			}

			return Combine(rootUri, pathUri.ToString());
		}

		private static readonly Regex percentEncoderRegex = new Regex(@"[^A-Za-z0-9_.~]", RegexOptions.Compiled | RegexOptions.CultureInvariant);
		public static string PercentEncode(string value)
		{
			return percentEncoderRegex.Replace(value, PercentEncoderMatchEvaluator);
		}

		private static readonly Regex percentEncoderPathRegex = new Regex(@"[^A-Za-z0-9_.~/]", RegexOptions.Compiled | RegexOptions.CultureInvariant);
		public static string PercentEncodePath(string value)
		{
			return percentEncoderPathRegex.Replace(value, PercentEncoderMatchEvaluator);
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

			if (string.IsNullOrWhiteSpace(newScheme))
			{
				throw new ArgumentNullException("newScheme cannot be empty");
			}

			if (!uri.IsAbsoluteUri)
			{
				throw new InvalidOperationException("Uri must be absolute to set scheme.");
			}

			var builder = new UriBuilder(uri);
			builder.Scheme = newScheme;
			return builder.Uri;
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

			if (string.IsNullOrWhiteSpace(newHost))
			{
				throw new ArgumentNullException("newHost cannot be empty");
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
			result = SetUriHost(uri, newHost);
			result = SetUriPort(uri, newPort);
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
			result = SetUrlHost(url, newHost);
			result = SetUrlPort(url, newPort);
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

			var queryStringResult = (queryStringData != null && queryStringData.AllKeys.Any())
				? "?" + queryStringData.ToPercentEncodedQueryString()
				: string.Empty;

			var result = baseUrl + queryStringResult;
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

			var query = GetQueryFromPathOrUrlAsNameValueCollection(pathOrUrl).AddValue(key, value);
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

			var query = GetQueryFromPathOrUrlAsNameValueCollection(pathOrUrl).SetValue(key, value);
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

			var query = GetQueryFromPathOrUrlAsNameValueCollection(pathOrUrl).RemoveValue(key);
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

		public static Uri GetApplicationUri(HttpContext context, string path)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			return GetApplicationUri(new HttpRequestWrapper(context.Request), path);
		}

		public static Uri GetApplicationUri(HttpRequest request, string path)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			return GetApplicationUri(new HttpRequestWrapper(request), path);
		}

		public static Uri GetApplicationUri(HttpRequestBase request, string path)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			string absolutePath;

			if (path.StartsWith("/"))
			{
				absolutePath = path;
			}
			else if (path.StartsWith("~/"))
			{
				absolutePath = Combine(request.ApplicationPath, path.Substring(2));
			}
			else
			{
				throw new ArgumentException("Path must be app relative (starts with '~/') or absolute (starts with '/').");
			}

			var uriBuilder = new UriBuilder();
			uriBuilder.Scheme = request.Url.Scheme;
			uriBuilder.Host = request.Url.Host;
			uriBuilder.Port = request.Url.Port;
			uriBuilder.Path = GetPathOrUrlWithoutQuery(absolutePath);
			uriBuilder.Query = GetQueryFromPathOrUrl(absolutePath);

			return uriBuilder.Uri;
		}

		public static string GetApplicationUrl(HttpContext context, string path)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			return GetApplicationUrl(new HttpRequestWrapper(context.Request), path);
		}

		public static string GetApplicationUrl(HttpRequest request, string path)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			return GetApplicationUrl(new HttpRequestWrapper(request), path);
		}

		public static string GetApplicationUrl(HttpRequestBase request, string path)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			return GetApplicationUri(request, path).AbsoluteUri;
		}

		public static Uri GetRootApplicationUri(HttpContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			return GetRootApplicationUri(new HttpRequestWrapper(context.Request));
		}

		public static Uri GetRootApplicationUri(HttpRequest request)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			return GetRootApplicationUri(new HttpRequestWrapper(request));
		}

		public static Uri GetRootApplicationUri(HttpRequestBase request)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			return GetApplicationUri(request, "~/");
		}

		public static string GetRootApplicationUrl(HttpContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			return GetRootApplicationUrl(new HttpRequestWrapper(context.Request));
		}

		public static string GetRootApplicationUrl(HttpRequest request)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			return GetRootApplicationUrl(new HttpRequestWrapper(request));
		}

		public static string GetRootApplicationUrl(HttpRequestBase request)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}

			return GetRootApplicationUri(request).AbsoluteUri;
		}

		public static string GetAppRelativePathWithTilde(string absolutePath)
		{
			return GetAppRelativePathWithTilde(HttpRuntime.AppDomainAppVirtualPath, absolutePath);
		}

		public static string GetAppRelativePathWithTilde(string appVirtualPath, string absolutePath)
		{
			if (appVirtualPath == null)
			{
				throw new ArgumentNullException("appVirtualPath");
			}

			if (absolutePath == null)
			{
				throw new ArgumentNullException("absolutePath");
			}

			var result = "~/" + GetAppRelativePathWithoutTilde(appVirtualPath, absolutePath);
			return result;
		}

		public static string GetAppRelativePathWithoutTilde(string path)
		{
			return GetAppRelativePathWithoutTilde(HttpRuntime.AppDomainAppVirtualPath, path);
		}

		public static string GetAppRelativePathWithoutTilde(string appVirtualPath, string path)
		{
			if (appVirtualPath == null)
			{
				throw new ArgumentNullException("appVirtualPath");
			}

			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			string absolutePath;

			if (path.StartsWith("/"))
			{
				absolutePath = path;
			}
			else if (path.StartsWith("~/"))
			{
				absolutePath = Combine(appVirtualPath, path.Substring(2));
			}
			else
			{
				throw new ArgumentException("Path must be app relative (starts with '~/') or absolute (starts with '/').");
			}

			appVirtualPath = appVirtualPath.TrimEnd('/') + "/";

			if (!absolutePath.StartsWith(appVirtualPath, StringComparison.InvariantCultureIgnoreCase))
			{
				var message = string.Format(CultureInfo.InvariantCulture, "absolutePath '{0}' does not belng to appVirtualPath '{1}'",
					absolutePath,
					appVirtualPath);

				throw new ArgumentException(message);
			}

			var result = absolutePath.Substring(appVirtualPath.Length);
			return result;
		}

		public static NameValueCollection GetQueryFromPathOrUrlAsNameValueCollection(string pathOrUrl)
		{
			if (pathOrUrl == null)
			{
				throw new ArgumentNullException("pathOrUrl");
			}

			var query = GetQueryFromPathOrUrl(pathOrUrl);
			return HttpUtility.ParseQueryString(query);
		}

		public static NameValueCollection GetQueryFromUriAsNameValueCollection(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}

			var query = GetQueryFromUri(uri);
			return HttpUtility.ParseQueryString(query);
		}
	}
}
