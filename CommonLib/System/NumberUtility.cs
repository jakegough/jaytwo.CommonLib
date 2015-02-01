using System.Linq;
using System;
using System.Collections.Generic;
using System.Web;

namespace jaytwo.Common.System
{
    public static class NumberUtility
    {
        public static byte Min(params byte[] values)
        {
            return Min<byte>(values);
        }

        public static short Min(params short[] values)
        {
            return Min<short>(values);
        }

        public static int Min(params int[] values)
        {
            return Min<int>(values);
        }

        public static long Min(params long[] values)
        {
            return Min<long>(values);
        }

        public static decimal Min(params decimal[] values)
        {
            return Min<decimal>(values);
        }

        public static float Min(params float[] values)
        {
            return Min<float>(values);
        }

        public static double Min(params double[] values)
        {
            return Min<double>(values);
        }

        public static DateTime Min(params DateTime[] values)
        {
            return Min<DateTime>(values);
        }

        public static byte Max(params byte[] values)
        {
            return Max<byte>(values);
        }

        public static short Max(params short[] values)
        {
            return Max<short>(values);
        }

        public static int Max(params int[] values)
        {
            return Max<int>(values);
        }

        public static long Max(params long[] values)
        {
            return Max<long>(values);
        }

        public static decimal Max(params decimal[] values)
        {
            return Max<decimal>(values);
        }

        public static float Max(params float[] values)
        {
            return Max<float>(values);
        }

        public static double Max(params double[] values)
        {
            return Max<double>(values);
        }

        public static DateTime Max(params DateTime[] values)
        {
            return Max<DateTime>(values);
        }

        public static T Min<T>(params T[] values) where T : IComparable<T>
        {
            return values.Min();
        }

        public static T Max<T>(params T[] values) where T : IComparable<T>
        {
            return values.Max();
        }

    }
}