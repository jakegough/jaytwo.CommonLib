using System;
using System.Collections.Generic;
using System.Text;
using jaytwo.Common.Extensions;
using System.Globalization;
using jaytwo.Common.Parse;
using System.Linq;
using System.Collections;

namespace jaytwo.Common.Futures
{
	public class PolyType : IConvertible
	{
		public static PolyType NewOrNull(object value)
		{
			if (value == null)
			{
				return null;
			}
			else
			{
				return new PolyType(value);
			}
		}

		private static readonly IFormatProvider DefaultFormatProvider = CultureInfo.InvariantCulture;

		protected IFormatProvider Provider { get; private set; }

		private IFormatProvider GetProviderOrDefault()
		{
			return Provider ?? DefaultFormatProvider;
		}

		private IList innerList;
		private IDictionary innerDictionary;
		private object innerValue;

		public PolyType(object value)
			: this(value, DefaultFormatProvider)
		{
		}

		public PolyType(object value, IFormatProvider formatProvider)
		{
			Provider = formatProvider;

			innerValue = value;
			innerList = value as IList;
			innerDictionary = value as IDictionary;			
		}

		public object Value
		{
			get
			{
				return innerValue;
			}
		}

		public bool HasValue
		{
			get
			{
				return (innerValue != null);
			}
		}

		public bool IsValueType
		{
			get
			{
				return !IsList && !IsDictionary;
			}
		}

		public bool IsDictionary
		{
			get
			{
				return (innerDictionary != null);
			}
		}

		public bool IsList
		{
			get
			{
				return (innerList != null);
			}
		}

		public bool IsValue
		{
			get
			{
				return !IsDictionary && !IsList;
			}
		}

		public PolyType this[string key]
		{
			get
			{
				return PolyType.NewOrNull(innerDictionary[key]);
			}
		}

		public PolyType this[int index]
		{
			get
			{
				return PolyType.NewOrNull(innerList[index]);
			}
		}

		public static implicit operator PolyType(string value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator string(PolyType value)
		{
			if (value != null)
			{
				return value.AsString();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(byte value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator byte(PolyType value)
		{
			if (value != null)
			{
				return value.AsByte();
			}
			else
			{
				return Convert.ToByte(null);
			}
		}

		public static implicit operator PolyType(byte? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator byte?(PolyType value)
		{
			if (value != null)
			{
				return value.AsByteNullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(bool value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator bool(PolyType value)
		{
			if (value != null)
			{
				return value.AsBoolean();
			}
			else
			{
				return Convert.ToBoolean(null);
			}
		}

		public static implicit operator PolyType(bool? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator bool?(PolyType value)
		{
			if (value != null)
			{
				return value.AsBooleanNullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(int value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator int(PolyType value)
		{
			if (value != null)
			{
				return value.AsInt32();
			}
			else
			{
				return Convert.ToInt32(null);
			}
		}

		public static implicit operator PolyType(int? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator int?(PolyType value)
		{
			if (value != null)
			{
				return value.AsInt32Nullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(long value)
		{
			return new PolyType(value);
		}

		public static implicit operator long(PolyType value)
		{
			if (value != null)
			{
				return value.AsInt64();
			}
			else
			{
				return Convert.ToInt64(null);
			}
		}

		public static implicit operator PolyType(long? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator long?(PolyType value)
		{
			if (value != null)
			{
				return value.AsInt64Nullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(short value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator short(PolyType value)
		{
			if (value != null)
			{
				return value.AsInt16();
			}
			else
			{
				return Convert.ToInt16(null);
			}
		}

		public static implicit operator PolyType(short? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator short?(PolyType value)
		{
			if (value != null)
			{
				return value.AsInt16Nullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(double value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator double(PolyType value)
		{
			if (value != null)
			{
				return value.AsDouble();
			}
			else
			{
				return Convert.ToDouble(null);
			}
		}

		public static implicit operator PolyType(double? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator double?(PolyType value)
		{
			if (value != null)
			{
				return value.AsDoubleNullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(float value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator float(PolyType value)
		{
			if (value != null)
			{
				return value.AsSingle();
			}
			else
			{
				return Convert.ToSingle(null);
			}
		}

		public static implicit operator PolyType(float? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator float?(PolyType value)
		{
			if (value != null)
			{
				return value.AsSingleNullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(decimal value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator decimal(PolyType value)
		{
			if (value != null)
			{
				return value.AsDecimal();
			}
			else
			{
				return Convert.ToDecimal(null);
			}
		}

		public static implicit operator PolyType(decimal? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator decimal?(PolyType value)
		{
			if (value != null)
			{
				return value.AsDecimalNullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(DateTime value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator DateTime(PolyType value)
		{
			if (value != null)
			{
				return value.AsDateTime();
			}
			else
			{
				return Convert.ToDateTime(null);
			}
		}

		public static implicit operator PolyType(DateTime? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator DateTime?(PolyType value)
		{
			if (value != null)
			{
				return value.AsDateTimeNullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(sbyte value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator sbyte(PolyType value)
		{
			if (value != null)
			{
				return value.AsSByte();
			}
			else
			{
				return Convert.ToSByte(null);
			}
		}

		public static implicit operator PolyType(sbyte? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator sbyte?(PolyType value)
		{
			if (value != null)
			{
				return value.AsSByteNullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(uint value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator uint(PolyType value)
		{
			if (value != null)
			{
				return value.AsUInt32();
			}
			else
			{
				return Convert.ToUInt32(null);
			}
		}

		public static implicit operator PolyType(uint? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator uint?(PolyType value)
		{
			if (value != null)
			{
				return value.AsUInt32Nullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(ulong value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator ulong(PolyType value)
		{
			if (value != null)
			{
				return value.AsUInt64();
			}
			else
			{
				return Convert.ToUInt64(null);
			}
		}

		public static implicit operator PolyType(ulong? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator ulong?(PolyType value)
		{
			if (value != null)
			{
				return value.AsUInt64Nullable();
			}
			else
			{
				return null;
			}
		}

		public static implicit operator PolyType(ushort value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator ushort(PolyType value)
		{
			if (value != null)
			{
				return value.AsUInt16();
			}
			else
			{
				return Convert.ToUInt16(null);
			}
		}

		public static implicit operator PolyType(ushort? value)
		{
			return PolyType.NewOrNull(value);
		}

		public static implicit operator ushort?(PolyType value)
		{
			if (value != null)
			{
				return value.AsUInt16Nullable();
			}
			else
			{
				return null;
			}
		}

		public TypeCode GetTypeCode()
		{
			return GetTypeCode(Value);
		}

		public static TypeCode GetTypeCode(object value)
		{
			if (value == null)
			{
				return TypeCode.Empty;
			}
			else
			{
				return Type.GetTypeCode(value.GetType());
			}
		}

		public IList AsList()
		{
			if (IsList || !HasValue)
			{
				return innerList;
			}
			else
			{
				throw new InvalidOperationException("Not a list...");
			}
		}

		public IList<T> AsList<T>()
		{
			return AsList().Cast<T>().ToList();
		}

		public IDictionary AsDictionary()
		{
			if (IsDictionary || !HasValue)
			{
				return innerDictionary;
			}
			else
			{
				throw new InvalidOperationException("Not a dictionary...");
			}
		}

		public IDictionary<TKey, TValue> AsDictionary<TKey, TValue>()
		{
			var asDictionary = AsDictionary();

			IDictionary<TKey, TValue> result;
		
			if (asDictionary is IDictionary<TKey, TValue>)
			{
				result = (IDictionary<TKey, TValue>)asDictionary;
			}
			else
			{
				throw new NotImplementedException();
			}

			return result;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return AsBoolean(provider);
		}

		public bool AsBoolean()
		{
			return AsBoolean(GetProviderOrDefault());
		}

		public bool AsBoolean(IFormatProvider provider)
		{
			return AsType<bool>(provider, (x, y) => ParseUtility.ParseBoolean(x), Convert.ToBoolean);
		}

		public bool? AsBooleanNullable()
		{
			return AsBooleanNullable(GetProviderOrDefault());
		}

		public bool? AsBooleanNullable(IFormatProvider provider)
		{
			return AsNullableType<bool>(provider, (x, y) => ParseUtility.ParseBoolean(x), Convert.ToBoolean);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return AsByte(provider);
		}

		public byte AsByte()
		{
			return AsByte(GetProviderOrDefault());
		}

		public byte AsByte(IFormatProvider provider)
		{
			return AsType<byte>(provider, ParseUtility.ParseByte, Convert.ToByte);
		}

		public byte? AsByteNullable()
		{
			return AsByteNullable(GetProviderOrDefault());
		}

		public byte? AsByteNullable(IFormatProvider provider)
		{
			return AsNullableType<byte>(provider, ParseUtility.ParseByte, Convert.ToByte);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return AsChar(provider);
		}

		public char AsChar()
		{
			return AsChar(GetProviderOrDefault());
		}

		public char AsChar(IFormatProvider provider)
		{
			return Convert.ToChar(Value, provider);
		}

		public char? AsCharNullable()
		{
			return AsCharNullable(GetProviderOrDefault());
		}

		public char? AsCharNullable(IFormatProvider provider)
		{
			if (Value == null)
			{
				return null;
			}
			else
			{
				return AsChar();
			}
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return AsDateTime(provider);
		}

		public DateTime AsDateTime()
		{
			return AsDateTime(GetProviderOrDefault());
		}

		public DateTime AsDateTime(IFormatProvider provider)
		{
			return AsType<DateTime>(provider, ParseUtility.ParseDateTime, Convert.ToDateTime);
		}

		public DateTime? AsDateTimeNullable()
		{
			return AsDateTimeNullable(GetProviderOrDefault());
		}

		public DateTime? AsDateTimeNullable(IFormatProvider provider)
		{
			return AsNullableType<DateTime>(provider, ParseUtility.ParseDateTime, Convert.ToDateTime);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return AsDecimal(provider);
		}

		public decimal AsDecimal()
		{
			return AsDecimal(GetProviderOrDefault());
		}

		public decimal AsDecimal(IFormatProvider provider)
		{
			return AsType<decimal>(provider, ParseUtility.ParseDecimal, Convert.ToDecimal);
		}

		public decimal? AsDecimalNullable()
		{
			return AsDecimalNullable(GetProviderOrDefault());
		}

		public decimal? AsDecimalNullable(IFormatProvider provider)
		{
			return AsNullableType<decimal>(provider, ParseUtility.ParseDecimal, Convert.ToDecimal);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return AsDouble(provider);
		}

		public double AsDouble()
		{
			return AsDouble(GetProviderOrDefault());
		}

		public double AsDouble(IFormatProvider provider)
		{
			return AsType<double>(provider, ParseUtility.ParseDouble, Convert.ToDouble);
		}

		public double? AsDoubleNullable()
		{
			return AsDoubleNullable(GetProviderOrDefault());
		}

		public double? AsDoubleNullable(IFormatProvider provider)
		{
			return AsNullableType<double>(provider, ParseUtility.ParseDouble, Convert.ToDouble);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return AsInt16(provider);
		}

		public short AsInt16()
		{
			return AsInt16(GetProviderOrDefault());
		}

		public short AsInt16(IFormatProvider provider)
		{
			return AsType<short>(provider, ParseUtility.ParseInt16, Convert.ToInt16);
		}

		public short? AsInt16Nullable()
		{
			return AsInt16Nullable(GetProviderOrDefault());
		}

		public short? AsInt16Nullable(IFormatProvider provider)
		{
			return AsNullableType<short>(provider, ParseUtility.ParseInt16, Convert.ToInt16);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return AsInt32(provider);
		}

		public int AsInt32()
		{
			return AsInt32(GetProviderOrDefault());
		}

		public int AsInt32(IFormatProvider provider)
		{
			return AsType<int>(provider, ParseUtility.ParseInt32, Convert.ToInt32);
		}

		public int? AsInt32Nullable()
		{
			return AsInt32Nullable(GetProviderOrDefault());
		}

		public int? AsInt32Nullable(IFormatProvider provider)
		{
			return AsNullableType<int>(provider, ParseUtility.ParseInt32, Convert.ToInt32);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return AsInt64(provider);
		}

		public long AsInt64()
		{
			return AsInt64(GetProviderOrDefault());
		}

		public long AsInt64(IFormatProvider provider)
		{
			return AsType<long>(provider, ParseUtility.ParseInt64, Convert.ToInt64);
		}

		public long? AsInt64Nullable()
		{
			return AsInt64Nullable(GetProviderOrDefault());
		}

		public long? AsInt64Nullable(IFormatProvider provider)
		{
			return AsNullableType<long>(provider, ParseUtility.ParseInt64, Convert.ToInt64);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return AsSByte(provider);
		}

		public sbyte AsSByte()
		{
			return AsSByte(GetProviderOrDefault());
		}

		public sbyte AsSByte(IFormatProvider provider)
		{
			return AsType<sbyte>(provider, ParseUtility.ParseSByte, Convert.ToSByte);
		}

		public sbyte? AsSByteNullable()
		{
			return AsSByteNullable(GetProviderOrDefault());
		}

		public sbyte? AsSByteNullable(IFormatProvider provider)
		{
			return AsNullableType<sbyte>(provider, ParseUtility.ParseSByte, Convert.ToSByte);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return AsSingle(provider);
		}

		public float AsSingle()
		{
			return AsSingle(GetProviderOrDefault());
		}

		public float AsSingle(IFormatProvider provider)
		{
			return AsType<float>(provider, ParseUtility.ParseSingle, Convert.ToSingle);
		}

		public float? AsSingleNullable()
		{
			return AsSingleNullable(GetProviderOrDefault());
		}

		public float? AsSingleNullable(IFormatProvider provider)
		{
			return AsNullableType<float>(provider, ParseUtility.ParseSingle, Convert.ToSingle);
		}

		public override string ToString()
		{
			return ToString(GetProviderOrDefault());
		}

		public string ToString(IFormatProvider provider)
		{
			if (Value is string)
			{
				return (string)Value;
			}
			else
			{
				var asString = Value as string;

				if (asString != null)
				{
					return asString;
				}
				else
				{
					return Convert.ToString(Value, provider);
				}
			}
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return AsString(provider);
		}

		public string AsString()
		{
			return AsString(GetProviderOrDefault());
		}

		public string AsString(IFormatProvider provider)
		{
			if (HasValue && !IsValueType)
			{
				throw new InvalidOperationException("Not a value type...");
			}
			else if(!HasValue)
			{
				return null;
			}
			else
			{
				return ToString();
			}
		}

		public T AsType<T>()
		{
			return (T)AsType(typeof(T));
		}

		public T AsType<T>(IFormatProvider provider)
		{
			return (T)AsType(typeof(T), provider);
		}

		public object AsType(Type conversionType)
		{
			return AsType(conversionType, GetProviderOrDefault());
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return AsType(conversionType, provider);
		}

		public object AsType(Type conversionType, IFormatProvider provider)
		{
			if (Value != null && conversionType == Value.GetType())
			{
				return Value;
			}
			if (conversionType == typeof(bool))
			{
				return AsBoolean(provider);
			}
			else if (conversionType == typeof(Nullable<bool>))
			{
				return AsBooleanNullable(provider);
			}
			else if (conversionType == typeof(byte))
			{
				return AsByte(provider);
			}
			else if (conversionType == typeof(Nullable<byte>))
			{
				return AsByteNullable(provider);
			}
			else if (conversionType == typeof(char))
			{
				return AsChar(provider);
			}
			else if (conversionType == typeof(Nullable<char>))
			{
				return AsCharNullable(provider);
			}
			else if (conversionType == typeof(DateTime))
			{
				return AsDateTime(provider);
			}
			else if (conversionType == typeof(Nullable<DateTime>))
			{
				return AsDateTimeNullable(provider);
			}
			else if (conversionType == typeof(decimal))
			{
				return AsDecimal(provider);
			}
			else if (conversionType == typeof(Nullable<decimal>))
			{
				return AsDecimalNullable(provider);
			}
			else if (conversionType == typeof(double))
			{
				return AsDouble(provider);
			}
			else if (conversionType == typeof(Nullable<double>))
			{
				return AsDoubleNullable(provider);
			}
			else if (conversionType == typeof(int))
			{
				return AsInt16(provider);
			}
			else if (conversionType == typeof(Nullable<int>))
			{
				return AsInt16Nullable(provider);
			}
			else if (conversionType == typeof(long))
			{
				return AsInt64(provider);
			}
			else if (conversionType == typeof(Nullable<long>))
			{
				return AsInt64Nullable(provider);
			}
			else if (conversionType == typeof(short))
			{
				return AsInt16(provider);
			}
			else if (conversionType == typeof(Nullable<short>))
			{
				return AsInt16Nullable(provider);
			}
			else if (conversionType == typeof(sbyte))
			{
				return AsSByte(provider);
			}
			else if (conversionType == typeof(Nullable<sbyte>))
			{
				return AsSByteNullable(provider);
			}
			else if (conversionType == typeof(float))
			{
				return AsSingle(provider);
			}
			else if (conversionType == typeof(Nullable<float>))
			{
				return AsSingleNullable(provider);
			}
			else if (conversionType == typeof(ushort))
			{
				return AsUInt16(provider);
			}
			else if (conversionType == typeof(Nullable<ushort>))
			{
				return AsUInt16Nullable(provider);
			}
			else if (conversionType == typeof(ulong))
			{
				return AsUInt64(provider);
			}
			else if (conversionType == typeof(Nullable<ulong>))
			{
				return AsUInt64Nullable(provider);
			}
			else if (conversionType == typeof(uint))
			{
				return AsUInt32(provider);
			}
			else if (conversionType == typeof(Nullable<uint>))
			{
				return AsUInt32Nullable(provider);
			}
			else if (conversionType == typeof(string))
			{
				return AsString(provider);
			}
			else if (conversionType == typeof(IList))
			{
				return AsList();
			}
			else if (conversionType == typeof(IDictionary))
			{
				return AsDictionary();
			}
			else
			{
				return Convert.ChangeType(Value, conversionType);
			}
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return AsUInt16(provider);
		}

		public ushort AsUInt16()
		{
			return AsUInt16(GetProviderOrDefault());
		}

		public ushort AsUInt16(IFormatProvider provider)
		{
			return AsType<ushort>(provider, ParseUtility.ParseUInt16, Convert.ToUInt16);
		}

		public ushort? AsUInt16Nullable()
		{
			return AsUInt16Nullable(GetProviderOrDefault());
		}

		public ushort? AsUInt16Nullable(IFormatProvider provider)
		{
			return AsNullableType<ushort>(provider, ParseUtility.ParseUInt16, Convert.ToUInt16);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return AsUInt32(provider);
		}

		public uint AsUInt32()
		{
			return AsUInt32(GetProviderOrDefault());
		}

		public uint AsUInt32(IFormatProvider provider)
		{
			return AsType<uint>(provider, ParseUtility.ParseUInt32, Convert.ToUInt32);
		}

		public uint? AsUInt32Nullable()
		{
			return AsUInt32Nullable(GetProviderOrDefault());
		}

		public uint? AsUInt32Nullable(IFormatProvider provider)
		{
			return AsNullableType<uint>(provider, ParseUtility.ParseUInt32, Convert.ToUInt32);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return AsType<ulong>(provider, ParseUtility.ParseUInt64, Convert.ToUInt64);
		}

		public ulong AsUInt64()
		{
			return AsUInt64(GetProviderOrDefault());
		}

		public ulong AsUInt64(IFormatProvider provider)
		{
			return AsType<ulong>(provider, ParseUtility.ParseUInt64, Convert.ToUInt64);
		}

		public ulong? AsUInt64Nullable()
		{
			return AsUInt64Nullable(GetProviderOrDefault());
		}

		public ulong? AsUInt64Nullable(IFormatProvider provider)
		{
			return AsNullableType<ulong>(provider, ParseUtility.ParseUInt64, Convert.ToUInt64);
		}

		protected T AsType<T>(
			IFormatProvider provider,
			Func<string, IFormatProvider, T> parseMethod,
			Func<object, IFormatProvider, T> convertMethod
			) where T : struct
		{
			if (!IsValue)
			{
				throw new InvalidOperationException("Not a value...");
			}

			var asString = Value as string;

			if (asString != null)
			{
				return parseMethod.Invoke(asString, provider);
			}
			else
			{
				return convertMethod.Invoke(Value, provider);
			}
		}

		protected T? AsNullableType<T>(
			IFormatProvider provider,
			Func<string, IFormatProvider, T> parseMethod,
			Func<object, IFormatProvider, T> convertMethod
			) where T : struct
		{
			if (!IsValue)
			{
				throw new InvalidOperationException("Not a value...");
			}

			if (Value == null)
			{
				return null;
			}
			else
			{
				var asString = Value as string;

				if (asString != null)
				{
					if (asString.Trim().Length > 0)
					{
						return parseMethod.Invoke(asString, provider);
					}
					else
					{
						return null;
					}
				}
				else
				{
					return convertMethod.Invoke(Value, provider);
				}
			}
		}
	}
}