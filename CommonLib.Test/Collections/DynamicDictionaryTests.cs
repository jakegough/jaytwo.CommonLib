#if NET_4_0

using jaytwo.Common.Collections;
using jaytwo.Common.Http;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Collections
{
    [TestFixture]
    public class DynamicDictionaryTests
    {
        [Test]
        public void DynamicDictionary_DynamicGetSet()
        {
            var target = CreateTarget();
            dynamic targetDynamic = target;

            target.Add("one", "foo");
            Assert.AreEqual("foo", targetDynamic.one);

            targetDynamic.one = "bar";
            Assert.AreEqual("bar", targetDynamic.one);
        }

        [Test]
        public void DynamicDictionary_TrySetMember_fail()
        {
            var target = new DynamicDictionary();
            Assert.IsFalse(target.TrySetMember(null, "hello"));
        }

        [Test]
        public void DynamicDictionary_TryGetMember_fail()
        {
            var target = new DynamicDictionary();
            object result;
            Assert.IsFalse(target.TryGetMember(null, out result));
        }

        [Test]
        public static void DynamicDictionary_StringComparer_Ordinal()
        {
            var expando = (IDictionary<string, object>)new DynamicDictionary(StringComparer.Ordinal);
            expando.Add("key", "value");

            Assert.AreEqual("value", expando["key"]);
            Assert.IsTrue(expando.ContainsKey("key"));
            Assert.IsFalse(expando.ContainsKey("Key"));
            Assert.IsFalse(expando.ContainsKey("foo"));
        }

        [Test]
        public static void DynamicDictionary_StringComparer_OrdinalIgnoreCase()
        {
            var expando = (IDictionary<string, object>)new DynamicDictionary(StringComparer.OrdinalIgnoreCase);
            expando.Add("key", "value");

            Assert.AreEqual("value", expando["key"]);
            Assert.IsTrue(expando.ContainsKey("key"));
            Assert.IsTrue(expando.ContainsKey("Key"));
            Assert.AreEqual("value", expando["Key"]);
            Assert.IsFalse(expando.ContainsKey("foo"));
        }

        // https://github.com/markrendle/InterfaceTests.Net

        private IDictionary<string, object> CreateTarget()
        {
            return new DynamicDictionary(StringComparer.Ordinal);
        }

        private KeyValuePair<string, object> CreateEntry(int seed)
        {
            //TODO: Create an entry using the seed for key/value uniqueness
            return new KeyValuePair<string, object>(seed.ToString(), seed);
        }

        [Test]
        public void DynamicDictionary_Add_KeyValuePair()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);

            target.Add(entry);

            Assert.AreEqual(1, target.Count);
            Assert.IsTrue(target.ContainsKey(entry.Key));
            Assert.AreEqual(entry.Value, target[entry.Key]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DynamicDictionary_Add_DuplicateKeyValuePairShouldThrow()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);

            target.Add(entry);
            target.Add(entry);
        }

        [Test]
        public void DynamicDictionary_Add_KeyAndValue()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);

            target.Add(entry.Key, entry.Value);

            Assert.AreEqual(1, target.Count);
            Assert.IsTrue(target.ContainsKey(entry.Key));
            Assert.AreEqual(entry.Value, target[entry.Key]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DynamicDictionary_Add_DuplicateKeyAndValueShouldThrow()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);

            target.Add(entry.Key, entry.Value);
            target.Add(entry.Key, entry.Value);
        }

        [Test]
        public void DynamicDictionary_AfterClearCountShouldBeZero()
        {
            var target = CreateTarget();
            target.Add(CreateEntry(0));
            target.Add(CreateEntry(1));
            target.Clear();

            Assert.AreEqual(0, target.Count);
        }

        [Test]
        public void DynamicDictionary_Contains_ShouldReturnTrueForValidEntry()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);
            Assert.IsTrue(target.Contains(entry));
        }

        [Test]
        public void DynamicDictionary_Contains_ShouldReturnFalseForInvalidEntry()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            Assert.IsFalse(target.Contains(entry));
        }

        [Test]
        public void DynamicDictionary_Contains_KeyShouldReturnTrueForValidKey()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);
            Assert.IsTrue(target.ContainsKey(entry.Key));
        }

        [Test]
        public void DynamicDictionary_Contains_KeyShouldReturnFalseForInvalidKey()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            Assert.IsFalse(target.ContainsKey(entry.Key));
        }

        [Test]
        public void DynamicDictionary_CopyTo_ZeroBasedShouldCopyAllElements()
        {
            var target = CreateTarget();
            var entry0 = CreateEntry(0);
            var entry1 = CreateEntry(1);
            target.Add(entry0);
            target.Add(entry1);

            var array = new KeyValuePair<string, object>[2];
            target.CopyTo(array, 0);

            Assert.AreEqual(entry0, array[0]);
            Assert.AreEqual(entry1, array[1]);
        }

        [Test]
        public void DynamicDictionary_CopyTo_NonZeroBasedShouldCopyElementsFromIndex()
        {
            var target = CreateTarget();
            var entry0 = CreateEntry(0);
            var entry1 = CreateEntry(1);
            target.Add(entry0);
            target.Add(entry1);

            var array = new KeyValuePair<string, object>[3];
            target.CopyTo(array, 1);

            Assert.AreEqual(entry0, array[1]);
            Assert.AreEqual(entry1, array[2]);
        }

        [Test]
        public void DynamicDictionary_Count_OnNewInstanceShouldBeZero()
        {
            var target = CreateTarget();
            Assert.AreEqual(0, target.Count);
        }

        [Test]
        public void DynamicDictionary_Count_AfterAddShouldBeOne()
        {
            var target = CreateTarget();
            target.Add(CreateEntry(0));
            Assert.AreEqual(1, target.Count);
        }

        [Test]
        public void DynamicDictionary_GetEnumerator()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);

            var enumerator = target.GetEnumerator();
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(entry, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [Test]
        public void DynamicDictionary_IEnumerable_GetEnumerator()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);

            var enumerator = ((IEnumerable)target).GetEnumerator();
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(entry, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [Test]
        public void DynamicDictionary_Keys_ShouldContainKey()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);
            Assert.AreEqual(1, target.Keys.Count);
            Assert.AreEqual(entry.Key, target.Keys.Single());
        }

        [Test]
        public void DynamicDictionary_Keys_ShouldContainKeys()
        {
            var target = CreateTarget();
            var entry0 = CreateEntry(0);
            var entry1 = CreateEntry(1);
            target.Add(entry0);
            target.Add(entry1);
            Assert.AreEqual(2, target.Keys.Count);
            Assert.AreEqual(entry0.Key, target.Keys.First());
            Assert.AreEqual(entry1.Key, target.Keys.Last());
        }

        [Test]
        public void DynamicDictionary_Remove_KeyValuePairShouldRemoveIt()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);
            target.Remove(entry);
            Assert.AreEqual(0, target.Count);
        }

        [Test]
        public void DynamicDictionary_Remove_KeyValuePairShouldOnlyRemoveIt()
        {
            var target = CreateTarget();
            var entry0 = CreateEntry(0);
            var entry1 = CreateEntry(1);
            target.Add(entry0);
            target.Add(entry1);
            target.Remove(entry0);
            Assert.AreEqual(1, target.Count);
            Assert.IsTrue(target.Contains(entry1));
        }

        [Test]
        public void DynamicDictionary_Remove_KeyShouldRemoveIt()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);
            target.Remove(entry.Key);
            Assert.AreEqual(0, target.Count);
        }

        [Test]
        public void DynamicDictionary_Remove_KeyShouldOnlyRemoveIt()
        {
            var target = CreateTarget();
            var entry0 = CreateEntry(0);
            var entry1 = CreateEntry(1);
            target.Add(entry0);
            target.Add(entry1);
            target.Remove(entry0.Key);
            Assert.AreEqual(1, target.Count);
            Assert.IsTrue(target.Contains(entry1));
        }

        [Test]
        public void DynamicDictionary_TryGet_ValueShouldReturnTrueAndGetValue()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);

            object value;
            Assert.IsTrue(target.TryGetValue(entry.Key, out value));
            Assert.AreEqual(entry.Value, value);
        }

        [Test]
        public void DynamicDictionary_TryGet_ValueShouldReturnFalseAndGetDefaultValue()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);

            object value;
            Assert.IsFalse(target.TryGetValue(entry.Key, out value));
            Assert.AreEqual(default(object), value);
        }

        [Test]
        public void DynamicDictionary_IndexerShouldReturnCorrectValue()
        {
            var target = CreateTarget();
            var entry = CreateEntry(0);
            target.Add(entry);

            Assert.AreEqual(entry.Value, target[entry.Key]);
        }

        [Test]
        public void DynamicDictionary_IsReadOnly_ShouldNotError()
        {
            var target = CreateTarget();

            Assert.IsNotNull(target.IsReadOnly);
        }

        [Test]
        public void DynamicDictionary_Values_ShouldNotError()
        {
            var target = CreateTarget();
            Assert.IsNotNull(target.Values.ToList());
        }

        [Test]
        public void DynamicDictionary_Indexer_Test()
        {
            var target = CreateTarget();
            target.Add("hello", "world");
            Assert.AreEqual("world", target["hello"]);

            target["hello"] = "again";
            Assert.AreEqual("again", target["hello"]);
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DynamicDictionary_Indexer_ShouldThrowWithInvalidKey()
        {
            var target = CreateTarget();
            var x = target["INVALIDKEY"];
        }

        [Test]
        public void DynamicDictionary_Create_FromNameValueCollection()
        {
            var collection = new NameValueCollection() { { "a", "b" }, { "c", "d" }, { "c", "e" } };
            var dynamicDictionaryAsDictionary = DynamicDictionary.CreateDictionary(collection);
            var dynamicDictionaryAsDynamic = DynamicDictionary.CreateDynamic(collection);

            Assert.AreEqual("b", dynamicDictionaryAsDynamic.a);
            Assert.AreEqual("e", dynamicDictionaryAsDynamic.c);

            Assert.AreEqual("b", dynamicDictionaryAsDictionary["a"]);
            Assert.AreEqual("e", dynamicDictionaryAsDictionary["c"]);

            CollectionAssert.AreEquivalent(collection.AllKeys, dynamicDictionaryAsDictionary.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => DynamicDictionary.FromNameValueCollection((NameValueCollection)null));
        }

        [Test]
        public void DynamicDictionary_Create_FromDictionary()
        {
            var dictionary = new Dictionary<string, object>() { { "a", "b" }, { "c", new Dictionary<string, object> { { "d", "e" } } } };
            var dynamicDictionaryAsDictionary = DynamicDictionary.CreateDictionary(dictionary);
            var dynamicDictionaryAsDynamic = DynamicDictionary.CreateDynamic(dictionary);

            Assert.AreEqual("b", dynamicDictionaryAsDynamic.a);
            Assert.AreEqual("e", dynamicDictionaryAsDynamic.c.d);

            Assert.AreEqual("b", dynamicDictionaryAsDictionary["a"]);
            CollectionAssert.AreEquivalent(new Dictionary<string, object> { { "d", "e" } }, dynamicDictionaryAsDictionary["c"] as IDictionary<string, object>);

            CollectionAssert.AreEquivalent(dictionary.Keys, dynamicDictionaryAsDictionary.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => DynamicDictionary.FromDictionary((Dictionary<string, object>)null));
        }

        [Test]
        public void DynamicDictionary_Create_FromNameValueCollection_ignore_case()
        {
            var collection = new NameValueCollection() { { "a", "b" }, { "c", null } };
            var dynamicDictionaryAsDictionary = DynamicDictionary.CreateDictionary(collection, StringComparer.OrdinalIgnoreCase);
            var dynamicDictionaryAsDynamic = DynamicDictionary.CreateDynamic(collection, StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual("b", dynamicDictionaryAsDynamic.a);
            Assert.AreEqual(null, dynamicDictionaryAsDynamic.c);
            Assert.AreEqual("b", dynamicDictionaryAsDictionary["a"]);
            Assert.AreEqual(null, dynamicDictionaryAsDictionary["c"]);
            CollectionAssert.AreEquivalent(collection.AllKeys, dynamicDictionaryAsDictionary.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => DynamicDictionary.FromNameValueCollection((NameValueCollection)null, StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void DynamicDictionary_Create_FromDictionary_ignore_case()
        {
            var dictionary = new Dictionary<string, object>() { { "a", "b" } };
            var dynamicDictionaryAsDictionary = DynamicDictionary.CreateDictionary(dictionary, StringComparer.OrdinalIgnoreCase);
            var dynamicDictionaryAsDynamic = DynamicDictionary.CreateDynamic(dictionary, StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual("b", dynamicDictionaryAsDynamic.a);
            Assert.AreEqual("b", dynamicDictionaryAsDynamic.A);
            Assert.AreEqual("b", dynamicDictionaryAsDictionary["a"]);
            Assert.AreEqual("b", dynamicDictionaryAsDictionary["A"]);
            CollectionAssert.AreEquivalent(dictionary.Keys, dynamicDictionaryAsDictionary.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => DynamicDictionary.FromDictionary((Dictionary<string, object>)null, StringComparer.OrdinalIgnoreCase));
        }
    }
}

#endif