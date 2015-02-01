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
		private static IEnumerable<TestCaseData> ParseInt32AllTestValues()
		{
			yield return new TestCaseData("2147483647").Returns(2147483647);
			yield return new TestCaseData("-2147483648").Returns(-2147483648);
			yield return new TestCaseData("2147483648").Throws(typeof(OverflowException));
			yield return new TestCaseData("-2147483649").Throws(typeof(OverflowException));

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

		private static IEnumerable<TestCaseData> ParseInt32GoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseInt32AllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseInt32BadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseInt32AllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseInt32BadTestValues()
		{
			foreach (var testCase in ParseInt32BadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseInt32_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseInt32AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseInt32_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseInt32AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseInt32_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseInt32AllTestValues());
		}

		[Test]
		[TestCaseSource("ParseInt32GoodTestValues")]
		public int ParseUtility_ParseInt32(string stringValue)
		{
			return ParseUtility.ParseInt32(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseInt32BadTestValues")]
		public int ParseUtility_ParseInt32_Exceptions(string stringValue)
		{
			return ParseUtility.ParseInt32(stringValue);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_formatProvider_GoodTestValues")]
		public int ParseUtility_ParseInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt32(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_GoodTestValues")]
		public int ParseUtility_ParseInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseInt32(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_formatProvider_GoodTestValues")]
		public int ParseUtility_ParseInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt32(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt32GoodTestValues")]
		[TestCaseSource("TryParseInt32BadTestValues")]
		public int? ParseUtility_TryParseInt32(string stringValue)
		{
			return ParseUtility.TryParseInt32(stringValue);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_formatProvider_GoodTestValues")]
		public int? ParseUtility_TryParseInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt32(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_GoodTestValues")]
		public int? ParseUtility_TryParseInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseInt32(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_formatProvider_GoodTestValues")]
		public int? ParseUtility_TryParseInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt32(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt32GoodTestValues")]
		public int StringExtensions_ParseInt32(string stringValue)
		{
			return stringValue.ParseInt32();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseInt32BadTestValues")]
		public int StringExtensions_ParseInt32_Exceptions(string stringValue)
		{
			return stringValue.ParseInt32();
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_formatProvider_GoodTestValues")]
		public int StringExtensions_ParseInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseInt32(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_GoodTestValues")]
		public int StringExtensions_ParseInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseInt32(styles);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_formatProvider_GoodTestValues")]
		public int StringExtensions_ParseInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseInt32(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt32GoodTestValues")]
		[TestCaseSource("TryParseInt32BadTestValues")]
		public int? StringExtensions_TryParseInt32(string stringValue)
		{
			return stringValue.TryParseInt32();
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_formatProvider_GoodTestValues")]
		public int? StringExtensions_TryParseInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseInt32(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_styles_GoodTestValues")]
		public int? StringExtensions_TryParseInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseInt32(styles);
		}

		[Test]
		[TestCaseSource("ParseInt32_With_formatProvider_GoodTestValues")]
		public int? StringExtensions_TryParseInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseInt32(formatProvider);
		}
	}
}
