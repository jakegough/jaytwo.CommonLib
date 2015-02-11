using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;

namespace jaytwo.Common.Futures.Http
{
	public static class DigestAuthentication
	{
		public static string GetDigestAuthenticatedRequestHeader(HttpWebResponse unauthorizedResponse, string username, string password)
		{
			var httpResponseAuthenticationHeader = HttpAuthentication.GetAuthenticationHeader(unauthorizedResponse);
			var uri = unauthorizedResponse.ResponseUri.PathAndQuery;

			return GetDigestAuthenticatedRequestHeader(
				uri: uri,
				verb: unauthorizedResponse.Method,
				httpResponseAuthenticationHeader: httpResponseAuthenticationHeader,
				username: username,
				password: password);
		}

		public static string GetDigestAuthenticatedRequestHeader(string uri, string verb, WebHeaderCollection httpResponseHeaders, string username, string password)
		{
			var httpResponseAuthenticationHeader = HttpAuthentication.GetAuthenticationHeader(httpResponseHeaders);

			return GetDigestAuthenticatedRequestHeader(
				uri: uri,
				verb: verb,
				httpResponseAuthenticationHeader: httpResponseAuthenticationHeader,
				username: username,
				password: password);
		}

		public static string GetDigestAuthenticatedRequestHeader(string uri, string verb, string httpResponseAuthenticationHeader, string username, string password)
		{
			var authenticationMethod = HttpAuthentication.GetAuthenticationHeaderMethod(httpResponseAuthenticationHeader);
			if (!authenticationMethod.Equals("Digest", StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException("Invalid authentication method: " + authenticationMethod);
			}

			var authenticateHeaderParameters = HttpAuthentication.GetAuthenticationHeaderParameters(httpResponseAuthenticationHeader);
			var realm = authenticateHeaderParameters["realm"];
			var nonce = authenticateHeaderParameters["nonce"];
			var qop = authenticateHeaderParameters["qop"];
			var algorithm = authenticateHeaderParameters["algorithm"];

			var nonceCount = "0000001";
			var clientNonce = Guid.NewGuid().ToString();

			// TODO: based on algorithm and qop, we need to do different things
			//       http://en.wikipedia.org/wiki/Digest_access_authentication
			//      (apparently we're not alone... "Most browsers have substantially implemented the spec, some barring certain features such as auth-int checking or the MD5-sess algorithm")

			return GetDigestAuthenticatedRequestHeader(
				algorithm: algorithm,
				uri: uri,
				verb: verb,
				realm: realm,
				nonce: nonce,
				nonceCount: nonceCount,
				clientNonce: clientNonce,
				qop: qop,
				username: username,
				password: password);
		}

		public static string GetDigestAuthenticatedRequestHeader(string algorithm, string uri, string verb, string realm, string nonce, string nonceCount, string clientNonce, string qop, string username, string password)
		{
			string ha1;
			if (string.IsNullOrWhiteSpace(algorithm) || algorithm.Equals("MD5", StringComparison.OrdinalIgnoreCase))
			{
				ha1 = GetDigestAuthenticationHA1Part(username, realm, password);
			}
			else if (algorithm.Equals("MD5-sess", StringComparison.OrdinalIgnoreCase))
			{
				ha1 = GetDigestAuthenticationHA1Part(username, realm, password, nonce, clientNonce);
			}
			else
			{
				throw new NotSupportedException("Unsupported algorithm directive: " + algorithm);
			}

			string ha2;
			if (!string.IsNullOrWhiteSpace(qop) && qop.Equals("auth", StringComparison.OrdinalIgnoreCase))
			{
				ha2 = GetDigestAuthenticationHA2Part(verb, uri);
			}
			else
			{
				throw new NotSupportedException("Unsupported qop directive: " + qop);
			}

			string response;
			if (string.IsNullOrWhiteSpace(qop))
			{
				response = GetGetDigestAuthenticationResponsePart(ha1, ha2, nonce);
			}
			else if (qop.Equals("auth", StringComparison.OrdinalIgnoreCase) || qop.Equals("auth-int", StringComparison.OrdinalIgnoreCase))
			{
				response = GetGetDigestAuthenticationResponsePart(ha1, nonce, nonceCount, clientNonce, qop, ha2);
			}
			else
			{
				throw new NotSupportedException("Unsupported qop directive: " + qop);
			}

			var data = new[] {
				string.Format("username=\"{0}\"", username),
				string.Format("realm=\"{0}\"", realm),
				string.Format("nonce=\"{0}\"", nonce),
				string.Format("uri=\"{0}\"", uri),
				string.Format("response=\"{0}\"", response),
				string.Format("qop={0}", qop),
				string.Format("nc={0}", nonceCount),
				string.Format("cnonce=\"{0}\"", clientNonce),
			};

			var result = "Digest " + string.Join(", ", data);
			return result;
		}

		public static string GetDigestAuthenticationHA1Part(string username, string realm, string password)
		{
			var stringToHash = username + ":" + realm + ":" + password;
			return GetMd5(stringToHash);
		}

		public static string GetDigestAuthenticationHA1Part(string username, string realm, string password, string nonce, string clientNonce)
		{
			var ha1 = GetDigestAuthenticationHA1Part(username, realm, password);
			var stringToHash = ha1 + ":" + nonce + ":" + clientNonce;
			return GetMd5(stringToHash);
		}

		public static string GetDigestAuthenticationHA2Part(string method, string digestUri)
		{
			var stringToHash = method + ":" + digestUri;
			return GetMd5(stringToHash);
		}

		public static string GetGetDigestAuthenticationResponsePart(string ha1, string nonce, string nonceCount, string clientNonce, string qop, string ha2)
		{
			var stringToHash = ha1 + ":" + nonce + ":" + nonceCount + ":" + clientNonce + ":" + qop + ":" + ha2;
			return GetMd5(stringToHash);
		}

		public static string GetGetDigestAuthenticationResponsePart(string ha1, string ha2, string nonce)
		{
			var stringToHash = ha1 + ":" + nonce + ":" + ha2;
			return GetMd5(stringToHash);
		}

		public static string GetMd5(string stringToHash)
		{
			var hash = Encoding.UTF8.GetBytes(stringToHash).ComputeMD5Hash().AsHexString().ToLower();
			return hash;
		}
	}
}
