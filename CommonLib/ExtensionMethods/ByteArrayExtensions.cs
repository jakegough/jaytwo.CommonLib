using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class ByteArrayExtensions
	{
		public static byte[] ComputeMd5Hash(this byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			using (var algorithm = MD5.Create())
			{
				return algorithm.ComputeHash(value);
			}
		}

		public static byte[] ComputeSha1Hash(this byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			using (var algorithm = new SHA1CryptoServiceProvider())
			{
				return algorithm.ComputeHash(value);
			}
		}

		public static byte[] ComputeSha1Hash(this byte[] value, byte[] salt)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			using (var algorithm = new HMACSHA1(salt))
			{
				return algorithm.ComputeHash(value);
			}
		}

		public static byte[] ComputeSha256Hash(this byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			using (var algorithm = new SHA256CryptoServiceProvider())
			{
				return algorithm.ComputeHash(value);
			}
		}

		public static byte[] ComputeSha256Hash(this byte[] value, byte[] salt)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			using (var algorithm = new HMACSHA256(salt))
			{
				return algorithm.ComputeHash(value);
			}
		}

		public static string ToHexString(this byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return BitConverter.ToString(value).Replace("-", string.Empty);
		}

		public static string ToBase64String(this byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return Convert.ToBase64String(value);
		}

		public static long ToInt64(this byte[] bytes)
		{
			if (bytes.Length > 8)
			{
				throw new Exception("Int64 must be 8 bytes or less.");
			}

			return BitConverter.ToInt64(bytes, 0);
		}

		public static int ToInt32(this byte[] bytes)
		{
			if (bytes.Length > 4)
			{
				throw new Exception("Int32 must be 8 bytes or less.");
			}

			return BitConverter.ToInt32(bytes, 0);
		}

		public static string GetString(this byte[] value, Encoding encoding)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}

			return encoding.GetString(value);
		}

		public static string GetString(this byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			return Encoding.UTF8.GetString(value);
		}
	}
}
