using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;
using System.Collections;
using System.Reflection;

namespace jaytwo.Common.Futures
{
	internal static class PolyNavigatorHelpers
	{
		public static Dictionary<string, object> ToDictionaryOfStringObject(IDictionary dictionary, StringComparer stringComparer)
		{
			var result = new Dictionary<string, object>();

			var enumerator = dictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string key = enumerator.Key.ToString();

				if (!result.ContainsKey(key))
				{
					object value;

					if (enumerator.Value is IDictionary)
					{
						value = ToDictionaryOfStringObject((IDictionary)enumerator.Value, stringComparer);
					}
					else
					{
						value = enumerator.Value;
					}

					result[key] = value;
				}
			}

			return result;
		}

		public static bool TryGetDictionaryValue(IDictionary dictionary, string key, StringComparer stringComparer, out object result)
		{
			result = null;
			var success = false;

			if (dictionary != null)
			{
				var theKey = dictionary.Keys.Cast<object>().FirstOrDefault(x => StringEquals(x, key, stringComparer));

				if (theKey != null)
				{
					result = dictionary[theKey];
					success = true;
				}
			}

			return success;
		}

		public static bool TryGetListValue(IList list, string key, out object result)
		{
			result = null;
			var success = false;

			var index = key.TryParseInt32();

			if (list != null && index.HasValue && list.Count > index.Value)
			{
				result = list[index.Value];
				success = true;
			}

			return success;
		}

		public static bool TryGetReflectionValue(object value, string propertyName, StringComparer stringComparer, out object result)
		{
			result = null;
			var success = false;

			if (value != null)
			{
				var properties = value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.CanRead);
				var theProperty = properties.FirstOrDefault(x => StringEquals(x.Name, propertyName, stringComparer));
				
				if (theProperty != null)
				{
					result = theProperty.GetValue(value, null);
					success = true;
				}				
			}
			
			return success;
		}

		public static bool StringEquals(object a, string b, StringComparer stringComparer)
		{
			if (stringComparer != null)
			{
				return stringComparer.Equals(a, b);
			}
			else
			{
				return string.Equals(a, b);
			}
		}

		public static bool StringEquals(string a, string b, StringComparer stringComparer)
		{
			if (stringComparer != null)
			{
				return stringComparer.Equals(a, b);
			}
			else
			{
				return string.Equals(a, b);
			}
		}
	}
}
