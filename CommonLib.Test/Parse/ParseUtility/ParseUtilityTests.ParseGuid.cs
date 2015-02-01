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
		public void ParseUtility_ParseGuid()
		{
			Assert.AreEqual(new Guid("be9c3e50-1765-4a24-80f6-53b5944e0c73"), ParseUtility.ParseGuid("be9c3e50-1765-4a24-80f6-53b5944e0c73"));
		}

		[Test]
		[ExpectedException]
		[TestCase("Foo")]
		[TestCase("")]
		[TestCase(null)]
		public void ParseUtility_ParseGuid_bad_input(string input)
		{
			ParseUtility.ParseGuid(input);
		}

		[Test]
		public void ParseUtility_TryParseGuid()
		{
			Assert.AreEqual(new Guid("be9c3e50-1765-4a24-80f6-53b5944e0c73"), ParseUtility.TryParseGuid("be9c3e50-1765-4a24-80f6-53b5944e0c73"));
		}

		[Test]
		[TestCase("Foo")]
		[TestCase("")]
		[TestCase(null)]
		public void ParseUtility_TryParseGuid_bad_input(string input)
		{
			Assert.IsNull(ParseUtility.TryParseGuid(input));
		}

		[Test]
		public void StringExtensions_ParseGuid()
		{
			Assert.AreEqual(new Guid("be9c3e50-1765-4a24-80f6-53b5944e0c73"), "be9c3e50-1765-4a24-80f6-53b5944e0c73".ParseGuid());
		}

		[Test]
		[ExpectedException]
		[TestCase("Foo")]
		[TestCase("")]
		[TestCase(null)]
		public void StringExtensions_ParseGuid_bad_input(string input)
		{
			ParseUtility.ParseGuid(input);
		}

		[Test]
		public void StringExtensions_TryParseGuid()
		{
			Assert.AreEqual(new Guid("be9c3e50-1765-4a24-80f6-53b5944e0c73"), "be9c3e50-1765-4a24-80f6-53b5944e0c73".TryParseGuid());
		}

		[Test]
		[TestCase("Foo")]
		[TestCase("")]
		[TestCase(null)]
		public void StringExtensions_TryParseGuid_bad_input(string input)
		{
			Assert.IsNull(ParseUtility.TryParseGuid(input));
		}
	}
}
