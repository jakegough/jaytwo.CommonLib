using jaytwo.Common.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace jaytwo.Common.System
{
    public static class StringUtility
    {
        private static readonly Regex normalizeWhitespaceRegex = new Regex(@"[\s]{2,}", RegexOptions.Compiled);
        public static string NormalizeWhiteSpace(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return normalizeWhitespaceRegex.Replace(value, " ").Trim();
            }
            else
            {
                return value;
            }
        }

        public static string RemoveDiacritics(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                StringBuilder result = new StringBuilder();

                foreach (var charFormD in value.Normalize(NormalizationForm.FormD).ToCharArray())
                {
                    UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(charFormD);

                    if (category != UnicodeCategory.NonSpacingMark)
                    {
                        result.Append(charFormD);
                    }
                }

                return result.ToString().Normalize(NormalizationForm.FormC);
            }
            else
            {
                return value;
            }
        }
    }
}
