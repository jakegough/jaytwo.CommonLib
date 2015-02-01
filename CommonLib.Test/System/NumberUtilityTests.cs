using jaytwo.Common.System;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.System
{
    [TestFixture]
    public static class NumberUtilityTests
    {
        public static IEnumerable<TestCaseData> NumberUtility_Max_Byte_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new byte[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new byte[] { 1, 0, 5, 5, 2, 1 }).Returns((byte)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_Byte_TestCases")]
        public static byte NumberUtility_Max_Byte(byte[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Max_Int16_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new short[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new short[] { -1, 0, -5, 5, 2, 1 }).Returns((short)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_Int16_TestCases")]
        public static short NumberUtility_Max_Int16(short[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Max_Int32_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new int[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new int[] { -1, 0, -5, 5, 2, 1 }).Returns((int)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_Int32_TestCases")]
        public static int NumberUtility_Max_Int32(int[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Max_Int64_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new long[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new long[] { -1, 0, -5, 5, 2, 1 }).Returns((long)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_Int64_TestCases")]
        public static long NumberUtility_Max_Int64(long[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Max_UInt64_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new ulong[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new ulong[] { 1, 0, 5, 5, 2, 1 }).Returns((ulong)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_UInt64_TestCases")]
        public static ulong NumberUtility_Max_UInt64(ulong[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Max_Single_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new float[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new float[] { -1, 0, -5, 5, 2, 1 }).Returns((float)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_Single_TestCases")]
        public static float NumberUtility_Max_Single(float[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Max_Double_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new double[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new double[] { -1, 0, -5, 5, 2, 1 }).Returns((double)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_Double_TestCases")]
        public static double NumberUtility_Max_Double(double[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Max_Decimal_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new decimal[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new decimal[] { -1, 0, -5, 5, 2, 1 }).Returns((decimal)5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_Decimal_TestCases")]
        public static decimal NumberUtility_Max_Decimal(decimal[] values)
        {
            return NumberUtility.Max(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_Byte_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new byte[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new byte[] { 1, 0, 5, 5, 2, 1 }).Returns((byte)0);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_Byte_TestCases")]
        public static byte NumberUtility_Min_Byte(byte[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_Int16_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new short[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new short[] { -1, 0, -5, 5, 2, 1 }).Returns((short)-5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_Int16_TestCases")]
        public static short NumberUtility_Min_Int16(short[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_Int32_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new int[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new int[] { -1, 0, -5, 5, 2, 1 }).Returns((int)-5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_Int32_TestCases")]
        public static int NumberUtility_Min_Int32(int[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_Int64_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new long[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new long[] { -1, 0, -5, 5, 2, 1 }).Returns((long)-5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_Int64_TestCases")]
        public static long NumberUtility_Min_Int64(long[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_UInt64_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new ulong[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new ulong[] { 1, 0, 5, 5, 2, 1 }).Returns((ulong)0);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_UInt64_TestCases")]
        public static ulong NumberUtility_Min_UInt64(ulong[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_Single_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new float[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new float[] { -1, 0, -5, 5, 2, 1 }).Returns((float)-5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_Single_TestCases")]
        public static float NumberUtility_Min_Single(float[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_Double_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new double[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new double[] { -1, 0, -5, 5, 2, 1 }).Returns((double)-5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_Double_TestCases")]
        public static double NumberUtility_Min_Double(double[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_Decimal_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new decimal[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new decimal[] { -1, 0, -5, 5, 2, 1 }).Returns((decimal)-5);
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_Decimal_TestCases")]
        public static decimal NumberUtility_Min_Decimal(decimal[] values)
        {
            return NumberUtility.Min(values);
        }

        public static IEnumerable<TestCaseData> NumberUtility_Min_DateTime_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new DateTime[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(
                new[]  
                { 
                    new DateTime(2001, 1, 1), 
                    new DateTime(2000, 1, 1), 
                    new DateTime(2005, 1, 1), 
                    new DateTime(2005, 1, 1), 
                    new DateTime(2002, 1, 1), 
                    new DateTime(2001, 1, 1), 
                }).Returns(new DateTime(2000, 1, 1));
        }

        [Test]
        [TestCaseSource("NumberUtility_Min_DateTime_TestCases")]
        public static DateTime NumberUtility_Min_DateTime(DateTime[] values)
        {
            return NumberUtility.Min(values);
        }


        public static IEnumerable<TestCaseData> NumberUtility_Max_DateTime_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new DateTime[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(
                new[]  
                { 
                    new DateTime(2001, 1, 1), 
                    new DateTime(2000, 1, 1), 
                    new DateTime(2005, 1, 1), 
                    new DateTime(2005, 1, 1), 
                    new DateTime(2002, 1, 1), 
                    new DateTime(2001, 1, 1), 
                }).Returns(new DateTime(2005, 1, 1));
        }

        [Test]
        [TestCaseSource("NumberUtility_Max_DateTime_TestCases")]
        public static DateTime NumberUtility_Max_DateTime(DateTime[] values)
        {
            return NumberUtility.Max(values);
        }
    }
}
