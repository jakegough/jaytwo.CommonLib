using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;
using System.Text.RegularExpressions;

namespace jaytwo.Common.Test.Extensions
{
    [TestFixture]
    public static class StringExtensionsTest
    {
        public static IEnumerable<TestCaseData> StringExtensions_HtmlEncode_TestCases()
        {
            yield return new TestCaseData(null).Returns(null);
            yield return new TestCaseData(string.Empty).Returns(string.Empty);
            yield return new TestCaseData("hello < world").Returns("hello &lt; world");
        }

        [Test]
        [TestCaseSource("StringExtensions_HtmlEncode_TestCases")]
        public static string StringExtensions_HtmlEncode(string value)
        {
            return value.HtmlEncode();
        }

        public static IEnumerable<TestCaseData> StringExtensions_HtmlDecode_TestCases()
        {
            yield return new TestCaseData(null).Returns(null);
            yield return new TestCaseData(string.Empty).Returns(string.Empty);
            yield return new TestCaseData("hello &lt; world").Returns("hello < world");
        }

        [Test]
        [TestCaseSource("StringExtensions_HtmlDecode_TestCases")]
        public static string StringExtensions_HtmlDecode(string value)
        {
            return value.HtmlDecode();
        }

        public static IEnumerable<TestCaseData> StringExtensions_PercentEncode_TestCases()
        {
            yield return new TestCaseData(null).Returns(null);
            yield return new TestCaseData(string.Empty).Returns(string.Empty);
            yield return new TestCaseData("hello & world").Returns("hello%20%26%20world");
        }

        [Test]
        [TestCaseSource("StringExtensions_PercentEncode_TestCases")]
        public static string StringExtensions_PercentEncode(string value)
        {
            return value.PercentEncode();
        }

        public static IEnumerable<TestCaseData> StringExtensions_UrlDecode_TestCases()
        {
            yield return new TestCaseData(null).Returns(null);
            yield return new TestCaseData(string.Empty).Returns(string.Empty);
            yield return new TestCaseData("hello%20%26%20world").Returns("hello & world");
        }

        [Test]
        [TestCaseSource("StringExtensions_UrlDecode_TestCases")]
        public static string StringExtensions_UrlDecode(string value)
        {
            return value.UrlDecode();
        }

        public static IEnumerable<TestCaseData> StringExtensions_RegexReplace_TestCases()
        {
            yield return new TestCaseData(null, "", "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(string.Empty, "[eo]", "_").Returns(string.Empty);
            yield return new TestCaseData("hello world", "[eo]","_").Returns("h_ll_ w_rld");
        }

        [Test]
        [TestCaseSource("StringExtensions_RegexReplace_TestCases")]
        public static string StringExtensions_RegexReplace(string value, string pattern, string replacement)
        {
            return value.RegexReplace(pattern, replacement);
        }

        [Test]
        [TestCaseSource("StringExtensions_RegexReplace_TestCases")]
        public static string StringExtensions_RegexReplace_with_RegexOptions(string value, string pattern, string replacement)
        {
            return value.RegexReplace(pattern, replacement, RegexOptions.None);
        }

        public static IEnumerable<TestCaseData> StringExtensions_RegexSplit_TestCases()
        {
            yield return new TestCaseData(null, "").Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(string.Empty, "\\s+").Returns(new[] { string.Empty });
            yield return new TestCaseData("hello world", "\\s+").Returns(new[] { "hello", "world" });
        }

        [Test]
        [TestCaseSource("StringExtensions_RegexSplit_TestCases")]
        public static string[] StringExtensions_RegexSplit(string value, string pattern)
        {
            return value.RegexSplit(pattern);
        }

        [Test]
        [TestCaseSource("StringExtensions_RegexSplit_TestCases")]
        public static string[] StringExtensions_RegexSplit_with_RegexOptions(string value, string pattern)
        {
            return value.RegexSplit(pattern, RegexOptions.None);
        }
    }
}
