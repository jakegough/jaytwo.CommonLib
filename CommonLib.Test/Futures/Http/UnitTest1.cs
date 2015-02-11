using System;
using System.Collections.Specialized;
using jaytwo.Common.Futures.Http;
using NUnit.Framework;

namespace jaytwo.Common.Test.Futures.Http
{
	[TestFixture]
	public class UnitTest1
	{
		
		[Test]
		public void HttpAuthentication_GetAuthenticationHeaderParameters()
		{
			var expected = new NameValueCollection()
			{
				{ "realm", "testrealm@host.com"},
				{ "qop", "auth"},
				{ "nonce", "dcd98b7102dd2f0e8b11d0f600bfb0c093"},
			};

			var headerValue = "Digest realm=\"testrealm@host.com\", qop=\"auth\", nonce=\"dcd98b7102dd2f0e8b11d0f600bfb0c093\" ";
			var actual = HttpAuthentication.GetAuthenticationHeaderParameters(headerValue);

			CollectionAssert.AreEquivalent(expected, actual);
		}

		[Test]
		public void HttpAuthentication_GetAuthenticationHeaderMethod()
		{
			var expected = "Digest";

			var headerValue = "Digest realm=\"testrealm@host.com\", qop=\"auth\", nonce=\"dcd98b7102dd2f0e8b11d0f600bfb0c093\" ";
			var actual = HttpAuthentication.GetAuthenticationHeaderMethod(headerValue);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void DigestAuthentication_GetDigestAuthenticationHA1Part()
		{
			var expected = "939e7578ed9e3c518a452acee763bce9";
			var actual = DigestAuthentication.GetDigestAuthenticationHA1Part("Mufasa", "testrealm@host.com", "Circle Of Life");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void DigestAuthentication_GetDigestAuthenticationHA2Part()
		{
			var expected = "39aff3a2bab6126f332b942af96d3366";
			var actual = DigestAuthentication.GetDigestAuthenticationHA2Part("GET", "/dir/index.html");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void DigestAuthentication_GetGetDigestAuthenticationResponsePart()
		{
			var expected = "6629fae49393a05397450978507c4ef1";

			var ha1 = DigestAuthentication.GetDigestAuthenticationHA1Part("Mufasa", "testrealm@host.com", "Circle Of Life");
			var ha2 = DigestAuthentication.GetDigestAuthenticationHA2Part("GET", "/dir/index.html");
			var nonce = "dcd98b7102dd2f0e8b11d0f600bfb0c093";
			var nonceCount = "00000001";
			var clientNonce = "0a4f113b";
			var qop = "auth";

			var actual = DigestAuthentication.GetGetDigestAuthenticationResponsePart(ha1, nonce, nonceCount, clientNonce, qop, ha2);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void DigestAuthentication_GetGetDigestAuthenticationResponsePart_tivo()
		{
			var expected = "54e62d6b3f3b02b28d6e1154bd87f14b";

			var ha1 = DigestAuthentication.GetDigestAuthenticationHA1Part("tivo", "TiVo DVR", "123456789");
			var ha2 = DigestAuthentication.GetDigestAuthenticationHA2Part("GET", "/TiVoConnect?AnchorOffset=0&Command=QueryContainer&Details=All&ItemCount=1");
			var nonce = "EEEC82F85D28D0EA";
			var nonceCount = "00000001";
			var clientNonce = "a0bdc66f82835c23";
			var qop = "auth";

			var actual = DigestAuthentication.GetGetDigestAuthenticationResponsePart(ha1, nonce, nonceCount, clientNonce, qop, ha2);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void DigestAuthentication_GetDigestAuthenticatedRequestHeader_tivo()
		{
			var uri = "/TiVoConnect?AnchorOffset=0&Command=QueryContainer&Details=All&ItemCount=1";
			var realm = "TiVo DVR";			
			var algorithm = "";
			var qop = "auth";
			var nonce = "EEEC82F85D28D0EA";
			var nonceCount = "00000003";
			var clientNonce = "ace02068914eb2eb";
			var username = "tivo";
			var password = "123456789";
			var verb = "GET";

			var actual = DigestAuthentication.GetDigestAuthenticatedRequestHeader(algorithm, uri, verb, realm, nonce, nonceCount, clientNonce, qop, username, password);
			var expected = "Digest username=\"tivo\", realm=\"TiVo DVR\", nonce=\"EEEC82F85D28D0EA\", uri=\"/TiVoConnect?AnchorOffset=0&Command=QueryContainer&Details=All&ItemCount=1\", response=\"8bbf30ad47bea96e782e797d6920c68b\", qop=auth, nc=00000003, cnonce=\"ace02068914eb2eb\"";

			Assert.AreEqual(expected, actual);
		}
	}
}
