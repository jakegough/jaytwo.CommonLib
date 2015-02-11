using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jaytwo.Common.Futures.Numbers
{
	public static class MathUtility
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
	}
}