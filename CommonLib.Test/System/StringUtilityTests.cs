using jaytwo.Common.System;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;

namespace jaytwo.Common.Test.System
{
	[TestFixture]
	public static class StringUtilityTests
	{
        public static IEnumerable<TestCaseData> StringUtility_RemoveDiacritics_TestCases()
        {
            yield return new TestCaseData("áíóúý").Returns("aiouy");
            yield return new TestCaseData("ñâ").Returns("na");
        }

		[Test]
        [TestCaseSource("StringUtility_RemoveDiacritics_TestCases")]
		public static string StringUtility_RemoveDiacritics(string value)
		{
            return StringUtility.RemoveDiacritics(value);
		}

        [Test]
        [TestCaseSource("StringUtility_RemoveDiacritics_TestCases")]
        public static string StringExtensions_RemoveDiacritics(string value)
        {
            return value.RemoveDiacritics();
        }

        public static IEnumerable<TestCaseData> StringUtility_NormalizeWhiteSpace_TestCases()
        {
            yield return new TestCaseData(null).Returns(null);
            yield return new TestCaseData(string.Empty).Returns(string.Empty);
            yield return new TestCaseData(" ").Returns(string.Empty);
            yield return new TestCaseData("           ").Returns(string.Empty);
            yield return new TestCaseData(" a    ").Returns("a");
            yield return new TestCaseData(
@"hello     world

blah		tab
skipped one line").Returns("hello world blah tab skipped one line");
        }

		[Test]
        [TestCaseSource("StringUtility_NormalizeWhiteSpace_TestCases")]
        public static string StringUtility_NormalizeWhiteSpace(string value)
		{
            return StringUtility.NormalizeWhiteSpace(value);
		}

        [Test]
        [TestCaseSource("StringUtility_NormalizeWhiteSpace_TestCases")]
        public static string StringExtensions_NormalizeWhiteSpace(string value)
        {
            return value.NormalizeWhiteSpace();
        }
	}
}
