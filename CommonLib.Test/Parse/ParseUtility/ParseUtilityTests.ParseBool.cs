using jaytwo.Common.Extensions;
using jaytwo.Common.Parse;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace jaytwo.Common.Test.Parse
{
	[TestFixture]
	public partial class ParseUtilityTests
	{
		private static IEnumerable<TestCaseData> ParseBoolAllTestValues()
		{
			yield return new TestCaseData("0").Returns(false);
			yield return new TestCaseData("00").Returns(false);
			yield return new TestCaseData("1").Returns(true);
			yield return new TestCaseData("01").Returns(true);
			yield return new TestCaseData("-1").Returns(true);
			yield return new TestCaseData("100").Returns(true);
			yield return new TestCaseData("Yes").Returns(true);
			yield return new TestCaseData("No").Returns(false);
			yield return new TestCaseData("Y").Returns(true);
			yield return new TestCaseData("N").Returns(false);
			yield return new TestCaseData("True").Returns(true);
			yield return new TestCaseData("False").Returns(false);
			yield return new TestCaseData("T").Returns(true);
			yield return new TestCaseData("F").Returns(false);
			yield return new TestCaseData(" true").Returns(true);
			yield return new TestCaseData("false ").Returns(false);

			yield return new TestCaseData("0", BoolStyles.ZeroOne).Returns(false);
			yield return new TestCaseData("00", BoolStyles.ZeroOne).Returns(false);
			yield return new TestCaseData("1", BoolStyles.ZeroOne).Returns(true);
			yield return new TestCaseData("01", BoolStyles.ZeroOne).Returns(true);
			yield return new TestCaseData("0", BoolStyles.ZeroNonzero).Returns(false);
			yield return new TestCaseData("00", BoolStyles.ZeroNonzero).Returns(false);
			yield return new TestCaseData("1", BoolStyles.ZeroNonzero).Returns(true);
			yield return new TestCaseData("01", BoolStyles.ZeroNonzero).Returns(true);
			yield return new TestCaseData("-1", BoolStyles.ZeroNonzero).Returns(true);
			yield return new TestCaseData("100", BoolStyles.ZeroNonzero).Returns(true);
			yield return new TestCaseData("Yes", BoolStyles.YesNo).Returns(true);
			yield return new TestCaseData("No", BoolStyles.YesNo).Returns(false);
			yield return new TestCaseData("Y", BoolStyles.YN).Returns(true);
			yield return new TestCaseData("N", BoolStyles.YN).Returns(false);
			yield return new TestCaseData("True", BoolStyles.TrueFalse).Returns(true);
			yield return new TestCaseData("False", BoolStyles.TrueFalse).Returns(false);
			yield return new TestCaseData("true", BoolStyles.TrueFalse).Returns(true);
			yield return new TestCaseData("false", BoolStyles.TrueFalse).Returns(false);
			yield return new TestCaseData(" true", BoolStyles.TrimWhiteSpace).Returns(true);
			yield return new TestCaseData("false ", BoolStyles.TrimWhiteSpace).Returns(false);
			yield return new TestCaseData("true", BoolStyles.Default).Returns(true);
			yield return new TestCaseData("false", BoolStyles.Default).Returns(false);
			yield return new TestCaseData("True", BoolStyles.Default).Returns(true);
			yield return new TestCaseData("False", BoolStyles.Default).Returns(false);
			yield return new TestCaseData("0", BoolStyles.Any).Returns(false);
			yield return new TestCaseData("00", BoolStyles.Any).Returns(false);
			yield return new TestCaseData("1", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("01", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("-1", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("100", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("Yes", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("No", BoolStyles.Any).Returns(false);
			yield return new TestCaseData("Y", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("N", BoolStyles.Any).Returns(false);
			yield return new TestCaseData("True", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("False", BoolStyles.Any).Returns(false);
			yield return new TestCaseData("T", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("F", BoolStyles.Any).Returns(false);
			yield return new TestCaseData(" true", BoolStyles.Any).Returns(true);
			yield return new TestCaseData("false ", BoolStyles.Any).Returns(false);

			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
			yield return new TestCaseData("").Throws(typeof(FormatException));
			yield return new TestCaseData("foo").Throws(typeof(FormatException));
			yield return new TestCaseData("true", BoolStyles.YesNo).Throws(typeof(FormatException));
		}

		private static IEnumerable<TestCaseData> ParseBoolGoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseBoolAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseBoolBadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string>(ParseBoolAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseBoolBadTestValues()
		{
			foreach (var testCase in ParseBoolBadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		private static IEnumerable<TestCaseData> ParseBool_With_styles_GoodTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string, BoolStyles>(ParseBoolAllTestValues()))
				if (testCase.HasExpectedResult)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> ParseBool_With_styles_BadTestValues()
		{
			foreach (var testCase in TestUtility.GetTestCasesWithArgumentTypes<string, BoolStyles>(ParseBoolAllTestValues()))
				if (testCase.ExpectedException != null)
					yield return testCase;
		}

		private static IEnumerable<TestCaseData> TryParseBool_With_styles_BadTestValues()
		{
			foreach (var testCase in ParseBool_With_styles_BadTestValues())
				yield return new TestCaseData(testCase.Arguments).Returns(null);
		}

		[Test]
		[TestCaseSource("ParseBoolGoodTestValues")]
		public bool ParseUtility_ParseBoolean(string stringValue)
		{
			return ParseUtility.ParseBoolean(stringValue);
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseBoolBadTestValues")]
		public bool ParseUtility_ParseBool_Exceptions(string stringValue)
		{
			return ParseUtility.ParseBoolean(stringValue);
		}

		[Test]
		[TestCaseSource("ParseBool_With_styles_GoodTestValues")]
		public bool ParseUtility_ParseBool_With_styles(string stringValue, BoolStyles styles)
		{
			return ParseUtility.ParseBoolean(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseBoolGoodTestValues")]
		[TestCaseSource("TryParseBoolBadTestValues")]
		public bool? ParseUtility_TryParseBoolean(string stringValue)
		{
			return ParseUtility.TryParseBoolean(stringValue);
		}

		[Test]
		[TestCaseSource("ParseBool_With_styles_GoodTestValues")]
		[TestCaseSource("TryParseBool_With_styles_BadTestValues")]
		public bool? ParseUtility_TryParseBool_With_styles(string stringValue, BoolStyles styles)
		{
			return ParseUtility.TryParseBoolean(stringValue, styles);
		}

		[Test]
		[TestCaseSource("ParseBoolGoodTestValues")]
		public bool StringExtensions_ParseBoolean(string stringValue)
		{
			return stringValue.ParseBoolean();
		}

		[Test]
		[ExpectedException]
		[TestCaseSource("ParseBoolBadTestValues")]
		public bool StringExtensions_ParseBool_Exceptions(string stringValue)
		{
			return stringValue.ParseBoolean();
		}

		[Test]
		[TestCaseSource("ParseBool_With_styles_GoodTestValues")]
		public bool StringExtensions_ParseBool_With_styles(string stringValue, BoolStyles styles)
		{
			return stringValue.ParseBoolean(styles);
		}

		[Test]
		[TestCaseSource("ParseBoolGoodTestValues")]
		[TestCaseSource("TryParseBoolBadTestValues")]
		public bool? StringExtensions_TryParseBoolean(string stringValue)
		{
			return stringValue.TryParseBoolean();
		}

		[Test]
		[TestCaseSource("ParseBool_With_styles_GoodTestValues")]
		[TestCaseSource("TryParseBool_With_styles_BadTestValues")]
		public bool? StringExtensions_TryParseBool_With_styles(string stringValue, BoolStyles styles)
		{
			return stringValue.TryParseBoolean(styles);
		}
	}
}
