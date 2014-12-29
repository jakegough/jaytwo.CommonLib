using jaytwo.CommonLib.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class NumberExtensions
	{
		public static double StandardDeviation(this IEnumerable<double> data)
		{
			return NumberUtility.StandardDeviation(data);
		}
	}
}
