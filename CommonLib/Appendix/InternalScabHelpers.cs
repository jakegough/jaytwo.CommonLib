using jaytwo.Common.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace jaytwo.Common.Appendix
{
	internal static class InternalScabHelpers
	{		
		public static string SerializeToJson(object content)
		{
#if CLIENTPROFILE
			return new global::jaytwo.Common.Appendix.Mono.System.Web.Script.Serialization.JavaScriptSerializer().Serialize(content);
#else			
			return new global::System.Web.Script.Serialization.JavaScriptSerializer().Serialize(content);
#endif
		}

		public static T DeserializeJson<T>(string json)
		{
#if CLIENTPROFILE
			return new global::jaytwo.Common.Appendix.Mono.System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<T>(json);
#else
			return new global::System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<T>(json);
#endif
		}

		public static NameValueCollection ParseQueryString(string value)
		{
#if CLIENTPROFILE
			return global::jaytwo.Common.Appendix.Google.GData.Client.HttpUtility.ParseQueryString(value);
#else
			return global::System.Web.HttpUtility.ParseQueryString(value);
#endif
		}

		public static string HtmlEncode(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}
			else
			{
#if CLIENTPROFILE
				return global::jaytwo.Common.Appendix.Google.GData.Client.HttpUtility.HtmlEncode(value);
#else
				return global::System.Web.HttpUtility.HtmlEncode(value);
#endif
			}
		}

		public static string HtmlDecode(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}
			else
			{
#if CLIENTPROFILE
				return global::jaytwo.Common.Appendix.Google.GData.Client.HttpUtility.HtmlDecode(value);
#else
				return global::System.Web.HttpUtility.HtmlDecode(value); 
#endif
			}
		}

		public static string UrlDecode(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}
			else
			{
				return Uri.UnescapeDataString(value);
			}
		}
	}
}
