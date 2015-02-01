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
		private static IEnumerable<TestCaseData> ParseDateTimeAllTestValues()
		{
			yield return new TestCaseData("6/1/2012").Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("6-1-2012").Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("2012-06-01").Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("2012-06-01T02:03:04").Returns(new DateTime(2012, 6, 1, 2, 3, 4));
			yield return new TestCaseData("June 1, 2012").Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("Jun 1, 2012").Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("Jun 1 2012").Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("June 1 2012 02:03:04").Returns(new DateTime(2012, 6, 1, 2, 3, 4));
			yield return new TestCaseData("June 1 2012 02:03:04 PM").Returns(new DateTime(2012, 6, 1, 14, 3, 4));
			yield return new TestCaseData("Fri Jun 1 2012 02:03:04 PM").Returns(new DateTime(2012, 6, 1, 14, 3, 4));
			yield return new TestCaseData("Friday June 1 2012 02:03:04 PM").Returns(new DateTime(2012, 6, 1, 14, 3, 4));
			yield return new TestCaseData("Friday, June 1, 2012 02:03:04 PM").Returns(new DateTime(2012, 6, 1, 14, 3, 4));

			yield return new TestCaseData("0").Throws(typeof(FormatException));
			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
			yield return new TestCaseData("").Throws(typeof(FormatException));
			yield return new TestCaseData("foo").Throws(typeof(FormatException));

			yield return new TestCaseData("06-01-2012", DateTimeStyles.AssumeLocal).Returns(new DateTime(2012, 6, 1, 0, 0, 0, DateTimeKind.Local));
			yield return new TestCaseData("01-06-2012", new CultureInfo("pt-BR")).Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("06-01-2012", new CultureInfo("en-US")).Returns(new DateTime(2012, 6, 1));
			yield return new TestCaseData("01-06-2012 02:03:04", DateTimeStyles.AssumeLocal, new CultureInfo("pt-BR")).Returns(new DateTime(2012, 6, 1, 2, 3, 4, DateTimeKind.Local));
			//yield return new TestCaseData("06-01-2012 02:03:04", DateTimeStyles.AssumeUniversal, new CultureInfo("en-US")).Returns(new DateTime(2012, 6, 1, 2, 3, 4, DateTimeKind.Utc));
		}

		private static IEnumerable<TestCaseData> ParseDateTimeGoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseDateTimeAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseDateTimeBadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseDateTimeAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseDateTimeBadTestValues()
		{
			foreach (var testCase in ParseDateTimeBadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseDateTime_With_styles_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, DateTimeStyles>(ParseDateTimeAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseDateTime_With_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, IFormatProvider>(ParseDateTimeAllTestValues());
		}

		private static IEnumerable<TestCaseData> ParseDateTime_With_styles_formatProvider_GoodTestValues()
		{
			return TestUtility.GetTestCasesWithArgumentTypes<string, DateTimeStyles, IFormatProvider>(ParseDateTimeAllTestValues());
		}

		[Test]
		[TestCaseSource("ParseDateTimeGoodTestValues")]
		public DateTime ParseUtility_ParseDateTime(string stringValue)
		{
			return ParseUtility.ParseDateTime(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseDateTimeBadTestValues")]
		public DateTime ParseUtility_ParseDateTime_Exceptions(string stringValue)
		{
			return ParseUtility.ParseDateTime(stringValue);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_formatProvider_GoodTestValues")]
		public DateTime ParseUtility_ParseDateTime_With_styles_formatProvider(string stringValue, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDateTime(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_GoodTestValues")]
		public DateTime ParseUtility_ParseDateTime_With_styles(string stringValue, DateTimeStyles styles)
		{
			return ParseUtility.ParseDateTime(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_formatProvider_GoodTestValues")]
		public DateTime ParseUtility_ParseDateTime_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.ParseDateTime(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDateTimeGoodTestValues")]
		[TestCaseSource("TryParseDateTimeBadTestValues")]
		public DateTime? ParseUtility_TryParseDateTime(string stringValue)
		{
			return ParseUtility.TryParseDateTime(stringValue);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_formatProvider_GoodTestValues")]
		public DateTime? ParseUtility_TryParseDateTime_With_styles_formatProvider(string stringValue, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDateTime(stringValue, styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_GoodTestValues")]
		public DateTime? ParseUtility_TryParseDateTime_With_styles(string stringValue, DateTimeStyles styles)
		{
			return ParseUtility.TryParseDateTime(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_formatProvider_GoodTestValues")]
		public DateTime? ParseUtility_TryParseDateTime_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return ParseUtility.TryParseDateTime(stringValue, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDateTimeGoodTestValues")]
		public DateTime StringExtensions_ParseDateTime(string stringValue)
		{
			return stringValue.ParseDateTime();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseDateTimeBadTestValues")]
		public DateTime StringExtensions_ParseDateTime_Exceptions(string stringValue)
		{
			return stringValue.ParseDateTime();
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_formatProvider_GoodTestValues")]
		public DateTime StringExtensions_ParseDateTime_With_styles_formatProvider(string stringValue, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.ParseDateTime(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_GoodTestValues")]
		public DateTime StringExtensions_ParseDateTime_With_styles(string stringValue, DateTimeStyles styles)
		{
			return stringValue.ParseDateTime(styles);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_formatProvider_GoodTestValues")]
		public DateTime StringExtensions_ParseDateTime_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.ParseDateTime(formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDateTimeGoodTestValues")]
		[TestCaseSource("TryParseDateTimeBadTestValues")]
		public DateTime? StringExtensions_TryParseDateTime(string stringValue)
		{
			return stringValue.TryParseDateTime();
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_formatProvider_GoodTestValues")]
		public DateTime? StringExtensions_TryParseDateTime_With_styles_formatProvider(string stringValue, DateTimeStyles styles, IFormatProvider formatProvider)
		{
			return stringValue.TryParseDateTime(styles, formatProvider);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_styles_GoodTestValues")]
		public DateTime? StringExtensions_TryParseDateTime_With_styles(string stringValue, DateTimeStyles styles)
		{
			return stringValue.TryParseDateTime(styles);
		}

		[Test]
		[TestCaseSource("ParseDateTime_With_formatProvider_GoodTestValues")]
		public DateTime? StringExtensions_TryParseDateTime_With_formatProvider(string stringValue, IFormatProvider formatProvider)
		{
			return stringValue.TryParseDateTime(formatProvider);
		}
	}
}
