using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;
using System.Web;

namespace jaytwo.Common.Test.Extensions
{
    [TestFixture]
    public static class NameValueCollectionExtensionsTests
    {
        [Test]
        public static void NameValueCollection_AddValue()
        {
            var collection = new NameValueCollection();
            
            var addedCollection = collection.AddValue("hello", "world");
            Assert.AreSame(collection, addedCollection);
            Assert.AreEqual("world", collection["hello"]);
            
            var secondAddedCollection = collection.AddValue("number", 1);
            Assert.AreSame(collection, secondAddedCollection);
            Assert.AreEqual("1", collection["number"]);

            secondAddedCollection = collection.AddValue("x", (object)1);
            Assert.AreSame(collection, secondAddedCollection);
            Assert.AreEqual("1", collection["x"]);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).AddValue("hello", "world"));
            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).AddValue("hello", (object)"world"));
        }

        [Test]
        public static void NameValueCollection_AddValues()
        {
            var collectionToAdd = new NameValueCollection() { { "hello", "world" } };
            var collection = new NameValueCollection();

            var addedCollection = collection.AddValues(collectionToAdd);
            Assert.AreSame(collection, addedCollection);
            Assert.AreEqual("world", collection["hello"]);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).AddValues(collectionToAdd));
        }

        [Test]
        public static void NameValueCollection_ClearValues()
        {
            var collection = new NameValueCollection() { { "hello", "world" } };

            var clearedCollection = collection.ClearValues();
            Assert.AreSame(collection, clearedCollection);
            Assert.AreEqual(0, collection.AllKeys.Length);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).ClearValues());
        }

        [Test]
        public static void NameValueCollection_RemoveValue()
        {
            var collection = new NameValueCollection() { { "hello", "world" }, { "foo", "bar" } };
            
            var clearedCollection = collection.RemoveValue("foo");
            Assert.AreSame(collection, clearedCollection);
            Assert.IsNull(collection["foo"]);
            Assert.AreEqual("world", collection["hello"]);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).RemoveValue("hello"));
        }

        [Test]
        public static void NameValueCollection_SetValue()
        {
            var collection = new NameValueCollection() { { "hello", "world" } };

            var setCollection = collection.SetValue("hello", "john");
            Assert.AreSame(collection, setCollection);
            Assert.AreEqual("john", collection["hello"]);

            var secondAddedCollection = collection.SetValue("number", 1);
            Assert.AreSame(collection, secondAddedCollection);
            Assert.AreEqual("1", collection["number"]);


            secondAddedCollection = collection.SetValue("number", (object)1);
            Assert.AreSame(collection, secondAddedCollection);
            Assert.AreEqual("1", collection["number"]);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).SetValue("hello", "world"));
        }

        [Test]
        public static void NameValueCollection_ToHttpValueCollection()
        {
            var collection = new NameValueCollection() { { "hello", "world" }, { "foo", "bar bar" } };

            var httpValueCollection = collection.ToHttpValueCollection();
            Assert.AreNotSame(collection, httpValueCollection);
            Assert.AreEqual("HttpValueCollection", httpValueCollection.GetType().Name);

            var queryString = httpValueCollection.ToString();
            Assert.AreEqual("hello=world&foo=bar+bar", queryString);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).ToHttpValueCollection());
        }

        [Test]
        public static void NameValueCollection_ToPercentEncodedQueryString()
        {
            var collection = new NameValueCollection() { { "hello", "world" }, { "foo", "bar bar" } };
            
            var queryString = collection.ToPercentEncodedQueryString();
            Assert.AreEqual("hello=world&foo=bar%20bar", queryString);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).ToPercentEncodedQueryString());
        }

        [Test]
        public static void NameValueCollection_ToDictionary()
        {
            var collection = new NameValueCollection() { { "hello", "world" }, { "foo", "bar bar" } };
            
            var dictionary = collection.ToDictionary();
            Assert.AreEqual(dictionary["hello"], collection["hello"]);
            CollectionAssert.AreEqual(dictionary.Keys, collection.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).ToDictionary());
        }

        [Test]
        public static void NameValueCollection_ToDictionary_OrdinalIgnoreCase()
        {
            var collection = new NameValueCollection() { { "hello", "world" }, { "foo", "bar bar" } };
            
            var dictionary = collection.ToDictionary(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(dictionary["hello"], collection["hello"]);
            Assert.AreEqual(dictionary["HELLO"], collection["hello"]);
            CollectionAssert.AreEqual(dictionary.Keys, collection.Keys);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).ToDictionary());
        }

#if GTENET40
        [Test]
        public static void NameValueCollection_ToDynamic()
        {
            var collection = new NameValueCollection() { { "hello", "world" }, { "foo", "bar bar" } };
            
            var asDynamic = collection.ToDynamic();
            Assert.AreEqual(asDynamic.hello, collection["hello"]);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).ToDynamic());
		}

        [Test]
        public static void NameValueCollection_ToDynamic_OrdinalIgnoreCase()
        {
            var collection = new NameValueCollection() { { "hello", "world" }, { "foo", "bar bar" } };
            
            var asDynamic = collection.ToDynamic(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(asDynamic.hello, collection["hello"]);
            Assert.AreEqual(asDynamic.HELLO, collection["hello"]);

            Assert.Throws(typeof(ArgumentNullException), () => ((NameValueCollection)null).ToDynamic(StringComparer.OrdinalIgnoreCase));
        }
#endif
    }
}
