using jaytwo.Common.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jaytwo.Common.Test.Time
{
	[TestFixture]
	public static class DateTimeExtensionsTests
	{
		[Test]
		public static void TruncateToSecondPrecision()
		{
			Assert.AreEqual(
				new DateTime(2014, 1, 1, 12, 23, 34, 0, DateTimeKind.Unspecified),
				new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified).TruncateToSecondPrecision());
		}

		[Test]
		public static void TruncateToMinutePrecision()
		{
			Assert.AreEqual(
				new DateTime(2014, 1, 1, 12, 23, 0, 0, DateTimeKind.Unspecified),
				new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified).TruncateToMinutePrecision());
		}

        [Test]
        public static void WithKind()
        {
            Assert.AreEqual(
                new DateTime(2014, 09, 17, 13, 46, 33, 756, DateTimeKind.Local),
                new DateTime(2014, 09, 17, 13, 46, 33, 756).WithKind(DateTimeKind.Local));

            Assert.AreEqual(
                new DateTime(2014, 09, 17, 13, 46, 33, 756, DateTimeKind.Unspecified),
                new DateTime(2014, 09, 17, 13, 46, 33, 756).WithKind(DateTimeKind.Unspecified));

            Assert.AreEqual(
                new DateTime(2014, 09, 17, 13, 46, 33, 756, DateTimeKind.Utc),
                new DateTime(2014, 09, 17, 13, 46, 33, 756).WithKind(DateTimeKind.Utc));

            Assert.AreEqual(
                new DateTime(2014, 09, 17, 13, 46, 33, 756, DateTimeKind.Utc),
                ((DateTime?)new DateTime(2014, 09, 17, 13, 46, 33, 756)).WithKind(DateTimeKind.Utc));

            Assert.IsNull(((DateTime?)null).WithKind(DateTimeKind.Utc));
        }
	}
}