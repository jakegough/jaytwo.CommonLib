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
		private static IEnumerable<TestCaseData> ParseUInt16AllTestValues()
		{
			yield return new TestCaseData("65535").Returns((ushort)65535);
			yield return new TestCaseData("0").Returns(0);
			yield return new TestCaseData("65536").Throws(typeof(OverflowException));
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

		private static IEnumerable<TestCaseData> ParseUInt16GoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseUInt16AllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseUInt16BadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseUInt16AllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseUInt16BadTestValues()
		{
			foreach (var testCase in ParseUInt16BadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseUInt16_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseUInt16AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseUInt16_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseUInt16AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseUInt16_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseUInt16AllTestValues());
		}

		[Test]
		[TestCaseSource("ParseUInt16GoodTestValues")]
		public ushort ParseUtility_ParseUInt16(string stringValue)
		{
			return ParseUtility.ParseUInt16(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseUInt16BadTestValues")]
		public ushort ParseUtility_ParseUInt16_Exceptions(string stringValue)
		{
			return ParseUtility.ParseUInt16(stringValue);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_formatProvider_GoodTestValues")]
		public ushort ParseUtility_ParseUInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt16(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_GoodTestValues")]
		public ushort ParseUtility_ParseUInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseUInt16(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_formatProvider_GoodTestValues")]
		public ushort ParseUtility_ParseUInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt16(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt16GoodTestValues")]
		[TestCaseSource("TryParseUInt16BadTestValues")]
		public ushort? ParseUtility_TryParseUInt16(string stringValue)
		{
			return ParseUtility.TryParseUInt16(stringValue);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_formatProvider_GoodTestValues")]
		public ushort? ParseUtility_TryParseUInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt16(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_GoodTestValues")]
		public ushort? ParseUtility_TryParseUInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseUInt16(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_formatProvider_GoodTestValues")]
		public ushort? ParseUtility_TryParseUInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt16(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt16GoodTestValues")]
		public ushort StringExtensions_ParseUInt16(string stringValue)
		{
			return stringValue.ParseUInt16();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseUInt16BadTestValues")]
		public ushort StringExtensions_ParseUInt16_Exceptions(string stringValue)
		{
			return stringValue.ParseUInt16();
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_formatProvider_GoodTestValues")]
		public ushort StringExtensions_ParseUInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseUInt16(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_GoodTestValues")]
		public ushort StringExtensions_ParseUInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseUInt16(styles);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_formatProvider_GoodTestValues")]
		public ushort StringExtensions_ParseUInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseUInt16(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt16GoodTestValues")]
		[TestCaseSource("TryParseUInt16BadTestValues")]
		public ushort? StringExtensions_TryParseUInt16(string stringValue)
		{
			return stringValue.TryParseUInt16();
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_formatProvider_GoodTestValues")]
		public ushort? StringExtensions_TryParseUInt16_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseUInt16(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_styles_GoodTestValues")]
		public ushort? StringExtensions_TryParseUInt16_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseUInt16(styles);
		}

		[Test]
		[TestCaseSource("ParseUInt16_With_formatProvider_GoodTestValues")]
		public ushort? StringExtensions_TryParseUInt16_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseUInt16(formatProvider);
		}
	}
}
