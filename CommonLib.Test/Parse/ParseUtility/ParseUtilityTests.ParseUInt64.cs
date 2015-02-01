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
		private static IEnumerable<TestCaseData> ParseUInt64AllTestValues()
		{
			yield return new TestCaseData("18446744073709551615").Returns((ulong)18446744073709551615);
			yield return new TestCaseData("0").Returns(0);
			yield return new TestCaseData("18446744073709551616").Throws(typeof(OverflowException));
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

		private static IEnumerable<TestCaseData> ParseUInt64GoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseUInt64AllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseUInt64BadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseUInt64AllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseUInt64BadTestValues()
		{
			foreach (var testCase in ParseUInt64BadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseUInt64_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles>(ParseUInt64AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseUInt64_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseUInt64AllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseUInt64_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, NumberStyles, IFormatProvider>(ParseUInt64AllTestValues());
		}

		[Test]
		[TestCaseSource("ParseUInt64GoodTestValues")]
		public ulong ParseUtility_ParseUInt64(string stringValue)
		{
			return ParseUtility.ParseUInt64(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseUInt64BadTestValues")]
		public ulong ParseUtility_ParseUInt64_Exceptions(string stringValue)
		{
			return ParseUtility.ParseUInt64(stringValue);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_formatProvider_GoodTestValues")]
		public ulong ParseUtility_ParseUInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt64(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_GoodTestValues")]
		public ulong ParseUtility_ParseUInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.ParseUInt64(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_formatProvider_GoodTestValues")]
		public ulong ParseUtility_ParseUInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseUInt64(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt64GoodTestValues")]
		[TestCaseSource("TryParseUInt64BadTestValues")]
		public ulong? ParseUtility_TryParseUInt64(string stringValue)
		{
			return ParseUtility.TryParseUInt64(stringValue);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_formatProvider_GoodTestValues")]
		public ulong? ParseUtility_TryParseUInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt64(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_GoodTestValues")]
		public ulong? ParseUtility_TryParseUInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return ParseUtility.TryParseUInt64(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_formatProvider_GoodTestValues")]
		public ulong? ParseUtility_TryParseUInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseUInt64(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt64GoodTestValues")]
		public ulong StringExtensions_ParseUInt64(string stringValue)
		{
			return stringValue.ParseUInt64();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseUInt64BadTestValues")]
		public ulong StringExtensions_ParseUInt64_Exceptions(string stringValue)
		{
			return stringValue.ParseUInt64();
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_formatProvider_GoodTestValues")]
		public ulong StringExtensions_ParseUInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseUInt64(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_GoodTestValues")]
		public ulong StringExtensions_ParseUInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.ParseUInt64(styles);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_formatProvider_GoodTestValues")]
		public ulong StringExtensions_ParseUInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseUInt64(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt64GoodTestValues")]
		[TestCaseSource("TryParseUInt64BadTestValues")]
		public ulong? StringExtensions_TryParseUInt64(string stringValue)
		{
			return stringValue.TryParseUInt64();
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_formatProvider_GoodTestValues")]
		public ulong? StringExtensions_TryParseUInt64_With_styles_formatProvider(string stringValue, NumberStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseUInt64(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_styles_GoodTestValues")]
		public ulong? StringExtensions_TryParseUInt64_With_styles(string stringValue, NumberStyles styles)
		{
			return stringValue.TryParseUInt64(styles);
		}

		[Test]
		[TestCaseSource("ParseUInt64_With_formatProvider_GoodTestValues")]
		public ulong? StringExtensions_TryParseUInt64_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseUInt64(formatProvider);
		}
	}
}
