using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.Globalization;
using jaytwo.Common.System;
using jaytwo.Common.Http;
using jaytwo.Common.Collections;

namespace jaytwo.Common.Extensions
{
	public static class NameValueCollectionExtensions
	{
		public static NameValueCollection AddValues(this NameValueCollection collection, NameValueCollection collectionToAdd)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			collection.Add(collectionToAdd);
			return collection;
		}

		public static NameValueCollection AddValue(this NameValueCollection collection, string name, string value)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			collection.Add(name, value);
			return collection;
		}

		public static NameValueCollection AddValue(this NameValueCollection collection, string name, object value)
		{
			return AddValue<object>(collection, name, value);
		}

		public static NameValueCollection AddValue<T>(this NameValueCollection collection, string name, T value)
		{
			var valueAsString = string.Format(CultureInfo.InvariantCulture, "{0}", value);
			return AddValue(collection, name, valueAsString);
		}

		public static NameValueCollection ClearValues(this NameValueCollection collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			collection.Clear();
			return collection;
		}

		public static NameValueCollection RemoveValue(this NameValueCollection collection, string name)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			collection.Remove(name);
			return collection;
		}

		public static NameValueCollection SetValue(this NameValueCollection collection, string name, string value)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			collection.Set(name, value);
			return collection;
		}

		public static NameValueCollection SetValue(this NameValueCollection collection, string name, object value)
		{
			return SetValue<object>(collection, name, value);
		}

		public static NameValueCollection SetValue<T>(this NameValueCollection collection, string name, T value)
		{
			var valueAsString = string.Format(CultureInfo.InvariantCulture, "{0}", value);
			return SetValue(collection, name, valueAsString);
		}

		public static string ToPercentEncodedQueryString(this NameValueCollection collection)
		{
			return CollectionUtility.ToPercentEncodedQueryString(collection);
		}

		public static IDictionary<string, string> ToDictionary(this NameValueCollection collection)
		{
			return CollectionUtility.ToDictionary(collection);
		}

		public static IDictionary<string, string> ToDictionary(this NameValueCollection collection, StringComparer stringComparer)
		{
			return CollectionUtility.ToDictionary(collection, stringComparer);
		}

#if NET_4_0
		public static dynamic ToDynamic(this NameValueCollection collection)
		{
			return DynamicDictionary.FromNameValueCollection(collection);
		}

		public static dynamic ToDynamic(this NameValueCollection collection, StringComparer stringComparer)
		{
			return DynamicDictionary.FromNameValueCollection(collection, stringComparer);
		}
#endif
	}
}