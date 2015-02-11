using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace jaytwo.Common.Futures.Http
{
	public static class HttpAuthentication
	{
		public static HttpWebRequest CreateAuthenticatedRequest(HttpWebResponse unauthorizedResponse, string username, string password)
		{
			var authenticationMethod = GetAuthenticationHeaderMethod(unauthorizedResponse);

			switch (authenticationMethod.ToLowerInvariant())
			{
				case "basic":
					return CreateAuthenticatedRequestBasic(unauthorizedResponse, username, password);

				case "digest":
					return CreateAuthenticatedRequestDigest(unauthorizedResponse, username, password);

				default:
					throw new NotSupportedException("Unknown authentication method: " + authenticationMethod);
			}
		}

		public static HttpWebRequest CreateAuthenticatedRequestBasic(HttpWebResponse unauthorizedResponse, string username, string password)
		{
			var authenticationMethod = GetAuthenticationHeaderMethod(unauthorizedResponse);
			if (!authenticationMethod.Equals("Basic", StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException("Invalid authentication method: " + authenticationMethod);
			}

			var request = unauthorizedResponse.ResponseUri
				.CreateHttpWebRequest()
				.WithBasicAuthentication(username, password);

			return request;
		}

		public static HttpWebRequest CreateAuthenticatedRequestDigest(HttpWebResponse unauthorizedResponse, string username, string password)
		{
			var digestAuthenticatedRequestHeader = DigestAuthentication.GetDigestAuthenticatedRequestHeader(
				unauthorizedResponse: unauthorizedResponse,
				username: username,
				password: password);

			var result = unauthorizedResponse.ResponseUri.CreateHttpWebRequest();
			result.Headers["Authorization"] = digestAuthenticatedRequestHeader;

			return result;
		}

		public static string GetAuthenticationHeader(HttpWebResponse httpResponse)
		{
			var unauthorizedResponseHeaders = httpResponse.Headers;
			return GetAuthenticationHeader(unauthorizedResponseHeaders);
		}

		public static string GetAuthenticationHeader(WebHeaderCollection httpResponseHeaders)
		{
			var wwwAuthenticateHeader = httpResponseHeaders["WWW-Authenticate"];
			return wwwAuthenticateHeader;
		}

		public static NameValueCollection GetAuthenticationHeaderParameters(HttpWebResponse httpResponse)
		{
			var wwwAuthenticateHeader = GetAuthenticationHeader(httpResponse);
			return GetAuthenticationHeaderParameters(wwwAuthenticateHeader);
		}

		public static NameValueCollection GetAuthenticationHeaderParameters(WebHeaderCollection httpResponseHeaders)
		{
			var wwwAuthenticateHeader = GetAuthenticationHeader(httpResponseHeaders);
			return GetAuthenticationHeaderParameters(wwwAuthenticateHeader);
		}

		private const string headerMethodDataRegexPattern =
@"^
\s*
(?<METHOD>\S+)
\s+
(?<VALUES>.*)
\s*
$";

		private static readonly Regex headerMethodDataRegex = new Regex(headerMethodDataRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

		private const string headerDataKeyValueRegexPattern =
@"(?<KEY>\S+)
\s*[=]\s*
(
  ([""](?<VALUE>[^""]*)[""])
  |
  (?<VALUE>[^""\s]+)
)";

		private static readonly Regex headerDataKeyValueRegex = new Regex(headerDataKeyValueRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

		public static NameValueCollection GetAuthenticationHeaderParameters(string wwwAuthenticateHeader)
		{
			var result = new NameValueCollection();

			var headerDataString = headerMethodDataRegex.Match(wwwAuthenticateHeader).Groups["VALUES"].Value;
			var keyValueMatches = headerDataKeyValueRegex.Matches(headerDataString);

			foreach (Match keyValueMatch in keyValueMatches)
			{
				var key = keyValueMatch.Groups["KEY"].Value;
				var value = keyValueMatch.Groups["VALUE"].Value;

				result[key] = value;
			}

			return result;
		}

		public static string GetAuthenticationHeaderMethod(HttpWebResponse httpResponse)
		{
			var wwwAuthenticateHeader = GetAuthenticationHeader(httpResponse);
			return GetAuthenticationHeaderMethod(wwwAuthenticateHeader);
		}

		public static string GetAuthenticationHeaderMethod(WebHeaderCollection httpResponseHeaders)
		{
			var wwwAuthenticateHeader = GetAuthenticationHeader(httpResponseHeaders);
			return GetAuthenticationHeaderMethod(wwwAuthenticateHeader);
		}

		public static string GetAuthenticationHeaderMethod(string wwwAuthenticateHeader)
		{
			var match = headerMethodDataRegex.Match(wwwAuthenticateHeader);
			return match.Groups["METHOD"].Value;
		}
	}
}
