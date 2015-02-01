using System;
using System.Collections.Generic;
using System.Text;

namespace jaytwo.Common.Parse
{
	[Flags]
	public enum BoolStyles
	{
		None = 0,
		TrimWhiteSpace = 1,
		Default = 2,
		TrueFalse = 4,
		TF = 8,
		YesNo = 16,
		YN = 32,
		ZeroOne = 64,
		ZeroNonzero = 128,
        Any = 255,
	}
}
