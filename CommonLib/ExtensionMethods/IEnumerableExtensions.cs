using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> selector)
		{
			return enumerable.GroupBy(selector).Select(x => x.First());
		}

		private static Random randomizer = new Random();
		public static IEnumerable<T> OrderByRandom<T>(this IEnumerable<T> enumerable)
		{
			return enumerable.OrderBy(x => randomizer.Next());
		}

		public static T FirstRandom<T>(this IEnumerable<T> enumerable)
		{
			var enumerableAsList = (enumerable as IList<T>);

			if (enumerableAsList != null)
			{
				var index = randomizer.Next(enumerableAsList.Count);
				return enumerableAsList[index];
			}
			else
			{
				return enumerable.OrderByRandom().First();
			}
		}

		public static T FirstRandomOrDefault<T>(this IEnumerable<T> enumerable)
		{
			var enumerableAsList = (enumerable as IList<T>);

			if (enumerableAsList != null && enumerableAsList.Count > 0)
			{
				var index = randomizer.Next(enumerableAsList.Count);
				return enumerableAsList[index];
			}
			else
			{
				return enumerable.OrderByRandom().FirstOrDefault();
			}
		}
	}
}
