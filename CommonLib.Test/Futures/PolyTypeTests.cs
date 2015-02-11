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
	public static class PolyTypeTests
	{
		[Test]
		public static void PolyTypeDictionary()
		{
			var dictionary = new Dictionary<string, object>()
			{
				{ "key1", 123 },
				{ "key2", new[] {1,2,3}},
				{ "key3", "hello world" },
			};

			var poly = PolyType.NewOrNull(dictionary);
			
			Assert.AreEqual(123, (int)poly["key1"]);

			Assert.AreEqual(1, poly["key2"][0].AsInt32());
			Assert.AreEqual(2, poly["key2"][1].AsInt32());
			Assert.AreEqual(3, poly["key2"][2].AsInt32());

			Assert.AreEqual("hello world", (string)poly["key3"]);
		}

		private static IEnumerable<TestCaseData> foo_TestCases()
		{
			yield return new TestCaseData();
		}

		[Test]
		[TestCase(1)]
		public static void PolyType_int(int one)
		{
			var onePoly = (PolyType)one;
			//Assert.AreEqual(one, onePoly);

			byte oneByte = onePoly;
			Assert.AreEqual(one, oneByte);

			short oneShort = onePoly;
			Assert.AreEqual(one, oneShort);

			int oneInt = onePoly;
			Assert.AreEqual(one, oneInt);

			long oneLong = onePoly;
			Assert.AreEqual(one, oneLong);

			decimal oneDecimal = onePoly;
			Assert.AreEqual(one, oneDecimal);

			sbyte oneSByte = onePoly;
			Assert.AreEqual(one, oneSByte);

			ushort oneUShort = onePoly;
			Assert.AreEqual(one, oneUShort);

			ulong oneULong = onePoly;
			Assert.AreEqual(one, oneULong);

			string oneString = onePoly;
			string oneToString = (one != null) ? one.ToString() : null;
			Assert.AreEqual(oneToString, oneString);
		}

		[Test]
		[TestCase(1)]
		[TestCase(null)]
		public static void PolyType_int_nullable(int? one)
		{
			var onePoly = (PolyType)one;
			//Assert.AreEqual(one, onePoly);

			//Assert.AreEqual(one.HasValue, onePoly.HasValue);            
			if (one.HasValue)
			{
				byte oneByte = onePoly;
				Assert.AreEqual(one, oneByte);

				short oneShort = onePoly;
				Assert.AreEqual(one, oneShort);

				int oneInt = onePoly;
				Assert.AreEqual(one, oneInt);

				long oneLong = onePoly;
				Assert.AreEqual(one, oneLong);

				decimal oneDecimal = onePoly;
				Assert.AreEqual(one, oneDecimal);

				sbyte oneSByte = onePoly;
				Assert.AreEqual(one, oneSByte);

				ushort oneUShort = onePoly;
				Assert.AreEqual(one, oneUShort);

				ulong oneULong = onePoly;
				Assert.AreEqual(one, oneULong);
			}

			byte? oneByteNullable = onePoly;
			Assert.AreEqual(one, oneByteNullable);

			short? oneShortNullable = onePoly;
			Assert.AreEqual(one, oneShortNullable);

			int? oneIntNullable = onePoly;
			Assert.AreEqual(one, oneIntNullable);

			long? oneLongNullable = onePoly;
			Assert.AreEqual(one, oneLongNullable);

			decimal? oneDecimalNullable = onePoly;
			Assert.AreEqual(one, oneDecimalNullable);

			sbyte? oneSByteNullable = onePoly;
			Assert.AreEqual(one, oneSByteNullable);

			ushort? oneUShortNullable = onePoly;
			Assert.AreEqual(one, oneUShortNullable);

			ulong? oneULongNullable = onePoly;
			Assert.AreEqual(one, oneULongNullable);

			string oneString = onePoly;
			string oneToString = (one != null) ? one.ToString() : null;
			Assert.AreEqual(oneToString, oneString);
		}

		[Test]
		[TestCase((byte)1)]
		public static void PolyType_byte(byte one)
		{
			var onePoly = (PolyType)one;
			//Assert.AreEqual(one, onePoly);

			byte oneByte = onePoly;
			Assert.AreEqual(one, oneByte);

			short oneShort = onePoly;
			Assert.AreEqual(one, oneShort);

			int oneInt = onePoly;
			Assert.AreEqual(one, oneInt);

			long oneLong = onePoly;
			Assert.AreEqual(one, oneLong);

			decimal oneDecimal = onePoly;
			Assert.AreEqual(one, oneDecimal);

			sbyte oneSByte = onePoly;
			Assert.AreEqual(one, oneSByte);

			ushort oneUShort = onePoly;
			Assert.AreEqual(one, oneUShort);

			ulong oneULong = onePoly;
			Assert.AreEqual(one, oneULong);

			string oneString = onePoly;
			string oneToString = (one != null) ? one.ToString() : null;
			Assert.AreEqual(oneToString, oneString);
		}

		[Test]
		[TestCase((byte)1)]
		[TestCase(null)]
		public static void PolyType_byte_nullable(byte? one)
		{
			var onePoly = (PolyType)one;
			//Assert.AreEqual(one, onePoly);

			//Assert.AreEqual(one.HasValue, onePoly.HasValue);
			if (one.HasValue)
			{
				byte oneByte = onePoly;
				Assert.AreEqual(one, oneByte);

				short oneShort = onePoly;
				Assert.AreEqual(one, oneShort);

				int oneInt = onePoly;
				Assert.AreEqual(one, oneInt);

				long oneLong = onePoly;
				Assert.AreEqual(one, oneLong);

				decimal oneDecimal = onePoly;
				Assert.AreEqual(one, oneDecimal);

				sbyte oneSByte = onePoly;
				Assert.AreEqual(one, oneSByte);

				ushort oneUShort = onePoly;
				Assert.AreEqual(one, oneUShort);

				ulong oneULong = onePoly;
				Assert.AreEqual(one, oneULong);
			}

			byte? oneByteNullable = onePoly;
			Assert.AreEqual(one, oneByteNullable);

			short? oneShortNullable = onePoly;
			Assert.AreEqual(one, oneShortNullable);

			int? oneIntNullable = onePoly;
			Assert.AreEqual(one, oneIntNullable);

			long? oneLongNullable = onePoly;
			Assert.AreEqual(one, oneLongNullable);

			decimal? oneDecimalNullable = onePoly;
			Assert.AreEqual(one, oneDecimalNullable);

			sbyte? oneSByteNullable = onePoly;
			Assert.AreEqual(one, oneSByteNullable);

			ushort? oneUShortNullable = onePoly;
			Assert.AreEqual(one, oneUShortNullable);

			ulong? oneULongNullable = onePoly;
			Assert.AreEqual(one, oneULongNullable);

			string oneString = onePoly;
			string oneToString = (one != null) ? one.ToString() : null;
			Assert.AreEqual(oneToString, oneString);
		}

		[Test]
		public static void PolyType_short()
		{
			short one = 1;
			var onePoly = (PolyType)one;

			byte oneByte = onePoly;
			short oneShort = onePoly;
			int oneInt = onePoly;
			long oneLong = onePoly;
			decimal oneDecimal = onePoly;
			sbyte oneSByte = onePoly;
			ushort oneUShort = onePoly;
			ulong oneULong = onePoly;

			string oneString = onePoly;
			string oneToString = (one != null) ? one.ToString() : null;
			Assert.AreEqual(oneToString, oneString);
		}

		[Test]
		public static void PolyType_long()
		{
			long one = 1;
			var onePoly = (PolyType)one;

			byte oneByte = onePoly;
			short oneShort = onePoly;
			int oneInt = onePoly;
			long oneLong = onePoly;
			decimal oneDecimal = onePoly;
			sbyte oneSByte = onePoly;
			ushort oneUShort = onePoly;
			ulong oneULong = onePoly;

			string oneString = onePoly;
			string oneToString = (one != null) ? one.ToString() : null;
			Assert.AreEqual(oneToString, oneString);
		}

		[Test]
		[TestCase("1")]
		[TestCase("")]
		[TestCase(null)]
		public static void PolyType_string(string one)
		{
			var onePoly = (PolyType)one;
			var oneIsNull = one == null;
			var oneIsEmpty = one == string.Empty;
			//Assert.AreEqual(one, onePoly);

			//Assert.AreEqual(!oneIsNull, onePoly.HasValue);
			if (!oneIsNull)
			{
				byte oneByte = onePoly;
				Assert.AreEqual(one, oneByte);

				short oneShort = onePoly;
				Assert.AreEqual(one, oneShort);

				int oneInt = onePoly;
				Assert.AreEqual(one, oneInt);

				long oneLong = onePoly;
				Assert.AreEqual(one, oneLong);

				decimal oneDecimal = onePoly;
				Assert.AreEqual(one, oneDecimal);

				sbyte oneSByte = onePoly;
				Assert.AreEqual(one, oneSByte);

				ushort oneUShort = onePoly;
				Assert.AreEqual(one, oneUShort);

				ulong oneULong = onePoly;
				Assert.AreEqual(one, oneULong);
			}

			byte? oneByteNullable = onePoly;
			Assert.AreEqual(one, oneByteNullable);

			short? oneShortNullable = onePoly;
			Assert.AreEqual(one, oneShortNullable);

			int? oneIntNullable = onePoly;
			Assert.AreEqual(one, oneIntNullable);

			long? oneLongNullable = onePoly;
			Assert.AreEqual(one, oneLongNullable);

			decimal? oneDecimalNullable = onePoly;
			Assert.AreEqual(one, oneDecimalNullable);

			sbyte? oneSByteNullable = onePoly;
			Assert.AreEqual(one, oneSByteNullable);

			ushort? oneUShortNullable = onePoly;
			Assert.AreEqual(one, oneUShortNullable);

			ulong? oneULongNullable = onePoly;
			Assert.AreEqual(one, oneULongNullable);

			string oneString = onePoly;
			string oneToString = (one != null) ? one.ToString() : null;
			Assert.AreEqual(oneToString, oneString);
		}
	}
}
