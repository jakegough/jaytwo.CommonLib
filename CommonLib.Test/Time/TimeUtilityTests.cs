using jaytwo.Common.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using jaytwo.Common;
using jaytwo.Common.Time;
using jaytwo.Common.Parse;

namespace jaytwo.Common.Test.Time
{
    [TestFixture]
    public static class TimeUtilityTests
    {
        public static IEnumerable<TestCaseData> TimeUtility_IsWeekday_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 06)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 07)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 08)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 09)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 10)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 11)).Returns(true);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsWeekday_TestCases")]
        public static bool TimeUtility_IsWeekday(DateTime value)
        {
            return TimeUtility.IsWeekday(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsWeekday_TestCases")]
        public static bool DateTimeExtensions_IsWeekday(DateTime value)
        {
            return value.IsWeekday();
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsWeekend_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 06)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 07)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 08)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 09)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 10)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 11)).Returns(false);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsWeekend_TestCases")]
        public static bool TimeUtility_IsWeekend(DateTime value)
        {
            return TimeUtility.IsWeekend(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsWeekend_TestCases")]
        public static bool DateTimeExtensions_IsWeekend(DateTime value)
        {
            return value.IsWeekend();
        }

        [Test]
        public static void TimeUtility_GetLdapTimestampFromUtcTime_GetUtcTimeFromLdapTimestamp()
        {
            var utcNow = DateTime.UtcNow;
            var activeDirectoryTimestamp = TimeUtility.GetLdapTimestampFromUtcTime(utcNow);
            var utcTime = TimeUtility.GetUtcTimeFromLdapTimestamp(activeDirectoryTimestamp);
            Assert.AreEqual(utcNow, utcTime);

            //http://www.epochconverter.com/epoch/ldap-timestamp.php
            Assert.AreEqual(130666219451230000, TimeUtility.GetLdapTimestampFromUtcTime(new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Utc)));
            Assert.AreEqual(130666219451230000, TimeUtility.GetLdapTimestampFromUtcTime(new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Unspecified)));
            Assert.AreEqual(130666219451230000, TimeUtility.GetLdapTimestampFromUtcTime((DateTime?)new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Unspecified)));
            Assert.AreEqual(null, TimeUtility.GetLdapTimestampFromUtcTime((DateTime?)null));

            Assert.AreEqual(new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Utc), TimeUtility.GetUtcTimeFromLdapTimestamp(130666219451230000));
            Assert.AreEqual(new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Utc), TimeUtility.GetUtcTimeFromLdapTimestamp((long?)130666219451230000));
            Assert.AreEqual(null, TimeUtility.GetUtcTimeFromLdapTimestamp((long?)null));
        }

        private static IEnumerable<TestCaseData> GetTotalDays_TestCaseData()
        {
            yield return new TestCaseData(TimeSpan.FromHours(12)).Returns(0.5);
            yield return new TestCaseData(TimeSpan.FromHours(24)).Returns(1.0);
            yield return new TestCaseData(TimeSpan.FromHours(36)).Returns(1.5);
            yield return new TestCaseData(TimeSpan.FromHours(372)).Returns(15.5);
            yield return new TestCaseData(null).Returns(null);
        }

        [Test]
        [TestCaseSource("GetTotalDays_TestCaseData")]
        public static double? TimeUtility_GetTotalDays(TimeSpan? duration)
        {
            return TimeUtility.GetTotalDays(duration);
        }

        [Test]
        [TestCaseSource("GetTotalDays_TestCaseData")]
        public static double? TimeSpanExtensions_GetTotalDays(TimeSpan? duration)
        {
            return duration.GetTotalDays();
        }

        private static IEnumerable<TestCaseData> GetTotalHours_TestCaseData()
        {
            yield return new TestCaseData(TimeSpan.FromMinutes(30)).Returns(0.5);
            yield return new TestCaseData(TimeSpan.FromMinutes(60)).Returns(1.0);
            yield return new TestCaseData(TimeSpan.FromMinutes(90)).Returns(1.5);
            yield return new TestCaseData(TimeSpan.FromMinutes(930)).Returns(15.5);
            yield return new TestCaseData(null).Returns(null);
        }

        [Test]
        [TestCaseSource("GetTotalHours_TestCaseData")]
        public static double? TimeUtility_GetTotalHours(TimeSpan? duration)
        {
            return TimeUtility.GetTotalHours(duration);
        }

        [Test]
        [TestCaseSource("GetTotalHours_TestCaseData")]
        public static double? TimeSpanExtensions_GetTotalHours(TimeSpan? duration)
        {
            return duration.GetTotalHours();
        }

        private static IEnumerable<TestCaseData> GetTotalMinutes_TestCaseData()
        {
            yield return new TestCaseData(TimeSpan.FromSeconds(30)).Returns(0.5);
            yield return new TestCaseData(TimeSpan.FromSeconds(60)).Returns(1.0);
            yield return new TestCaseData(TimeSpan.FromSeconds(90)).Returns(1.5);
            yield return new TestCaseData(TimeSpan.FromSeconds(930)).Returns(15.5);
            yield return new TestCaseData(null).Returns(null);
        }

        [Test]
        [TestCaseSource("GetTotalMinutes_TestCaseData")]
        public static double? TimeUtility_GetTotalMinutes(TimeSpan? duration)
        {
            return TimeUtility.GetTotalMinutes(duration);
        }

        [Test]
        [TestCaseSource("GetTotalMinutes_TestCaseData")]
        public static double? TimeSpanExtensions_GetTotalMinutes(TimeSpan? duration)
        {
            return duration.GetTotalMinutes();
        }

        private static IEnumerable<TestCaseData> GetTotalSeconds_TestCaseData()
        {
            yield return new TestCaseData(TimeSpan.FromMilliseconds(500)).Returns(0.5);
            yield return new TestCaseData(TimeSpan.FromMilliseconds(1000)).Returns(1.0);
            yield return new TestCaseData(TimeSpan.FromMilliseconds(1500)).Returns(1.5);
            yield return new TestCaseData(TimeSpan.FromMilliseconds(1555500)).Returns(1555.5);
            yield return new TestCaseData(null).Returns(null);
        }

        [Test]
        [TestCaseSource("GetTotalSeconds_TestCaseData")]
        public static double? TimeUtility_GetTotalSeconds(TimeSpan? duration)
        {
            return TimeUtility.GetTotalSeconds(duration);
        }

        [Test]
        [TestCaseSource("GetTotalSeconds_TestCaseData")]
        public static double? TimeSpanExtensions_GetTotalSeconds(TimeSpan? duration)
        {
            return duration.GetTotalSeconds();
        }


        private static IEnumerable<TestCaseData> GetTotalMilliseconds_TestCaseData()
        {
            yield return new TestCaseData(TimeSpan.FromTicks(5000)).Returns(0.5);
            yield return new TestCaseData(TimeSpan.FromTicks(10000)).Returns(1.0);
            yield return new TestCaseData(TimeSpan.FromTicks(15000)).Returns(1.5);
            yield return new TestCaseData(TimeSpan.FromTicks(15555000)).Returns(1555.5);
            yield return new TestCaseData(null).Returns(null);
        }

        [Test]
        [TestCaseSource("GetTotalMilliseconds_TestCaseData")]
        public static double? TimeUtility_GetTotalMilliseconds(TimeSpan? duration)
        {
            return TimeUtility.GetTotalMilliseconds(duration);
        }

        [Test]
        [TestCaseSource("GetTotalMilliseconds_TestCaseData")]
        public static double? TimeSpanExtensions_GetTotalMilliseconds(TimeSpan? duration)
        {
            return duration.GetTotalMilliseconds();
        }

        static TestCaseData[] GetUnixTimeFromUtcTime_TestCaseData = new[] {
			new TestCaseData(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Returns(0).SetName("epoch"),
			new TestCaseData(new DateTime(1970, 1, 1, 0, 0, 0, 500, DateTimeKind.Utc)).Returns(0.5).SetName("fractional seconds"),
			new TestCaseData(new DateTime(2014, 1, 1, 15, 0, 0, DateTimeKind.Utc)).Returns(1388588400.0d).SetName("random date"),
			new TestCaseData(null).Returns(null),
		};

        [Test]
        [TestCaseSource("GetUnixTimeFromUtcTime_TestCaseData")]
        public static double? TimeUtility_GetUnixTime(DateTime? utcTime)
        {
            var result = TimeUtility.GetUnixTime(utcTime);

            if (utcTime.HasValue)
            {
                var nonNullable = TimeUtility.GetUnixTime(utcTime.Value);
                Assert.AreEqual(nonNullable, result);
            }

            return result;
        }

        [Test]
        public static void TimeUtility_GetDateTimeFromUnixTime()
        {
            var unixTime = TimeSpan.FromHours(12).TotalSeconds;

            Assert.AreEqual(
                new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Unspecified),
                TimeUtility.GetDateTimeFromUnixTime(unixTime));

            // nullable with value
            Assert.AreEqual(
                new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Unspecified),
                TimeUtility.GetDateTimeFromUnixTime((double?)unixTime));

            // nullable without value
            Assert.IsNull(TimeUtility.GetDateTimeFromUnixTime((double?)null));
        }

        public static IEnumerable<TestCaseData> TimeUtility_AddWeekdays_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 05, 05, 16, 00, 00), 1).Returns(new DateTime(2014, 05, 06, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 05, 16, 00, 00), 2).Returns(new DateTime(2014, 05, 07, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 05, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 08, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 06, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 09, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 07, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 12, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 08, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 13, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 09, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 14, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 10, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 14, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 11, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 14, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 12, 16, 00, 00), 3).Returns(new DateTime(2014, 05, 15, 16, 00, 00));

            yield return new TestCaseData(new DateTime(2014, 05, 05, 16, 00, 00), 0).Returns(new DateTime(2014, 05, 05, 16, 00, 00));

            yield return new TestCaseData(new DateTime(2014, 05, 05, 16, 00, 00), -1).Returns(new DateTime(2014, 05, 02, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 05, 16, 00, 00), -2).Returns(new DateTime(2014, 05, 01, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 05, 16, 00, 00), -3).Returns(new DateTime(2014, 04, 30, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 06, 16, 00, 00), -3).Returns(new DateTime(2014, 05, 01, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 07, 16, 00, 00), -3).Returns(new DateTime(2014, 05, 02, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 08, 16, 00, 00), -3).Returns(new DateTime(2014, 05, 05, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 09, 16, 00, 00), -3).Returns(new DateTime(2014, 05, 06, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 10, 16, 00, 00), -3).Returns(new DateTime(2014, 05, 07, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 11, 16, 00, 00), -3).Returns(new DateTime(2014, 05, 07, 16, 00, 00));
            yield return new TestCaseData(new DateTime(2014, 05, 12, 16, 00, 00), -3).Returns(new DateTime(2014, 05, 07, 16, 00, 00));
        }

        [Test]
        [TestCaseSource("TimeUtility_AddWeekdays_TestCases")]
        public static DateTime TimeUtility_AddWeekdays(DateTime value, int weekdaysToAdd)
        {
            return TimeUtility.AddWeekdays(value, weekdaysToAdd);
        }

        [Test]
        [TestCaseSource("TimeUtility_AddWeekdays_TestCases")]
        public static DateTime DateTimeExtensions_AddWeekdays(DateTime value, int weekdaysToAdd)
        {
            return value.AddWeekdays(weekdaysToAdd);
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsSameDayAs_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 23, 59, 59)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 23, 59, 59), new DateTime(2014, 06, 06, 00, 00, 00)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 00, 00, 00), new DateTime(2014, 06, 04, 23, 59, 59)).Returns(false);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsSameDayAs_TestCases")]
        public static bool TimeUtility_IsSameDayAs(DateTime a, DateTime b)
        {
            return TimeUtility.IsSameDayAs(a, b);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsSameDayAs_TestCases")]
        public static bool DateTimeExtensions_IsSameDayAs(DateTime a, DateTime b)
        {
            return a.IsSameDayAs(b);
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsSameDayOrAfter_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 23, 59, 59)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 23, 59, 59), new DateTime(2014, 06, 06, 00, 00, 00)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 00, 00, 00), new DateTime(2014, 06, 04, 23, 59, 59)).Returns(true);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsSameDayOrAfter_TestCases")]
        public static bool TimeUtility_IsSameDayOrAfter(DateTime a, DateTime b)
        {
            return TimeUtility.IsSameDayOrAfter(a, b);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsSameDayOrAfter_TestCases")]
        public static bool DateTimeExtensions_IsSameDayOrAfter(DateTime a, DateTime b)
        {
            return a.IsSameDayOrAfter(b);
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsSameDayOrBefore_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 23, 59, 59)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 23, 59, 59), new DateTime(2014, 06, 06, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 00, 00, 00), new DateTime(2014, 06, 04, 23, 59, 59)).Returns(false);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsSameDayOrBefore_TestCases")]
        public static bool TimeUtility_IsSameDayOrBefore(DateTime a, DateTime b)
        {
            return TimeUtility.IsSameDayOrBefore(a, b);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsSameDayOrBefore_TestCases")]
        public static bool DateTimeExtensions_IsSameDayOrBefore(DateTime a, DateTime b)
        {
            return a.IsSameDayOrBefore(b);
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsAfter_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 23, 59, 59)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 23, 59, 59), new DateTime(2014, 06, 06, 00, 00, 00)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 00, 00, 00), new DateTime(2014, 06, 04, 23, 59, 59)).Returns(true);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsAfter_TestCases")]
        public static bool TimeUtility_IsAfter(DateTime a, DateTime b)
        {
            return TimeUtility.IsAfter(a, b);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsAfter_TestCases")]
        public static bool DateTimeExtensions_IsAfter(DateTime a, DateTime b)
        {
            return a.IsAfter(b);
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsBefore_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 00, 00, 00)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 23, 59, 59)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 23, 59, 59), new DateTime(2014, 06, 06, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 00, 00, 00), new DateTime(2014, 06, 04, 23, 59, 59)).Returns(false);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsBefore_TestCases")]
        public static bool TimeUtility_IsBefore(DateTime a, DateTime b)
        {
            return TimeUtility.IsBefore(a, b);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsBefore_TestCases")]
        public static bool DateTimeExtensions_IsBefore(DateTime a, DateTime b)
        {
            return a.IsBefore(b);
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsOnOrAfter_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 23, 59, 59)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 23, 59, 59), new DateTime(2014, 06, 06, 00, 00, 00)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 00, 00, 00), new DateTime(2014, 06, 04, 23, 59, 59)).Returns(true);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsOnOrAfter_TestCases")]
        public static bool TimeUtility_IsOnOrAfter(DateTime a, DateTime b)
        {
            return TimeUtility.IsOnOrAfter(a, b);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsOnOrAfter_TestCases")]
        public static bool DateTimeExtensions_IsOnOrAfter(DateTime a, DateTime b)
        {
            return a.IsOnOrAfter(b);
        }

        public static IEnumerable<TestCaseData> TimeUtility_IsOnOrBefore_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 00, 00, 00)).Returns(false);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 12, 07, 00), new DateTime(2014, 06, 05, 23, 59, 59)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 23, 59, 59), new DateTime(2014, 06, 06, 00, 00, 00)).Returns(true);
            yield return new TestCaseData(new DateTime(2014, 06, 05, 00, 00, 00), new DateTime(2014, 06, 04, 23, 59, 59)).Returns(false);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsOnOrBefore_TestCases")]
        public static bool TimeUtility_IsOnOrBefore(DateTime a, DateTime b)
        {
            return TimeUtility.IsOnOrBefore(a, b);
        }

        [Test]
        [TestCaseSource("TimeUtility_IsOnOrBefore_TestCases")]
        public static bool DateTimeExtensions_IsOnOrBefore(DateTime a, DateTime b)
        {
            return a.IsOnOrBefore(b);
        }

        public static IEnumerable<TestCaseData> TimeUtility_TruncateToSecondPrecision_DateTime_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified)).Returns(new DateTime(2014, 1, 1, 12, 23, 34, 0, DateTimeKind.Unspecified));
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_DateTime_TestCases")]
        public static DateTime TimeUtility_TruncateToSecondPrecision_DateTime(DateTime value)
        {
            return TimeUtility.TruncateToSecondPrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_DateTime_TestCases")]
        public static DateTime DateTimeExtensions_TruncateToSecondPrecision_DateTime(DateTime value)
        {
            return value.TruncateToSecondPrecision();
        }

        public static IEnumerable<TestCaseData> TimeUtility_TruncateToSecondPrecision_Nullable_TestCases()
        {
            yield return new TestCaseData(null).Returns(null);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_DateTime_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_Nullable_TestCases")]
        public static DateTime? TimeUtility_TruncateToSecondPrecision_DateTime_Nullable(DateTime? value)
        {
            return TimeUtility.TruncateToSecondPrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_DateTime_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_Nullable_TestCases")]
        public static DateTime? DateTimeExtensions_TruncateToSecondPrecision_DateTime_Nullable(DateTime? value)
        {
            return value.TruncateToSecondPrecision();
        }

        public static IEnumerable<TestCaseData> TimeUtility_TruncateToMinutePrecision_DateTime_TestCases()
        {
            yield return new TestCaseData(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified)).Returns(new DateTime(2014, 1, 1, 12, 23, 0, 0, DateTimeKind.Unspecified));
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_DateTime_TestCases")]
        public static DateTime TimeUtility_TruncateToMinutePrecision_DateTime(DateTime value)
        {
            return TimeUtility.TruncateToMinutePrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_DateTime_TestCases")]
        public static DateTime DateTimeExtensions_TruncateToMinutePrecision_DateTime(DateTime value)
        {
            return value.TruncateToMinutePrecision();
        }

        public static IEnumerable<TestCaseData> TimeUtility_TruncateToMinutePrecision_Nullable_TestCases()
        {
            yield return new TestCaseData(null).Returns(null);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_DateTime_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_Nullable_TestCases")]
        public static DateTime? TimeUtility_TruncateToMinutePrecision_DateTime_Nullable(DateTime? value)
        {
            return TimeUtility.TruncateToMinutePrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_DateTime_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_Nullable_TestCases")]
        public static DateTime? DateTimeExtensions_TruncateToMinutePrecision_DateTime_Nullable(DateTime? value)
        {
            return value.TruncateToMinutePrecision();
        }

        public static IEnumerable<TestCaseData> TimeUtility_TruncateToSecondPrecision_TimeSpan_TestCases()
        {
            yield return new TestCaseData(TimeSpan.FromMilliseconds(123456)).Returns(TimeSpan.FromMilliseconds(123000));
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_TimeSpan_TestCases")]
        public static TimeSpan TimeUtility_TruncateToSecondPrecision_TimeSpan(TimeSpan value)
        {
            return TimeUtility.TruncateToSecondPrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_TimeSpan_TestCases")]
        public static TimeSpan TimeSpanExtensions_TruncateToSecondPrecision_TimeSpan(TimeSpan value)
        {
            return value.TruncateToSecondPrecision();
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_TimeSpan_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_Nullable_TestCases")]
        public static TimeSpan? TimeUtility_TruncateToSecondPrecision_TimeSpan_Nullable(TimeSpan? value)
        {
            return TimeUtility.TruncateToSecondPrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_TimeSpan_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToSecondPrecision_Nullable_TestCases")]
        public static TimeSpan? TimeSpanExtensions_TruncateToSecondPrecision_TimeSpan_Nullable(TimeSpan? value)
        {
            return value.TruncateToSecondPrecision();
        }

        public static IEnumerable<TestCaseData> TimeUtility_TruncateToMinutePrecision_TimeSpan_TestCases()
        {
            yield return new TestCaseData(TimeSpan.FromMilliseconds(123456)).Returns(TimeSpan.FromMilliseconds(120000));
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_TimeSpan_TestCases")]
        public static TimeSpan TimeUtility_TruncateToMinutePrecision_TimeSpan(TimeSpan value)
        {
            return TimeUtility.TruncateToMinutePrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_TimeSpan_TestCases")]
        public static TimeSpan TimeSpanExtensions_TruncateToMinutePrecision_TimeSpan(TimeSpan value)
        {
            return value.TruncateToMinutePrecision();
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_TimeSpan_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_Nullable_TestCases")]
        public static TimeSpan? TimeUtility_TruncateToMinutePrecision_TimeSpan_Nullable(TimeSpan? value)
        {
            return TimeUtility.TruncateToMinutePrecision(value);
        }

        [Test]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_TimeSpan_TestCases")]
        [TestCaseSource("TimeUtility_TruncateToMinutePrecision_Nullable_TestCases")]
        public static TimeSpan? TimeSpanExtensions_TruncateToMinutePrecision_TimeSpan_Nullable(TimeSpan? value)
        {
            return value.TruncateToMinutePrecision();
        }

		public static IEnumerable<TestCaseData> TimeUtility_GetHttpTimeString_TestCases()
		{
			yield return new TestCaseData(new DateTime(2014, 1, 2, 13, 34, 45, 56, DateTimeKind.Unspecified)).Returns("Thu, 02 Jan 2014 13:34:45 GMT");
		}

		public static IEnumerable<TestCaseData> TimeUtility_GetHttpTimeString_Nullable_TestCases()
		{
			yield return new TestCaseData(null).Returns(null);
		}

        [Test]
		[TestCaseSource("TimeUtility_GetHttpTimeString_TestCases")]
        public static string TimeUtility_GetHttpTimeString(DateTime value)
        {
			return TimeUtility.GetHttpTimeString(value);
        }

		[Test]
		[TestCaseSource("TimeUtility_GetHttpTimeString_TestCases")]
		[TestCaseSource("TimeUtility_GetHttpTimeString_Nullable_TestCases")]
		public static string TimeUtility_GetHttpTimeString_Nullable(DateTime? value)
		{
			return TimeUtility.GetHttpTimeString(value);
		}

		[Test]
		[TestCaseSource("TimeUtility_GetHttpTimeString_TestCases")]
		public static string DateTimeExtensions_ToHttpTimeString(DateTime value)
		{
			return value.ToHttpTimeString();
		}

		[Test]
		[TestCaseSource("TimeUtility_GetHttpTimeString_TestCases")]
		[TestCaseSource("TimeUtility_GetHttpTimeString_Nullable_TestCases")]
		public static string DateTimeExtensions_ToHttpTimeString_Nullable(DateTime? value)
		{
			return value.ToHttpTimeString();
		}

		public static IEnumerable<TestCaseData> TimeUtility_GetIso8601TimeString_TestCases()
		{
			yield return new TestCaseData(new DateTime(2014, 1, 2, 13, 34, 45, 56, DateTimeKind.Unspecified)).Returns("2014-01-02T13:34:45Z");
		}

		public static IEnumerable<TestCaseData> TimeUtility_GetIso8601TimeString_Nullable_TestCases()
		{
			yield return new TestCaseData(null).Returns(null);
		}

		[Test]
		[TestCaseSource("TimeUtility_GetIso8601TimeString_TestCases")]
		public static string TimeUtility_GetIso8601TimeString(DateTime value)
		{
			return TimeUtility.GetIso8601TimeString(value);
		}

		[Test]
		[TestCaseSource("TimeUtility_GetIso8601TimeString_TestCases")]
		[TestCaseSource("TimeUtility_GetIso8601TimeString_Nullable_TestCases")]
		public static string TimeUtility_GetIso8601TimeString_Nullable(DateTime? value)
		{
			return TimeUtility.GetIso8601TimeString(value);
		}

		[Test]
		[TestCaseSource("TimeUtility_GetIso8601TimeString_TestCases")]
		public static string DateTimeExtensions_ToIso8601TimeString(DateTime value)
		{
			return value.ToIso8601TimeString();
		}

		[Test]
		[TestCaseSource("TimeUtility_GetIso8601TimeString_TestCases")]
		[TestCaseSource("TimeUtility_GetIso8601TimeString_Nullable_TestCases")]
		public static string DateTimeExtensions_ToIso8601TimeString_Nullable(DateTime? value)
		{
			return value.ToIso8601TimeString();
		}

		public static IEnumerable<TestCaseData> TimeUtility_GetSortableTimeString_TestCases()
		{
			yield return new TestCaseData(new DateTime(2014, 1, 2, 13, 34, 45, 56, DateTimeKind.Unspecified)).Returns("2014-01-02T13:34:45");
		}

		public static IEnumerable<TestCaseData> TimeUtility_GetSortableTimeString_Nullable_TestCases()
		{
			yield return new TestCaseData(null).Returns(null);
		}

		[Test]
		[TestCaseSource("TimeUtility_GetSortableTimeString_TestCases")]
		public static string TimeUtility_GetSortableTimeString(DateTime value)
		{
			return TimeUtility.GetSortableTimeString(value);
		}

		[Test]
		[TestCaseSource("TimeUtility_GetSortableTimeString_TestCases")]
		[TestCaseSource("TimeUtility_GetSortableTimeString_Nullable_TestCases")]
		public static string TimeUtility_GetSortableTimeString_Nullable(DateTime? value)
		{
			return TimeUtility.GetSortableTimeString(value);
		}

		[Test]
		[TestCaseSource("TimeUtility_GetSortableTimeString_TestCases")]
		public static string DateTimeExtensions_ToSortableTimeString(DateTime value)
		{
			return value.ToSortableTimeString();
		}

		[Test]
		[TestCaseSource("TimeUtility_GetSortableTimeString_TestCases")]
		[TestCaseSource("TimeUtility_GetSortableTimeString_Nullable_TestCases")]
		public static string DateTimeExtensions_ToSortableTimeString_Nullable(DateTime? value)
		{
			return value.ToSortableTimeString();
		}

    }
}
