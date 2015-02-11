#if NET_4_0
using System.Dynamic;
#endif

using jaytwo.Common.Appendix;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace jaytwo.Common.Collections
{
    public class DynamicDictionary :
#if NET_4_0
		DynamicObject,
#endif
		IDictionary,
		IDictionary<string, object>
	{
        public static DynamicDictionary FromNameValueCollection(NameValueCollection collection)
        {
            return FromNameValueCollection(collection, StringComparer.Ordinal);
        }

        public static DynamicDictionary FromNameValueCollection(NameValueCollection collection, StringComparer stringComparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            var result = new Dictionary<string, object>(stringComparer);

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

            return new DynamicDictionary(result);
        }

        public static DynamicDictionary FromDictionary(IDictionary dictionary)
        {
            return FromDictionary(dictionary, StringComparer.Ordinal);
        }

        public static DynamicDictionary FromDictionary(IDictionary dictionary, StringComparer stringComparer)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            var result = new DynamicDictionary(stringComparer);
            var resultDictionary = result as IDictionary<string, object>;

			foreach (var key in dictionary.Keys)
            {
				var keyString = Convert.ToString(key);
				var value = dictionary[key];
				var innerDictionary = value as IDictionary;

                if (innerDictionary != null)
                {
					resultDictionary.Add(keyString, FromDictionary(innerDictionary, stringComparer));
                }
                else
                {
					var valueString = Convert.ToString(value);
					resultDictionary.Add(keyString, valueString);
                }
            }

            return result;
        }

		public static DynamicDictionary FromObject(object value)
		{
			return FromObject(value, StringComparer.Ordinal);
		}

		public static DynamicDictionary FromObject(object value, StringComparer stringComparer)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			var json = InternalScabHelpers.SerializeToJson(value);
			var dictionary = InternalScabHelpers.DeserializeJson<IDictionary>(json);
			return FromDictionary(dictionary, stringComparer);
		}

#if NET_4_0
        public static dynamic CreateDynamic(NameValueCollection collection)
        {
            return FromNameValueCollection(collection).AsDynamic();
        }

        public static dynamic CreateDynamic(NameValueCollection collection, StringComparer stringComparer)
        {
            return FromNameValueCollection(collection, stringComparer).AsDynamic(); 
        }

        public static dynamic CreateDynamic(IDictionary dictionary)
        {
            return FromDictionary(dictionary).AsDynamic();
        }

        public static dynamic CreateDynamic(IDictionary dictionary, StringComparer stringComparer)
        {
            return FromDictionary(dictionary, stringComparer).AsDynamic();
        }

		public static dynamic CreateDynamic(object value)
		{
			return FromObject(value).AsDynamic();
		}

		public static dynamic CreateDynamic(object value, StringComparer stringComparer)
		{
			return FromObject(value, stringComparer).AsDynamic();
		}
#endif

        public static IDictionary<string, object> CreateDictionary(NameValueCollection collection)
        {
            return FromNameValueCollection(collection).AsDictionary();
        }

        public static IDictionary<string, object> CreateDictionary(NameValueCollection collection, StringComparer stringComparer)
        {
            return FromNameValueCollection(collection, stringComparer).AsDictionary();
        }

        public static IDictionary<string, object> CreateDictionary(IDictionary dictionary)
        {
            return FromDictionary(dictionary).AsDictionary();
        }

        public static IDictionary<string, object> CreateDictionary(IDictionary dictionary, StringComparer stringComparer)
        {
            return FromDictionary(dictionary, stringComparer).AsDictionary();
        }

		public static IDictionary<string, object> CreateDictionary(object value)
		{
			return FromObject(value).AsDictionary();
		}

		public static IDictionary<string, object> CreateDictionary(object value, StringComparer stringComparer)
		{
			return FromObject(value, stringComparer).AsDictionary();
		}

        private IDictionary<string, object> innerDictionary;

        public DynamicDictionary(IDictionary<string, object> innerDictionary)
            : base()
        {
            this.innerDictionary = innerDictionary;
        }

        public DynamicDictionary(StringComparer stringComparer)
            : this(new Dictionary<string, object>(stringComparer))
        {
        }

        public DynamicDictionary()
            : this(new Dictionary<string, object>())
        {
        }

		public object this[string key]
		{
			get
			{
				return innerDictionary[key];
			}
			set
			{
				innerDictionary[key] = value;
			}
		}

#if NET_4_0
		public dynamic AsDynamic()
        {
            return this;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (binder != null)
            {
                try
                {
                    innerDictionary[binder.Name] = value;
                    return true;
                }
                catch
                {
                }
            }
            
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder != null)
            {
                try
                {
                    return innerDictionary.TryGetValue(binder.Name, out result);
                }
                catch
                {                    
                }
            }

            result = null;
            return false;
        }
#endif

		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary)innerDictionary)[key];
			}
			set
			{
				((IDictionary)innerDictionary)[key] = value;
			}
		}

		public IDictionary<string, object> AsDictionary()
		{
			return this;
		}

		void IDictionary<string, object>.Add(string key, object value)
        {
            ((IDictionary<string, object>)innerDictionary).Add(key, value);
        }

		void IDictionary.Add(object key, object value)
		{
			((IDictionary)innerDictionary).Add(key, value);
		}

        bool IDictionary<string, object>.ContainsKey(string key)
        {
            return ((IDictionary<string, object>)innerDictionary).ContainsKey(key);
        }

        ICollection<string> IDictionary<string, object>.Keys
        {
            get { return ((IDictionary<string, object>)innerDictionary).Keys; }
        }

		ICollection IDictionary.Keys
		{
			get { return ((IDictionary)innerDictionary).Keys; }
		}

        bool IDictionary<string, object>.Remove(string key)
        {
            return ((IDictionary<string, object>)innerDictionary).Remove(key);
        }

		void IDictionary.Remove(object key)
		{
			((IDictionary)innerDictionary).Remove(key);
		}

        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            return ((IDictionary<string, object>)innerDictionary).TryGetValue(key, out value);
        }

        ICollection<object> IDictionary<string, object>.Values
        {
            get { return ((IDictionary<string, object>)innerDictionary).Values; }
        }

		ICollection IDictionary.Values
		{
			get { return ((IDictionary)innerDictionary).Values; }
		}

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            ((ICollection<KeyValuePair<string, object>>)innerDictionary).Add(item);
        }

        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            ((ICollection<KeyValuePair<string, object>>)innerDictionary).Clear();
        }

		void IDictionary.Clear()
		{
			((IDictionary)innerDictionary).Clear();
		}

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)innerDictionary).Contains(item);
        }

		bool IDictionary.Contains(object key)
		{
			return ((IDictionary)innerDictionary).Contains(key);
		}

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)innerDictionary).CopyTo(array, arrayIndex);
        }

		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			((ICollection)innerDictionary).CopyTo(array, arrayIndex);
		}

        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { return ((ICollection<KeyValuePair<string, object>>)innerDictionary).Count; }
        }

		int ICollection.Count
		{
			get { return ((ICollection)innerDictionary).Count; }
		}

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<string, object>>)innerDictionary).IsReadOnly; }
        }

		bool IDictionary.IsReadOnly
		{
			get { return ((IDictionary)innerDictionary).IsReadOnly; }
		}

		bool IDictionary.IsFixedSize
		{
			get { return ((IDictionary)innerDictionary).IsFixedSize; }
		}

		bool ICollection.IsSynchronized
		{
			get { return ((IDictionary)innerDictionary).IsSynchronized; }
		}

        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)innerDictionary).Remove(item);
        }

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, object>>)innerDictionary).GetEnumerator();
        }

		IEnumerator IEnumerable.GetEnumerator()
        {
			return ((IEnumerable)innerDictionary).GetEnumerator();
        }

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)innerDictionary).GetEnumerator();
		}

		object ICollection.SyncRoot
		{
			get { return ((ICollection)innerDictionary).SyncRoot; }
		}
    }
}