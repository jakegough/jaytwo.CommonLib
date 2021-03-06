﻿using jaytwo.Common.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace jaytwo.Common.Collections
{
	public static class CollectionUtility
	{
		public static IDictionary<string, string> ToDictionary(NameValueCollection collection)
		{
			return ToDictionary(collection, StringComparer.Ordinal);

		}

		public static IDictionary<string, string> ToDictionary(NameValueCollection collection, StringComparer stringComparer)
		{
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

			var result = new Dictionary<string, string>(stringComparer);

			foreach (var key in collection.AllKeys)
			{
				var values = collection.GetValues(key);

				if (values != null)
				{
					result.Add(key, values[values.Length - 1]);
				}
				else
				{
					result.Add(key, null);
				}
			}

			return result;
		}

		public static string ToPercentEncodedQueryString(NameValueCollection collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}

			var queryString = new StringBuilder();

			var isFirst = true;

			for (int i = 0; i < collection.Count; i++)
			{
				var key = collection.GetKey(i);
				var values = collection.GetValues(key);

				foreach (var value in values)
				{
					queryString.Append(isFirst ? null : "&");

					if (key != null)
					{
						queryString.Append(UrlHelper.PercentEncode(key));
						queryString.Append("=");
					}

					if (!string.IsNullOrEmpty(value))
					{
						queryString.Append(UrlHelper.PercentEncode(value));
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
