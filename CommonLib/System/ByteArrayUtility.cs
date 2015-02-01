using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace jaytwo.Common.System
{
    public static class ByteArrayUtility
    {
        public static string ToHexString(byte[] value)
        {
            return BitConverter.ToString(value).Replace("-", string.Empty);
        }

        public static string ToBase64String(byte[] value)
        {
            return Convert.ToBase64String(value);
        }

        public static string ToUtf8String(byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }

        public static short ToInt16(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length > 2)
            {
                throw new ArgumentException("Int16 must be 2 bytes or less.");
            }

            return BitConverter.ToInt16(value, 0);
        }

        public static int ToInt32(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length > 4)
            {
                throw new ArgumentException("Int32 must be 4 bytes or less.");
            }

            return BitConverter.ToInt32(value, 0);
        }

        public static long ToInt64(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length > 8)
            {
                throw new ArgumentException("Int64 must be 8 bytes or less.");
            }

            return BitConverter.ToInt64(value, 0);
        }

        public static byte[] ComputeMD5Hash(byte[] value)
        {
            using (var algorithm = MD5.Create())
            {
                return algorithm.ComputeHash(value);
            }
        }

        public static byte[] ComputeSHA1Hash(byte[] value)
        {
            using (var algorithm = SHA1CryptoServiceProvider.Create())
            {
                return algorithm.ComputeHash(value);
            }
        }

        public static byte[] ComputeSHA256Hash(byte[] value)
        {
            using (var algorithm = SHA256CryptoServiceProvider.Create())
            {
                return algorithm.ComputeHash(value);
            }
        }
    }
}
