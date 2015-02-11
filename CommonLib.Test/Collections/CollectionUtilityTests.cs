using jaytwo.Common.Collections;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Collections
{
    [TestFixture]
    public static class CollectionUtilityTests
    {
        [Test]
        public static void CollectionUtility_CreateDictionary_FromNameValueCollection()
        {
            var collection = new NameValueCollection() { { "a", "b" }, { "c", "d" }, { "c", "e" }, { "f", null } };
            var dynamicDictionaryAsDictionary = CollectionUtility.ToDictionary(collection);

            Assert.AreEqual("b", dynamicDictionaryAsDictionary["a"]);
            Assert.AreEqual("e", dynamicDictionaryAsDictionary["c"]);
            Assert.AreEqual(null, dynamicDictionaryAsDictionary["f"]);

            CollectionAssert.AreEquivalent(collection.AllKeys, dynamicDictionaryAsDictionary.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => CollectionUtility.ToDictionary((NameValueCollection)null));
        }

        [Test]
        public static void CollectionUtility_CreateDictionary_FromNameValueCollection_ignore_case()
        {
            var collection = new NameValueCollection() { { "a", "b" }, { "f", null } };
            var dynamicDictionaryAsDictionary = CollectionUtility.ToDictionary(collection, StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual("b", dynamicDictionaryAsDictionary["a"]);
            Assert.AreEqual("b", dynamicDictionaryAsDictionary["A"]);
            Assert.AreEqual(null, dynamicDictionaryAsDictionary["f"]);
            CollectionAssert.AreEquivalent(collection.AllKeys, dynamicDictionaryAsDictionary.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => CollectionUtility.ToDictionary((NameValueCollection)null, StringComparer.OrdinalIgnoreCase));
        }

    }
}
