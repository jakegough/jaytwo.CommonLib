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
		private static IEnumerable<TestCaseData> ParseUInt32AllTestValues()
		{
			yield return new TestCaseData("4294967295").Returns((uint)4294967295);
			yield return new TestCaseData("0").Returns(0);
			yield return new TestCaseData("4294967296").Throws(typeof(OverflowException));
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

		private static IEnumerable<TestCaseData> ParseUInt32GoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseUInt32AllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseUInt32BadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseUInt32AllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseUInt32BadTestValues()
		{
			foreach (var testCase in ParseUInt32BadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseUInt32_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseUInt32AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseUInt32_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseUInt32AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseUInt32_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseUInt32AllTestValues());
		}

		[Test]
		[TestCaseSource("ParseUInt32GoodTestValues")]
		public uint ParseUtility_ParseUInt32(string stringValue)
		{
			return ParseUtility.ParseUInt32(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseUInt32BadTestValues")]
		public uint ParseUtility_ParseUInt32_Exceptions(string stringValue)
		{
			return ParseUtility.ParseUInt32(stringValue);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_formatProvider_GoodTestValues")]
		public uint ParseUtility_ParseUInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt32(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_GoodTestValues")]
		public uint ParseUtility_ParseUInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseUInt32(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_formatProvider_GoodTestValues")]
		public uint ParseUtility_ParseUInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt32(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt32GoodTestValues")]
		[TestCaseSource("TryParseUInt32BadTestValues")]
		public uint? ParseUtility_TryParseUInt32(string stringValue)
		{
			return ParseUtility.TryParseUInt32(stringValue);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_formatProvider_GoodTestValues")]
		public uint? ParseUtility_TryParseUInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt32(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_GoodTestValues")]
		public uint? ParseUtility_TryParseUInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseUInt32(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_formatProvider_GoodTestValues")]
		public uint? ParseUtility_TryParseUInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt32(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt32GoodTestValues")]
		public uint StringExtensions_ParseUInt32(string stringValue)
		{
			return stringValue.ParseUInt32();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseUInt32BadTestValues")]
		public uint StringExtensions_ParseUInt32_Exceptions(string stringValue)
		{
			return stringValue.ParseUInt32();
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_formatProvider_GoodTestValues")]
		public uint StringExtensions_ParseUInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseUInt32(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_GoodTestValues")]
		public uint StringExtensions_ParseUInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseUInt32(styles);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_formatProvider_GoodTestValues")]
		public uint StringExtensions_ParseUInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseUInt32(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt32GoodTestValues")]
		[TestCaseSource("TryParseUInt32BadTestValues")]
		public uint? StringExtensions_TryParseUInt32(string stringValue)
		{
			return stringValue.TryParseUInt32();
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_formatProvider_GoodTestValues")]
		public uint? StringExtensions_TryParseUInt32_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseUInt32(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_styles_GoodTestValues")]
		public uint? StringExtensions_TryParseUInt32_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseUInt32(styles);
		}

		[Test]
		[TestCaseSource("ParseUInt32_With_formatProvider_GoodTestValues")]
		public uint? StringExtensions_TryParseUInt32_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseUInt32(formatProvider);
		}
	}
}
