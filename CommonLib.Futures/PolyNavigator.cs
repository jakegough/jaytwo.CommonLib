using jaytwo.Common.Collections;
using jaytwo.Common.Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;
using jaytwo.Common.Appendix;

namespace jaytwo.Common.Futures
{
	public class PolyNavigator
	{
		public static PolyNavigator FromObject(object value)
		{
			if (value != null)
			{
				return new PolyNavigator(value);
			}
			else
			{
				return null;
			}
		}

		public static PolyNavigator FromObject(object value, StringComparer stringComparer)
		{
			if (value != null)
			{
				return new PolyNavigator(value, stringComparer);
			}
			else
			{
				return null;
			}
		}

		public static PolyNavigator FromJson(string json)
		{
			if (!string.IsNullOrEmpty(json))
			{
				var dictionary = ParseUtility.ParseJsonAsDictionary(json);
				return FromObject(dictionary);
			}
			else
			{
				return null;
			}
		}

		public static PolyNavigator FromJson(string json, StringComparer stringComparer)
		{
			if (!string.IsNullOrEmpty(json))
			{
				var dictionary = ParseUtility.ParseJsonAsDictionary(json);
				return FromObject(dictionary, stringComparer);
			}
			else
			{
				return null;
			}
		}

		private StringComparer stringComparer;
		private object innerValue;
		private IList innerList;
		private IDictionary innerDictionary;

		public StringComparer StringComparer
		{
			get
			{
				return stringComparer;
			}
		}

		public PolyType Value
		{
			get
			{
				return PolyType.NewOrNull(innerValue);
			}
		}

		public string AsString()
		{
			return new PolyType(innerValue).AsString();
		}

		public IDictionary AsDictionary()
		{
			return new PolyType(innerValue).AsDictionary();
		}

		public IDictionary<TKey, TValue> AsDictionary<TKey, TValue>()
		{
			return new PolyType(innerValue).AsDictionary<TKey, TValue>();
		}

		public IList AsList()
		{
			return new PolyType(innerValue).AsList();
		}

		public IList<T> AsList<T>()
		{
			return new PolyType(innerValue).AsList<T>();
		}

		public bool AsBoolean()
		{
			return new PolyType(innerValue).AsBoolean();
		}

		public bool? AsBooleanNullable()
		{
			return new PolyType(innerValue).AsBooleanNullable();
		}

		public byte AsByte()
		{
			return new PolyType(innerValue).AsByte();
		}

		public byte? AsByteNullable()
		{
			return new PolyType(innerValue).AsByteNullable();
		}

		public char AsChar()
		{
			return new PolyType(innerValue).AsChar();
		}

		public char? AsCharNullable()
		{
			return new PolyType(innerValue).AsCharNullable();
		}

		public DateTime AsDateTime()
		{
			return new PolyType(innerValue).AsDateTime();
		}

		public DateTime? AsDateTimeNullable()
		{
			return new PolyType(innerValue).AsDateTimeNullable();
		}

		public decimal AsDecimal()
		{
			return new PolyType(innerValue).AsDecimal();
		}

		public decimal? AsDecimalNullable()
		{
			return new PolyType(innerValue).AsDecimalNullable();
		}

		public double AsDouble()
		{
			return new PolyType(innerValue).AsDouble();
		}

		public double? AsDoubleNullable()
		{
			return new PolyType(innerValue).AsDoubleNullable();
		}

		public short AsInt16()
		{
			return new PolyType(innerValue).AsInt16();
		}

		public short? AsInt16Nullable()
		{
			return new PolyType(innerValue).AsInt16Nullable();
		}

		public int AsInt32()
		{
			return new PolyType(innerValue).AsInt32();
		}

		public int? AsInt32Nullable()
		{
			return new PolyType(innerValue).AsInt32Nullable();
		}

		public long AsInt64()
		{
			return new PolyType(innerValue).AsInt64();
		}

		public long? AsInt64Nullable()
		{
			return new PolyType(innerValue).AsInt64Nullable();
		}

		public sbyte AsSByte()
		{
			return new PolyType(innerValue).AsSByte();
		}

		public sbyte? AsSByteNullable()
		{
			return new PolyType(innerValue).AsSByteNullable();
		}

		public float AsSingle()
		{
			return new PolyType(innerValue).AsSingle();
		}

		public float? AsSingleNullable()
		{
			return new PolyType(innerValue).AsSingleNullable();
		}

		public ushort AsUInt16()
		{
			return new PolyType(innerValue).AsUInt16();
		}

		public ushort? AsUInt16Nullable()
		{
			return new PolyType(innerValue).AsUInt16Nullable();
		}

		public uint AsUInt32()
		{
			return new PolyType(innerValue).AsUInt32();
		}

		public uint? AsUInt32Nullable()
		{
			return new PolyType(innerValue).AsUInt32Nullable();
		}

		public ulong AsUInt64()
		{
			return new PolyType(innerValue).AsUInt64();
		}

		public ulong? AsUInt64Nullable()
		{
			return new PolyType(innerValue).AsUInt64Nullable();
		}

		public object InnerValue
		{
			get
			{
				return innerValue;
			}
		}

		private PolyNavigator(object value, StringComparer stringComparer)
			: this(value)
		{
			this.stringComparer = stringComparer;
		}

		private PolyNavigator(object value)
		{
			this.innerValue = value;
			this.innerList = value as IList;
			this.innerDictionary = value as IDictionary;
		}

		public T InnerValueAs<T>()
		{
			return (T)innerValue;
		}

		public string ToJson()
		{
			return InternalScabHelpers.SerializeToJson(innerValue);
		}

		public PolyNavigator this[string key]
		{
			get
			{
				object result;

				if (PolyNavigatorHelpers.TryGetDictionaryValue(innerDictionary, key, StringComparer, out result))
				{
					// do nothing
				}
				else if (PolyNavigatorHelpers.TryGetListValue(innerList, key, out result))
				{
					// do nothing
				}
				else if (PolyNavigatorHelpers.TryGetReflectionValue(innerValue, key, StringComparer, out result))
				{
					// do nothing
				}

				return new PolyNavigator(result, StringComparer);
			}
		}

		public PolyNavigator this[int index]
		{
			get
			{
				object result = null;

				if (innerList != null && innerList.Count > index)
				{
					result = innerList[index];
				}

				return new PolyNavigator(result, StringComparer);
			}
		}

	}
}
