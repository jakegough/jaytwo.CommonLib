using jaytwo.Common.Time;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jaytwo.Common.Test.Time
{
	[TestFixture]
	public static class TimeProviderTests
	{
		[Test]
		public static void default_TimeProvider_Now_equals_DateTime_Now()
		{
			TimeProvider.SetProvider(null);
			var systemNow = DateTime.Now;
			var timeProviderNow = TimeProvider.Now;
			var difference = systemNow.Subtract(timeProviderNow);

			Assert.IsTrue(difference.TotalMilliseconds <= 1);
		}

		[Test]
		public static void default_TimeProvider_UtcNow_equals_DateTime_UtcNow()
		{
			TimeProvider.SetProvider(null);
			var systemUtcNow = DateTime.UtcNow;
			var timeProviderUtcNow = TimeProvider.UtcNow;

			var difference = systemUtcNow.Subtract(timeProviderUtcNow);

			Assert.IsTrue(difference.TotalMilliseconds <= 1);
		}

		[Test]
		public static void can_mock_time_provider()
		{
			var mockTimeProvider = MockRepository.GenerateMock<ITimeProvider>();
			TimeProvider.SetProvider(mockTimeProvider);

			var mockNow = new DateTime(2014, 12, 31, 15, 03, 05);
			mockTimeProvider.Stub(x => x.Now).Return(mockNow);
			Assert.AreEqual(mockNow, TimeProvider.Now);

			var mockUtcNow = new DateTime(2014, 12, 30, 14, 02, 03);
			mockTimeProvider.Stub(x => x.UtcNow).Return(mockUtcNow);
			Assert.AreEqual(mockUtcNow, TimeProvider.UtcNow);
		}
	}
}
