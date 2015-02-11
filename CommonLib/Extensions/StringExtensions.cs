using System.Text;
using System;
using System.Globalization;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using jaytwo.Common.Http;
using jaytwo.Common.System;
using jaytwo.Common.Appendix;

namespace jaytwo.Common.Extensions
{
	public static partial class StringExtensions
	{
		public static string HtmlDecode(this string value)
		{
			return InternalScabHelpers.HtmlDecode(value);
		}

		public static string HtmlEncode(this string value)
		{
			return InternalScabHelpers.HtmlEncode(value);
		}

		public static string UrlDecode(this string value)
		{
			return InternalScabHelpers.UrlDecode(value);
		}

		public static string PercentEncode(this string value)
		{
			return UrlHelper.PercentEncode(value);
		}

        public static string RegexReplace(this string input, string pattern, string replacement)
        {
			return RegexReplace(input, pattern, replacement, RegexOptions.None);
        }

        public static string RegexReplace(this string input, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, pattern, replacement, options);
        }

        public static string[] RegexSplit(this string input, string pattern)
        {
			return RegexSplit(input, pattern, RegexOptions.None);
        }

        public static string[] RegexSplit(this string input, string pattern, RegexOptions options)
        {
            return Regex.Split(input, pattern, options);
        }

        public static string NormalizeWhiteSpace(this string value)
        {
            return StringUtility.NormalizeWhiteSpace(value);
        }

        public static string RemoveDiacritics(this string value)
        {
            return StringUtility.RemoveDiacritics(value);
        }
	}
}