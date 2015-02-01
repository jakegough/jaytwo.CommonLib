using System;
using System.Collections.Generic;
using System.Text;

namespace jaytwo.Common.Parse
{
    public static partial class ParseUtility
    {
		public static bool ParseBoolean(string value)
		{
			return ParseBoolean(value, BoolStyles.Any);
		}

		public static bool ParseBoolean(string value, BoolStyles styles)
		{
			bool? result = null;

			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			if (value.Trim().Length > 0)
			{
				if (InternalParseHelpers.IsBoolStylesMatch(BoolStyles.TrimWhiteSpace, styles))
				{
					value = value.Trim();
				}

				if (!result.HasValue && InternalParseHelpers.IsBoolStylesMatch(BoolStyles.TF, styles))
				{
					if (string.Equals(value, "T", StringComparison.OrdinalIgnoreCase))
					{
						result = true;
					}
					else if (string.Equals(value, "F", StringComparison.OrdinalIgnoreCase))
					{
						result = false;
					}
				}

				if (!result.HasValue && InternalParseHelpers.IsBoolStylesMatch(BoolStyles.TrueFalse, styles))
				{
					if (string.Equals(value, "True", StringComparison.OrdinalIgnoreCase))
					{
						result = true;
					}
					else if (string.Equals(value, "False", StringComparison.OrdinalIgnoreCase))
					{
						result = false;
					}
				}

				if (!result.HasValue && InternalParseHelpers.IsBoolStylesMatch(BoolStyles.YesNo, styles))
				{
					if (string.Equals(value, "Yes", StringComparison.OrdinalIgnoreCase))
					{
						result = true;
					}
					else if (string.Equals(value, "No", StringComparison.OrdinalIgnoreCase))
					{
						result = false;
					}
				}

				if (!result.HasValue && InternalParseHelpers.IsBoolStylesMatch(BoolStyles.YN, styles))
				{
					if (string.Equals(value, "Y", StringComparison.OrdinalIgnoreCase))
					{
						result = true;
					}
					else if (string.Equals(value, "N", StringComparison.OrdinalIgnoreCase))
					{
						result = false;
					}
				}

				if (!result.HasValue && InternalParseHelpers.IsBoolStylesMatch(BoolStyles.ZeroOne, styles))
				{
					if (InternalParseHelpers.IsZeroInt(value))
					{
						result = false;
					}
					else if (InternalParseHelpers.IsOneInt(value))
					{
						result = true;
					}
				}

				if (!result.HasValue && InternalParseHelpers.IsBoolStylesMatch(BoolStyles.ZeroNonzero, styles))
				{
					if (InternalParseHelpers.IsZeroInt(value))
					{
						result = false;
					}
					else if (InternalParseHelpers.IsNonZeroInt(value))
					{
						result = true;
					}
				}

				if (!result.HasValue && (styles <= BoolStyles.Default))
				{
					result = bool.Parse(value);
				}
			}

			if (!result.HasValue)
			{
				throw new FormatException("String was not recognized as a valid Boolean.");
			}

			return result.Value;
		}

		public static bool? TryParseBoolean(string value)
		{
			try
			{
				return ParseBoolean(value);
			}
			catch
			{
				return null;
			}
		}

		public static bool? TryParseBoolean(string value, BoolStyles styles)
		{
			try
			{
				return ParseBoolean(value, styles);
			}
			catch
			{
				return null;
			}
		}
    }
}
