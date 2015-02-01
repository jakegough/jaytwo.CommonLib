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
		private static IEnumerable<TestCaseData> ParseSingleAllTestValues()
		{
			yield return new TestCaseData("3.40282e+038").Returns(3.40282e+038f);
			yield return new TestCaseData("-3.40282e+038").Returns(-3.40282e+038f);
			yield return new TestCaseData("3.40282e+039").Throws(typeof(OverflowException));
			yield return new TestCaseData("-3.40282e+039").Throws(typeof(OverflowException));

			yield return new TestCaseData("0").Returns(0f);
			yield return new TestCaseData("123.45").Returns(123.45f);
			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
			yield return new TestCaseData("").Throws(typeof(FormatException));
			yield return new TestCaseData("foo").Throws(typeof(FormatException));
			yield return new TestCaseData("$123.45", NumberStyles.Currency).Returns(123.45f);
			yield return new TestCaseData("123.45", NumberStyles.Number).Returns(123.45f);
			yield return new TestCaseData("123,45", new CultureInfo("pt-BR")).Returns(123.45f);
			yield return new TestCaseData("123.45", new CultureInfo("en-US")).Returns(123.45f);
			yield return new TestCaseData("R$123,45", NumberStyles.Currency, new CultureInfo("pt-BR")).Returns(123.45f);
			yield return new TestCaseData("$123.45", NumberStyles.Currency, new CultureInfo("en-US")).Returns(123.45f);
		}

		private static IEnumerable<TestCaseData> ParseSingleGoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseSingleAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseSingleBadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseSingleAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseSingleBadTestValues()
		{
			foreach (var testCase in ParseSingleBadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseSingle_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseSingleAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseSingle_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseSingleAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseSingle_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseSingleAllTestValues());
		}

		[Test]
		[TestCaseSource("ParseSingleGoodTestValues")]
		public float ParseUtility_ParseSingle(string stringValue)
		{
			return ParseUtility.ParseSingle(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseSingleBadTestValues")]
		public float ParseUtility_ParseSingle_Exceptions(string stringValue)
		{
			return ParseUtility.ParseSingle(stringValue);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_formatProvider_GoodTestValues")]
		public float ParseUtility_ParseSingle_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSingle(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_GoodTestValues")]
		public float ParseUtility_ParseSingle_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseSingle(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_formatProvider_GoodTestValues")]
		public float ParseUtility_ParseSingle_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSingle(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSingleGoodTestValues")]
		[TestCaseSource("TryParseSingleBadTestValues")]
		public float? ParseUtility_TryParseSingle(string stringValue)
		{
			return ParseUtility.TryParseSingle(stringValue);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_formatProvider_GoodTestValues")]
		public float? ParseUtility_TryParseSingle_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSingle(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_GoodTestValues")]
		public float? ParseUtility_TryParseSingle_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseSingle(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_formatProvider_GoodTestValues")]
		public float? ParseUtility_TryParseSingle_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSingle(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSingleGoodTestValues")]
		public float StringExtensions_ParseSingle(string stringValue)
		{
			return stringValue.ParseSingle();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseSingleBadTestValues")]
		public float StringExtensions_ParseSingle_Exceptions(string stringValue)
		{
			return stringValue.ParseSingle();
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_formatProvider_GoodTestValues")]
		public float StringExtensions_ParseSingle_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseSingle(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_GoodTestValues")]
		public float StringExtensions_ParseSingle_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseSingle(styles);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_formatProvider_GoodTestValues")]
		public float StringExtensions_ParseSingle_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseSingle(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSingleGoodTestValues")]
		[TestCaseSource("TryParseSingleBadTestValues")]
		public float? StringExtensions_TryParseSingle(string stringValue)
		{
			return stringValue.TryParseSingle();
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_formatProvider_GoodTestValues")]
		public float? StringExtensions_TryParseSingle_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseSingle(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_styles_GoodTestValues")]
		public float? StringExtensions_TryParseSingle_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseSingle(styles);
		}

		[Test]
		[TestCaseSource("ParseSingle_With_formatProvider_GoodTestValues")]
		public float? StringExtensions_TryParseSingle_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseSingle(formatProvider);
		}
	}
}
