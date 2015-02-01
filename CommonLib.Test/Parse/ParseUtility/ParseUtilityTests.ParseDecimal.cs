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
		private static IEnumerable<TestCaseData> ParseDecimalAllTestValues()
		{
			yield return new TestCaseData("79228162514264337593543950335").Returns(79228162514264337593543950335m);
			yield return new TestCaseData("-79228162514264337593543950335").Returns(-79228162514264337593543950335m);
			yield return new TestCaseData("79228162514264337593543950336").Throws(typeof(OverflowException));
			yield return new TestCaseData("-79228162514264337593543950336").Throws(typeof(OverflowException));
			
			yield return new TestCaseData("0").Returns(0);
			yield return new TestCaseData("123.45").Returns(123.45);
			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
			yield return new TestCaseData("").Throws(typeof(FormatException));
			yield return new TestCaseData("foo").Throws(typeof(FormatException));
			yield return new TestCaseData("$123.45", NumberStyles.Currency).Returns(123.45);
			yield return new TestCaseData("123.45", NumberStyles.Number).Returns(123.45);
			yield return new TestCaseData("123,45", new CultureInfo("pt-BR")).Returns(123.45);
			yield return new TestCaseData("123.45", new CultureInfo("en-US")).Returns(123.45);
			yield return new TestCaseData("R$123,45", NumberStyles.Currency, new CultureInfo("pt-BR")).Returns(123.45);
			yield return new TestCaseData("$123.45", NumberStyles.Currency, new CultureInfo("en-US")).Returns(123.45);
		}

		private static IEnumerable<TestCaseData> ParseDecimalGoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseDecimalAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseDecimalBadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseDecimalAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseDecimalBadTestValues()
		{
			foreach (var testCase in ParseDecimalBadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseDecimal_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseDecimalAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseDecimal_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseDecimalAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseDecimal_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseDecimalAllTestValues());
		}

		[Test]
		[TestCaseSource("ParseDecimalGoodTestValues")]
		public decimal ParseUtility_ParseDecimal(string stringValue)
		{
			return ParseUtility.ParseDecimal(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseDecimalBadTestValues")]
		public decimal ParseUtility_ParseDecimal_Exceptions(string stringValue)
		{
			return ParseUtility.ParseDecimal(stringValue);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_formatProvider_GoodTestValues")]
		public decimal ParseUtility_ParseDecimal_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDecimal(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_GoodTestValues")]
		public decimal ParseUtility_ParseDecimal_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseDecimal(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_formatProvider_GoodTestValues")]
		public decimal ParseUtility_ParseDecimal_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDecimal(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDecimalGoodTestValues")]
		[TestCaseSource("TryParseDecimalBadTestValues")]
		public decimal? ParseUtility_TryParseDecimal(string stringValue)
		{
			return ParseUtility.TryParseDecimal(stringValue);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_formatProvider_GoodTestValues")]
		public decimal? ParseUtility_TryParseDecimal_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDecimal(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_GoodTestValues")]
		public decimal? ParseUtility_TryParseDecimal_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseDecimal(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_formatProvider_GoodTestValues")]
		public decimal? ParseUtility_TryParseDecimal_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDecimal(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDecimalGoodTestValues")]
		public decimal StringExtensions_ParseDecimal(string stringValue)
		{
			return stringValue.ParseDecimal();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseDecimalBadTestValues")]
		public decimal StringExtensions_ParseDecimal_Exceptions(string stringValue)
		{
			return stringValue.ParseDecimal();
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_formatProvider_GoodTestValues")]
		public decimal StringExtensions_ParseDecimal_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseDecimal(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_GoodTestValues")]
		public decimal StringExtensions_ParseDecimal_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseDecimal(styles);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_formatProvider_GoodTestValues")]
		public decimal StringExtensions_ParseDecimal_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseDecimal(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDecimalGoodTestValues")]
		[TestCaseSource("TryParseDecimalBadTestValues")]
		public decimal? StringExtensions_TryParseDecimal(string stringValue)
		{
			return stringValue.TryParseDecimal();
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_formatProvider_GoodTestValues")]
		public decimal? StringExtensions_TryParseDecimal_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseDecimal(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_styles_GoodTestValues")]
		public decimal? StringExtensions_TryParseDecimal_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseDecimal(styles);
		}

		[Test]
		[TestCaseSource("ParseDecimal_With_formatProvider_GoodTestValues")]
		public decimal? StringExtensions_TryParseDecimal_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseDecimal(formatProvider);
		}
	}
}
