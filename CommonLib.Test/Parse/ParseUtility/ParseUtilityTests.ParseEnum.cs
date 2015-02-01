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
		[Test]
		public void ParseUtility_ParseEnum()
		{
			Assert.AreEqual(BoolStyles.Any, ParseUtility.ParseEnum<BoolStyles>("Any"));
		}
		
		[Test]
		[ExpectedException]
		[TestCase("Foo")]
		[TestCase("")]
		[TestCase(null)]
		public void ParseUtility_ParseEnum_bad_input(string input)
		{
			ParseUtility.ParseEnum<BoolStyles>(input);
		}

		[Test]
		[ExpectedException]
		public void ParseUtility_ParseEnum_not_enum()
		{
			ParseUtility.ParseEnum<Int32>("foo");
		}

		[Test]
		public void ParseUtility_TryParseEnum()
		{
			Assert.AreEqual(BoolStyles.Any, ParseUtility.TryParseEnum<BoolStyles>("Any"));
		}

        [Test]
        [TestCase("Foo")]
        [TestCase("")]
        [TestCase(null)]
        public void ParseUtility_TryParseEnum_bad_input(string input)
        {
            Assert.IsNull(ParseUtility.TryParseEnum<BoolStyles>(input));
        }

		[Test]
		public void StringExtensions_ParseEnum()
		{
			Assert.AreEqual(BoolStyles.Any, "Any".ParseEnum<BoolStyles>());
		}

		[Test]
		[ExpectedException]
		[TestCase("Foo")]
		[TestCase("")]
		[TestCase(null)]
		public void StringExtensions_ParseEnum_bad_input(string input)
		{
			input.ParseEnum<BoolStyles>();
		}

		[Test]
		[ExpectedException]
		public void StringExtensions_ParseEnum_not_enum()
		{
			"foo".ParseEnum<Int32>();
		}

		[Test]
		public void StringExtensions_TryParseEnum()
		{
			Assert.AreEqual(BoolStyles.Any, "Any".TryParseEnum<BoolStyles>());
		}

		[Test]
		[TestCase("Foo")]
		[TestCase("")]
		[TestCase(null)]
		public void StringExtensions_TryParseEnum_bad_input(string input)
		{
			Assert.IsNull(input.TryParseEnum<BoolStyles>());
		}
	}
}
