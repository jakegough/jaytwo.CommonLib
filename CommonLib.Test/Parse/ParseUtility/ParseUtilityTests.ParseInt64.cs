using jaytwo.Common.Extensions;
using jaytwo.Common.Parse;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jaytwo.Common.Test.Parse
{
	[TestFixture]
	public partial class ParseUtilityTests
	{	
		private static IEnumerable<TestCaseData> ParseInt64AllTestValues()
		{
			yield return new TestCaseData("9223372036854775807").Returns(9223372036854775807);
			yield return new TestCaseData("-9223372036854775808").Returns(-9223372036854775808);
			yield return new TestCaseData("9223372036854775808").Throws(typeof(OverflowException));
			yield return new TestCaseData("-9223372036854775809").Throws(typeof(OverflowException));

			yield return new TestCaseData("0").Returns(0);
			yield return new TestCaseData("123").Returns(123);
			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
			yield return new TestCaseData("").Throws(typeof(FormatException));
			yield return new TestCaseData("foo").Throws(typeof(FormatException));
			yield return new TestCaseData("123.45").Throws(typeof(OverflowException));
			yield return new TestCaseData("$123.00", NumberStyles.Currency).Returns(123);
			yield return new TestCaseData("123.00", NumberStyles.Number).Returns(123);
			yield return new TestCaseData("123,00", new CultureInfo("pt-BR")).Returns(123);
			yield return new TestCaseData("123.00", new CultureInfo("en-US")).Returns(123);
			yield return new TestCaseData("R$123,00", NumberStyles.Currency, new CultureInfo("pt-BR")).Returns(123);
			yield return new TestCaseData("$123.00", NumberStyles.Currency, new CultureInfo("en-US")).Returns(123);
		}

		private static IEnumerable<TestCaseData> ParseInt64GoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseInt64AllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseInt64BadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseInt64AllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseInt64BadTestValues()
		{
			foreach (var testCase in ParseInt64BadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseInt64_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseInt64AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseInt64_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseInt64AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseInt64_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseInt64AllTestValues());
		}

		[Test]
		[TestCaseSource("ParseInt64GoodTestValues")]
		public long ParseUtility_ParseInt64(string stringValue)
		{
			return ParseUtility.ParseInt64(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseInt64BadTestValues")]
		public long ParseUtility_ParseInt64_Exceptions(string stringValue)
		{
			return ParseUtility.ParseInt64(stringValue);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_formatProvider_GoodTestValues")]
		public long ParseUtility_ParseInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt64(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_GoodTestValues")]
		public long ParseUtility_ParseInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseInt64(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_formatProvider_GoodTestValues")]
		public long ParseUtility_ParseInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt64(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt64GoodTestValues")]
		[TestCaseSource("TryParseInt64BadTestValues")]
		public long? ParseUtility_TryParseInt64(string stringValue)
		{
			return ParseUtility.TryParseInt64(stringValue);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_formatProvider_GoodTestValues")]
		public long? ParseUtility_TryParseInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt64(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_GoodTestValues")]
		public long? ParseUtility_TryParseInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseInt64(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_formatProvider_GoodTestValues")]
		public long? ParseUtility_TryParseInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt64(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt64GoodTestValues")]
		public long StringExtensions_ParseInt64(string stringValue)
		{
			return stringValue.ParseInt64();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseInt64BadTestValues")]
		public long StringExtensions_ParseInt64_Exceptions(string stringValue)
		{
			return stringValue.ParseInt64();
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_formatProvider_GoodTestValues")]
		public long StringExtensions_ParseInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseInt64(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_GoodTestValues")]
		public long StringExtensions_ParseInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseInt64(styles);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_formatProvider_GoodTestValues")]
		public long StringExtensions_ParseInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseInt64(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt64GoodTestValues")]
		[TestCaseSource("TryParseInt64BadTestValues")]
		public long? StringExtensions_TryParseInt64(string stringValue)
		{
			return stringValue.TryParseInt64();
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_formatProvider_GoodTestValues")]
		public long? StringExtensions_TryParseInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseInt64(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt64_With_styles_GoodTestValues")]
		public long? StringExtensions_TryParseInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseInt64(styles);
		}

        [Test]
        [TestCaseSource("ParseInt64_With_formatProvider_GoodTestValues")]
        public long? StringExtensions_TryParseInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
        {
            return stringValue.TryParseInt64(formatProvider);
        }
	}
}
