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
		private static IEnumerable<TestCaseData> ParseSByteAllTestValues()
		{
			yield return new TestCaseData("127").Returns(127);
			yield return new TestCaseData("-128").Returns(-128);
			yield return new TestCaseData("128").Throws(typeof(OverflowException));
			yield return new TestCaseData("-129").Throws(typeof(OverflowException));

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

		private static IEnumerable<TestCaseData> ParseSByteGoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseSByteAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseSByteBadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseSByteAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseSByteBadTestValues()
		{
			foreach (var testCase in ParseSByteBadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseSByte_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseSByteAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseSByte_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseSByteAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseSByte_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseSByteAllTestValues());
		}

		[Test]
		[TestCaseSource("ParseSByteGoodTestValues")]
		public sbyte ParseUtility_ParseSByte(string stringValue)
		{
			return ParseUtility.ParseSByte(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseSByteBadTestValues")]
		public sbyte ParseUtility_ParseSByte_Exceptions(string stringValue)
		{
			return ParseUtility.ParseSByte(stringValue);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_formatProvider_GoodTestValues")]
		public sbyte ParseUtility_ParseSByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSByte(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_GoodTestValues")]
		public sbyte ParseUtility_ParseSByte_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseSByte(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_formatProvider_GoodTestValues")]
		public sbyte ParseUtility_ParseSByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseSByte(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSByteGoodTestValues")]
		[TestCaseSource("TryParseSByteBadTestValues")]
		public sbyte? ParseUtility_TryParseSByte(string stringValue)
		{
			return ParseUtility.TryParseSByte(stringValue);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_formatProvider_GoodTestValues")]
		public sbyte? ParseUtility_TryParseSByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSByte(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_GoodTestValues")]
		public sbyte? ParseUtility_TryParseSByte_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseSByte(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_formatProvider_GoodTestValues")]
		public sbyte? ParseUtility_TryParseSByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseSByte(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSByteGoodTestValues")]
		public sbyte StringExtensions_ParseSByte(string stringValue)
		{
			return stringValue.ParseSByte();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseSByteBadTestValues")]
		public sbyte StringExtensions_ParseSByte_Exceptions(string stringValue)
		{
			return stringValue.ParseSByte();
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_formatProvider_GoodTestValues")]
		public sbyte StringExtensions_ParseSByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseSByte(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_GoodTestValues")]
		public sbyte StringExtensions_ParseSByte_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseSByte(styles);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_formatProvider_GoodTestValues")]
		public sbyte StringExtensions_ParseSByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseSByte(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSByteGoodTestValues")]
		[TestCaseSource("TryParseSByteBadTestValues")]
		public sbyte? StringExtensions_TryParseSByte(string stringValue)
		{
			return stringValue.TryParseSByte();
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_formatProvider_GoodTestValues")]
		public sbyte? StringExtensions_TryParseSByte_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseSByte(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_styles_GoodTestValues")]
		public sbyte? StringExtensions_TryParseSByte_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseSByte(styles);
		}

		[Test]
		[TestCaseSource("ParseSByte_With_formatProvider_GoodTestValues")]
		public sbyte? StringExtensions_TryParseSByte_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseSByte(formatProvider);
		}
	}
}
