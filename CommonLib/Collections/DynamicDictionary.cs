#if GTENET40

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace jaytwo.Common.Collections
{
    public class DynamicDictionary : DynamicObject, IDictionary<string, object>
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

        public static DynamicDictionary FromDictionary(IDictionary<string, object> dictionary)
        {
            return FromDictionary(dictionary, StringComparer.Ordinal);
        }

        public static DynamicDictionary FromDictionary(IDictionary<string, object> dictionary, StringComparer stringComparer)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            var result = new DynamicDictionary(stringComparer);
            var resultDictionary = result as IDictionary<string, object>;

            foreach (var item in dictionary)
            {
                var innerDictionary = item.Value as IDictionary<string, object>;

                if (innerDictionary != null)
                {
                    resultDictionary.Add(item.Key, FromDictionary(innerDictionary, stringComparer));
                }
                else
                {
                    resultDictionary.Add(item.Key, item.Value);
                }
            }

            return result;
        }

        public static dynamic CreateDynamic(NameValueCollection collection)
        {
            return FromNameValueCollection(collection).AsDynamic();
        }

        public static dynamic CreateDynamic(NameValueCollection collection, StringComparer stringComparer)
        {
            return FromNameValueCollection(collection, stringComparer).AsDynamic(); 
        }

        public static dynamic CreateDynamic(IDictionary<string, object> dictionary)
        {
            return FromDictionary(dictionary).AsDynamic();
        }

        public static dynamic CreateDynamic(IDictionary<string, object> dictionary, StringComparer stringComparer)
        {
            return FromDictionary(dictionary, stringComparer).AsDynamic();
        }

        public static IDictionary<string, object> CreateDictionary(NameValueCollection collection)
        {
            return FromNameValueCollection(collection).AsDictionary();
        }

        public static IDictionary<string, object> CreateDictionary(NameValueCollection collection, StringComparer stringComparer)
        {
            return FromNameValueCollection(collection, stringComparer).AsDictionary();
        }

        public static IDictionary<string, object> CreateDictionary(IDictionary<string, object> dictionary)
        {
            return FromDictionary(dictionary).AsDictionary();
        }

        public static IDictionary<string, object> CreateDictionary(IDictionary<string, object> dictionary, StringComparer stringComparer)
        {
            return FromDictionary(dictionary, stringComparer).AsDictionary();
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

        public dynamic AsDynamic()
        {
            return this;
        }

        public IDictionary<string, object> AsDictionary()
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

        void IDictionary<string, object>.Add(string key, object value)
        {
            ((IDictionary<string, object>)innerDictionary).Add(key, value);
        }

        bool IDictionary<string, object>.ContainsKey(string key)
        {
            return ((IDictionary<string, object>)innerDictionary).ContainsKey(key);
        }

        ICollection<string> IDictionary<string, object>.Keys
        {
            get { return ((IDictionary<string, object>)innerDictionary).Keys; }
        }

        bool IDictionary<string, object>.Remove(string key)
        {
            return ((IDictionary<string, object>)innerDictionary).Remove(key);
        }

        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            return ((IDictionary<string, object>)innerDictionary).TryGetValue(key, out value);
        }

        ICollection<object> IDictionary<string, object>.Values
        {
            get { return ((IDictionary<string, object>)innerDictionary).Values; }
        }

        object IDictionary<string, object>.this[string key]
        {
            get
            {
                return ((IDictionary<string, object>)innerDictionary)[key];
            }
            set
            {
                ((IDictionary<string, object>)innerDictionary)[key] = value;
            }
        }

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            ((ICollection<KeyValuePair<string, object>>)innerDictionary).Add(item);
        }

        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            ((ICollection<KeyValuePair<string, object>>)innerDictionary).Clear();
        }

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)innerDictionary).Contains(item);
        }

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)innerDictionary).CopyTo(array, arrayIndex);
        }

        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { return ((ICollection<KeyValuePair<string, object>>)innerDictionary).Count; }
        }

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<string, object>>)innerDictionary).IsReadOnly; }
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
    }
}

#endif