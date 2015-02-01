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
		private static IEnumerable<TestCaseData> ParseInt16AllTestValues()
		{
			yield return new TestCaseData("32767").Returns((short)32767);
			yield return new TestCaseData("-32768").Returns(-32768);
			yield return new TestCaseData("32768").Throws(typeof(OverflowException));
			yield return new TestCaseData("-32769").Throws(typeof(OverflowException));

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

		private static IEnumerable<TestCaseData> ParseInt16GoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseInt16AllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseInt16BadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseInt16AllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseInt16BadTestValues()
		{
			foreach (var testCase in ParseInt16BadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseInt16_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseInt16AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseInt16_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseInt16AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseInt16_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseInt16AllTestValues());
		}

		[Test]
		[TestCaseSource("ParseInt16GoodTestValues")]
		public short ParseUtility_ParseInt16(string stringValue)
		{
			return ParseUtility.ParseInt16(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseInt16BadTestValues")]
		public short ParseUtility_ParseInt16_Exceptions(string stringValue)
		{
			return ParseUtility.ParseInt16(stringValue);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_formatProvider_GoodTestValues")]
		public short ParseUtility_ParseInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt16(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_GoodTestValues")]
		public short ParseUtility_ParseInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseInt16(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_formatProvider_GoodTestValues")]
		public short ParseUtility_ParseInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseInt16(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt16GoodTestValues")]
		[TestCaseSource("TryParseInt16BadTestValues")]
		public short? ParseUtility_TryParseInt16(string stringValue)
		{
			return ParseUtility.TryParseInt16(stringValue);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_formatProvider_GoodTestValues")]
		public short? ParseUtility_TryParseInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt16(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_GoodTestValues")]
		public short? ParseUtility_TryParseInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseInt16(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_formatProvider_GoodTestValues")]
		public short? ParseUtility_TryParseInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseInt16(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt16GoodTestValues")]
		public short StringExtensions_ParseInt16(string stringValue)
		{
			return stringValue.ParseInt16();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseInt16BadTestValues")]
		public short StringExtensions_ParseInt16_Exceptions(string stringValue)
		{
			return stringValue.ParseInt16();
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_formatProvider_GoodTestValues")]
		public short StringExtensions_ParseInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseInt16(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_GoodTestValues")]
		public short StringExtensions_ParseInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseInt16(styles);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_formatProvider_GoodTestValues")]
		public short StringExtensions_ParseInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseInt16(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt16GoodTestValues")]
		[TestCaseSource("TryParseInt16BadTestValues")]
		public short? StringExtensions_TryParseInt16(string stringValue)
		{
			return stringValue.TryParseInt16();
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_formatProvider_GoodTestValues")]
		public short? StringExtensions_TryParseInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseInt16(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_styles_GoodTestValues")]
		public short? StringExtensions_TryParseInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseInt16(styles);
		}

		[Test]
		[TestCaseSource("ParseInt16_With_formatProvider_GoodTestValues")]
		public short? StringExtensions_TryParseInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseInt16(formatProvider);
		}
	}
}
