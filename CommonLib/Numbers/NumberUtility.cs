using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jaytwo.CommonLib.Numbers
{
	public static class NumberUtility
	{
		public static double StandardDeviation(IEnumerable<double> data)
		{
			var average = data.Average();
			var individualDeviations = data.Select(x => Math.Pow(x - average, 2));
			return Math.Sqrt(individualDeviations.Average());
		}

		public static double StandardDeviation(params double[] data)
		{
			return StandardDeviation((IEnumerable<double>)data);
		}

		public static byte Min(params byte[] values)
		{
			return values.Min();
		}

		public static sbyte Min(params sbyte[] values)
		{
			return values.Min();
		}

		public static short Min(params short[] values)
		{
			return values.Min();
		}

		public static ushort Min(params ushort[] values)
		{
			return values.Min();
		}

		public static int Min(params int[] values)
		{
			return values.Min();
		}

		public static uint Min(params uint[] values)
		{
			return values.Min();
		}

		public static long Min(params long[] values)
		{
			return values.Min();
		}

		public static ulong Min(params ulong[] values)
		{
			return values.Min();
		}

		public static decimal Min(params decimal[] values)
		{
			return values.Min();
		}

		public static float Min(params float[] values)
		{
			return values.Min();
		}

		public static double Min(params double[] values)
		{
			return values.Min();
		}

		public static DateTime Min(params DateTime[] values)
		{
			return values.Min();
		}

		public static byte Max(params byte[] values)
		{
			return values.Max();
		}

		public static sbyte Max(params sbyte[] values)
		{
			return values.Max();
		}

		public static short Max(params short[] values)
		{
			return values.Max();
		}

		public static ushort Max(params ushort[] values)
		{
			return values.Max();
		}

		public static int Max(params int[] values)
		{
			return values.Max();
		}

		public static uint Max(params uint[] values)
		{
			return values.Max();
		}

		public static long Max(params long[] values)
		{
			return values.Max();
		}

		public static ulong Max(params ulong[] values)
		{
			return values.Max();
		}

		public static decimal Max(params decimal[] values)
		{
			return values.Max();
		}

		public static float Max(params float[] values)
		{
			return values.Max();
		}

		public static double Max(params double[] values)
		{
			return values.Max();
		}

		public static DateTime Max(params DateTime[] values)
		{
			return values.Min();
		}
	}
}