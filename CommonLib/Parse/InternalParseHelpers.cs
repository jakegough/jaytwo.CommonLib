using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace jaytwo.Common.Parse
{
	internal static class InternalParseHelpers
	{
		public static bool IsBoolStylesMatch(BoolStyles expected, BoolStyles actual)
		{
			return ((actual & expected) > 0);
		}

		private static readonly Regex zeroIntRegex = new Regex("^0+$", RegexOptions.Compiled);
		public static bool IsZeroInt(string value)
		{
			return zeroIntRegex.IsMatch(value);
		}

		private static readonly Regex oneIntRegex = new Regex("^0*1$", RegexOptions.Compiled);
		public static bool IsOneInt(string value)
		{
			return oneIntRegex.IsMatch(value);
		}

		private static readonly Regex nonZeroIntRegex = new Regex(@"^[-]?0*[1-9]\d*$", RegexOptions.Compiled);
		public static bool IsNonZeroInt(string value)
		{
			return nonZeroIntRegex.IsMatch(value);
		}
	}
}
