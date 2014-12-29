using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.Globalization;

namespace jaytwo.CommonLib.ExtensionMethods
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

		public static NameValueCollection ToHttpValueCollection(this NameValueCollection collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			return collection = HttpUtility.ParseQueryString(string.Empty).AddValues(collection);
		}

		public static string ToPercentEncodedQueryString(this NameValueCollection collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			StringBuilder queryString = new StringBuilder();

			bool isFirst = true;

			for (int i = 0; i < collection.Count; i++)
			{
				var key = collection.GetKey(i);
				var values = collection.GetValues(key);

				foreach (var value in values)
				{
					queryString.Append(isFirst ? null : "&");

					if (key != null)
					{
						queryString.Append(key.PercentEncode());
						queryString.Append("=");
					}

					if (!string.IsNullOrEmpty(value))
					{
						queryString.Append(value.PercentEncode());
					}

					if (isFirst)
					{
						isFirst = false;
					}
				}
			}

			return queryString.ToString();
		}
	}
}
