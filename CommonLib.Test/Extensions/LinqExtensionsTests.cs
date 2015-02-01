using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;

namespace jaytwo.Common.Test.Extensions
{
    [TestFixture]
    public static class LinqExtensionsTests
    {
        public static IEnumerable<TestCaseData> OrderByRandom_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new int[] { });
            yield return new TestCaseData(Enumerable.Range(1, 1000).ToArray());
        }

        [Test]
        [TestCaseSource("OrderByRandom_TestCases")]
        public static void OrderByRandom(int[] array)
        {
            var random = array.OrderByRandom().ToArray();
            CollectionAssert.AreEquivalent(array, random);

            if (array.Any())
            {
                CollectionAssert.AreNotEqual(array, random);
            }
        }

        public static IEnumerable<TestCaseData> FirstRandomOrDefault_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new int[] { });
            yield return new TestCaseData(new int[] { 1 });
            yield return new TestCaseData(Enumerable.Range(1, 1000).ToArray());
        }

        [Test]
        [TestCaseSource("FirstRandomOrDefault_TestCases")]
        public static void FirstRandomOrDefault(int[] array)
        {
            var random1 = array.FirstRandomOrDefault();
            var random2 = array.FirstRandomOrDefault();

            if (array.Count() > 1)
            {
                Assert.IsFalse(random1 == random2);
            }
            else if (array.Length > 0)
            {
                Assert.IsTrue(random1 == random2);
            }
            else
            {
                Assert.AreEqual(0, random1);
                Assert.AreEqual(0, random2);
            }
        }

        public static IEnumerable<TestCaseData> FirstRandom_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new int[] { }).Throws(typeof(InvalidOperationException));
            yield return new TestCaseData(new int[] { 1 });
            yield return new TestCaseData(Enumerable.Range(1, 1000).ToArray());
            yield return new TestCaseData(Enumerable.Range(1, 1000));
        }

        [Test]
        [TestCaseSource("FirstRandom_TestCases")]
        public static void FirstRandom(IEnumerable<int> array)
        {
            var random1 = array.FirstRandom();
            var random2 = array.FirstRandom();

            if (array.Count() > 1)
            {
                Assert.IsFalse(random1 == random2);
            }
            else
            {
                Assert.IsTrue(random1 == random2);
            }
        }


        public static IEnumerable<TestCaseData> DistinctBy_TestCases()
        {
            yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new int[] { });
            yield return new TestCaseData(Enumerable.Range(1, 1000).ToArray());
        }

        [Test]
        [TestCaseSource("DistinctBy_TestCases")]
        public static void DistinctBy(int[] array)
        {
            var distinct = array.Distinct();
            Assert.AreEqual(distinct, array.DistinctBy(x => x.ToString()));
        }
    }
}
