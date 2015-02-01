using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using jaytwo.Common.System;

namespace jaytwo.Common.Extensions
{
	public static class ByteArrayExtensions
	{
		public static string AsHexString(this byte[] value)
		{
            return ByteArrayUtility.ToHexString(value);
		}

		public static string AsBase64String(this byte[] value)
		{
            return ByteArrayUtility.ToBase64String(value);
		}

        public static string AsUtf8String(this byte[] value)
        {
            return ByteArrayUtility.ToUtf8String(value);
        }

        public static short AsInt16(this byte[] value)
        {
            return ByteArrayUtility.ToInt16(value);
        }

		public static int AsInt32(this byte[] value)
		{
            return ByteArrayUtility.ToInt32(value);
		}

        public static long AsInt64(this byte[] value)
        {
            return ByteArrayUtility.ToInt64(value);
        }

        public static byte[] ComputeMD5Hash(this byte[] value)
        {
            return ByteArrayUtility.ComputeMD5Hash(value);
        }

        public static byte[] ComputeSHA1Hash(this byte[] value)
        {
            return ByteArrayUtility.ComputeSHA1Hash(value);
        }

        public static byte[] ComputeSHA256Hash(this byte[] value)
        {
            return ByteArrayUtility.ComputeSHA256Hash(value);
        }
	}
}