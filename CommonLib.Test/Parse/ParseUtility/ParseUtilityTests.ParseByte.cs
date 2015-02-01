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
		private static IEnumerable<TestCaseData> ParseByteAllTestValues()
		{
			yield return new TestCaseData("255").Returns(255);
			yield return new TestCaseData("0").Returns(0);
			yield return new TestCaseData("256").Throws(typeof(OverflowException));
			yield return new TestCaseData("-1").Throws(typeof(OverflowException));

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

		private static IEnumerable<TestCaseData> ParseByteGoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseByteAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseByteBadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseByteAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseByteBadTestValues()
		{
			foreach (var testCase in ParseByteBadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseByte_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseByteAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseByte_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseByteAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseByte_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseByteAllTestValues());
		}

		[Test]
		[TestCaseSource("ParseByteGoodTestValues")]
		public byte ParseUtility_ParseByte(string stringValue)
		{
			return ParseUtility.ParseByte(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseByteBadTestValues")]
		public byte ParseUtility_ParseByte_Exceptions(string stringValue)
		{
			return ParseUtility.ParseByte(stringValue);
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_formatProvider_GoodTestValues")]
		public byte ParseUtility_ParseByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseByte(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_GoodTestValues")]
		public byte ParseUtility_ParseByte_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseByte(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseByte_With_formatProvider_GoodTestValues")]
		public byte ParseUtility_ParseByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseByte(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseByteGoodTestValues")]
		[TestCaseSource("TryParseByteBadTestValues")]
		public byte? ParseUtility_TryParseByte(string stringValue)
		{
			return ParseUtility.TryParseByte(stringValue);
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_formatProvider_GoodTestValues")]
		public byte? ParseUtility_TryParseByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseByte(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_GoodTestValues")]
		public byte? ParseUtility_TryParseByte_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseByte(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseByte_With_formatProvider_GoodTestValues")]
		public byte? ParseUtility_TryParseByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseByte(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseByteGoodTestValues")]
		public byte StringExtensions_ParseByte(string stringValue)
		{
			return stringValue.ParseByte();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseByteBadTestValues")]
		public byte StringExtensions_ParseByte_Exceptions(string stringValue)
		{
			return stringValue.ParseByte();
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_formatProvider_GoodTestValues")]
		public byte StringExtensions_ParseByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseByte(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_GoodTestValues")]
		public byte StringExtensions_ParseByte_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseByte(styles);
		}

		[Test]
		[TestCaseSource("ParseByte_With_formatProvider_GoodTestValues")]
		public byte StringExtensions_ParseByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseByte(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseByteGoodTestValues")]
		[TestCaseSource("TryParseByteBadTestValues")]
		public byte? StringExtensions_TryParseByte(string stringValue)
		{
			return stringValue.TryParseByte();
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_formatProvider_GoodTestValues")]
		public byte? StringExtensions_TryParseByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseByte(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseByte_With_styles_GoodTestValues")]
		public byte? StringExtensions_TryParseByte_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseByte(styles);
		}

		[Test]
		[TestCaseSource("ParseByte_With_formatProvider_GoodTestValues")]
		public byte? StringExtensions_TryParseByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseByte(formatProvider);
		}
	}
}
