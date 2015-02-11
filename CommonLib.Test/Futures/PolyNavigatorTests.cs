using jaytwo.Common.Futures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test.Futures
{
	[TestFixture]
	public static class PolyNavigatorTests
	{
		[Test]
		public static void PolyNavigator_dictioanry()
		{
			var foo = new Dictionary<string, object>();
			foo["class"] = new List<IDictionary<string, object>>()
			{
				new Dictionary<string, object>() 
				{
					{"1", new Dictionary<string, object>() { {"Name", "Jake"},{"Score","100"} }},
				},
			};

			var poly = PolyNavigator.FromObject(foo);
			Assert.AreEqual(foo, poly.InnerValue);
			Assert.AreEqual(foo, poly.AsDictionary());
			Assert.AreEqual(foo, poly.InnerValueAs<Dictionary<string, object>>());
			Assert.AreEqual(foo["class"], poly["class"].InnerValue);
			Assert.AreEqual(foo["class"], poly["class"].AsList());
			Assert.AreEqual(foo["class"], poly["class"].InnerValueAs<List<IDictionary<string, object>>>());
			Assert.AreEqual("Jake", poly["class"][0]["1"]["Name"].AsString());
			Assert.AreEqual("Jake", poly["class"]["0"]["1"]["Name"].AsString());
			Assert.AreEqual(100, poly["class"][0]["1"]["Score"].AsInt32());

			Assert.IsNull(poly["class"][0]["1"]["Name"]["random"][1000]["invalid"].Value);
		}

		[Test]
		public static void PolyNavigator_object()
		{
			var foo = new
			{
				classes = new[] { new { one = new { Name = "Jake", Score = 100 } } }
			};
			

			var poly = PolyNavigator.FromObject(foo);
			Assert.AreEqual(foo, poly.InnerValue);
			Assert.AreEqual(foo.classes, poly["classes"].InnerValue);
			Assert.AreEqual("Jake", poly["classes"][0]["one"]["Name"].AsString());
			Assert.AreEqual("Jake", poly["classes"]["0"]["one"]["Name"].AsString());
			Assert.AreEqual(100, poly["classes"][0]["one"]["Score"].AsInt32());

			Assert.IsNull(poly["classes"][0]["1"]["Name"]["random"][1000]["invalid"].Value);
		}
	}
}
