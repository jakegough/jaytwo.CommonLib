using System;
using System.Collections.Generic;
using System.Text;

namespace jaytwo.Common.Time
{
	public static class TimeProvider
	{
		private static ITimeProvider _provider;

		public static void SetProvider(ITimeProvider provider)
		{
			_provider = provider;
		}

		private static void SetDefaultProviderIfNotSet()
		{
			if (_provider == null)
			{
				SetProvider(new DefaultTimeProvider());
			}			
		}

		public static DateTime Now
		{
			get
			{
				SetDefaultProviderIfNotSet();
				return _provider.Now;
			}			
		}

		public static DateTime UtcNow
		{
			get
			{
				SetDefaultProviderIfNotSet();
				return _provider.UtcNow;
			}
		}
	}
}
