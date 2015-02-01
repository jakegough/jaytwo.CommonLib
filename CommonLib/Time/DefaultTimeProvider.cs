using System;
using System.Collections.Generic;
using System.Text;

namespace jaytwo.Common.Time
{
	public class DefaultTimeProvider : ITimeProvider
	{
		public DateTime Now
		{
			get
			{
				return DateTime.Now;
			}
		}

		public DateTime UtcNow
		{
			get
			{
				return DateTime.UtcNow;
			}
		}
	}
}
