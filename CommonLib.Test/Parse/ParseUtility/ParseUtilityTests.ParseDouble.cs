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
		private static IEnumerable<TestCaseData> ParseDoubleAllTestValues()
		{
			yield return new TestCaseData("1.79769e+308").Returns(1.79769e+308);
			yield return new TestCaseData("-1.79769e+308").Returns(-1.79769e+308);
			yield return new TestCaseData("1.79769e+309").Throws(typeof(OverflowException));
			yield return new TestCaseData("-1.79769e+309").Throws(typeof(OverflowException));

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

		private static IEnumerable<TestCaseData> ParseDoubleGoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseDoubleAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseDoubleBadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseDoubleAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseDoubleBadTestValues()
		{
			foreach (var testCase in ParseDoubleBadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseDouble_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseDoubleAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseDouble_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseDoubleAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseDouble_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseDoubleAllTestValues());
		}

		[Test]
		[TestCaseSource("ParseDoubleGoodTestValues")]
		public double ParseUtility_ParseDouble(string stringValue)
		{
			return ParseUtility.ParseDouble(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseDoubleBadTestValues")]
		public double ParseUtility_ParseDouble_Exceptions(string stringValue)
		{
			return ParseUtility.ParseDouble(stringValue);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_formatProvider_GoodTestValues")]
		public double ParseUtility_ParseDouble_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDouble(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_GoodTestValues")]
		public double ParseUtility_ParseDouble_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseDouble(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_formatProvider_GoodTestValues")]
		public double ParseUtility_ParseDouble_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDouble(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDoubleGoodTestValues")]
		[TestCaseSource("TryParseDoubleBadTestValues")]
		public double? ParseUtility_TryParseDouble(string stringValue)
		{
			return ParseUtility.TryParseDouble(stringValue);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_formatProvider_GoodTestValues")]
		public double? ParseUtility_TryParseDouble_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDouble(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_GoodTestValues")]
		public double? ParseUtility_TryParseDouble_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseDouble(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_formatProvider_GoodTestValues")]
		public double? ParseUtility_TryParseDouble_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDouble(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDoubleGoodTestValues")]
		public double StringExtensions_ParseDouble(string stringValue)
		{
			return stringValue.ParseDouble();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseDoubleBadTestValues")]
		public double StringExtensions_ParseDouble_Exceptions(string stringValue)
		{
			return stringValue.ParseDouble();
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_formatProvider_GoodTestValues")]
		public double StringExtensions_ParseDouble_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseDouble(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_GoodTestValues")]
		public double StringExtensions_ParseDouble_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseDouble(styles);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_formatProvider_GoodTestValues")]
		public double StringExtensions_ParseDouble_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseDouble(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDoubleGoodTestValues")]
		[TestCaseSource("TryParseDoubleBadTestValues")]
		public double? StringExtensions_TryParseDouble(string stringValue)
		{
			return stringValue.TryParseDouble();
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_formatProvider_GoodTestValues")]
		public double? StringExtensions_TryParseDouble_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseDouble(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_styles_GoodTestValues")]
		public double? StringExtensions_TryParseDouble_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseDouble(styles);
		}

		[Test]
		[TestCaseSource("ParseDouble_With_formatProvider_GoodTestValues")]
		public double? StringExtensions_TryParseDouble_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseDouble(formatProvider);
		}
	}
}
