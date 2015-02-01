using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using jaytwo.Common.Parse;

namespace jaytwo.Common.Test.Parse
{
	[TestFixture]
	public static class ParseHelpersTests
	{
		[Test]
		public static void ParseHelpers_IsBoolStylesMatch()
		{
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.None));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.Any));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.Default));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.TrimWhiteSpace));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.TrueFalse));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.TF));						
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.YesNo));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.YN));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.ZeroOne));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.None, BoolStyles.ZeroNonzero));

			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.None));

			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.Any));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.Default));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.TrimWhiteSpace));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.TrueFalse));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.TF));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.YesNo));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.YN));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.ZeroOne));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Any, BoolStyles.ZeroNonzero));

			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.None));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.TrueFalse));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.TF));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.YesNo));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.YN));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.ZeroOne));
			Assert.IsFalse(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.ZeroNonzero));

			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.Any));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.Default));
			Assert.IsTrue(InternalParseHelpers.IsBoolStylesMatch(BoolStyles.Default | BoolStyles.TrimWhiteSpace, BoolStyles.TrimWhiteSpace));
		}

		[Test]
		public static void ParseHelpers_IsNonZeroInt()
		{
			Assert.IsTrue(InternalParseHelpers.IsNonZeroInt("1"));
			Assert.IsTrue(InternalParseHelpers.IsNonZeroInt("100"));
			Assert.IsTrue(InternalParseHelpers.IsNonZeroInt("9"));
			Assert.IsTrue(InternalParseHelpers.IsNonZeroInt("123"));			
			Assert.IsTrue(InternalParseHelpers.IsNonZeroInt("123456789123456789123456789123456789"));

			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt("0"));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt(".456"));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt("0.456"));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt("123.456"));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt(" 123 "));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt("123 456789123456789123456789123456789"));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt(" "));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt("X"));
			Assert.IsFalse(InternalParseHelpers.IsNonZeroInt("["));			
		}

		[Test]
		public static void ParseHelpers_IsOneInt()
		{
			Assert.IsTrue(InternalParseHelpers.IsOneInt("1"));
			Assert.IsTrue(InternalParseHelpers.IsOneInt("001"));

			Assert.IsFalse(InternalParseHelpers.IsOneInt(" 1 "));
			Assert.IsFalse(InternalParseHelpers.IsOneInt(".1"));
			Assert.IsFalse(InternalParseHelpers.IsOneInt("1."));
			Assert.IsFalse(InternalParseHelpers.IsOneInt("1.1"));
			Assert.IsFalse(InternalParseHelpers.IsOneInt("0"));
			Assert.IsFalse(InternalParseHelpers.IsOneInt(" "));
			Assert.IsFalse(InternalParseHelpers.IsOneInt("9"));
			Assert.IsFalse(InternalParseHelpers.IsOneInt("X"));
			Assert.IsFalse(InternalParseHelpers.IsOneInt("["));
		}

		[Test]
		public static void ParseHelpers_IsZeroInt()
		{
			Assert.IsTrue(InternalParseHelpers.IsZeroInt("0"));
			Assert.IsTrue(InternalParseHelpers.IsZeroInt("000"));

			Assert.IsFalse(InternalParseHelpers.IsZeroInt(" 0 "));
			Assert.IsFalse(InternalParseHelpers.IsZeroInt(".0"));
			Assert.IsFalse(InternalParseHelpers.IsZeroInt("0."));
			Assert.IsFalse(InternalParseHelpers.IsZeroInt("1"));
			Assert.IsFalse(InternalParseHelpers.IsZeroInt(" "));
			Assert.IsFalse(InternalParseHelpers.IsZeroInt("9"));
			Assert.IsFalse(InternalParseHelpers.IsZeroInt("X"));
			Assert.IsFalse(InternalParseHelpers.IsZeroInt("["));
		}
	}
}
