using System;
using System.Collections.Generic;
using System.Text;

namespace jaytwo.Common.Time
{
	public interface ITimeProvider
	{
		DateTime Now { get; }
		DateTime UtcNow { get; }
	}
}
