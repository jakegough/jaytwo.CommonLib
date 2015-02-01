using jaytwo.Common.IO;
using jaytwo.Common.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace jaytwo.Common.Extensions
{
	public static class StreamExtensions
	{
#if NET35
        public static void CopyTo(this Stream source, Stream destination)
        {
            StreamUtility.CopyStreamToStream(source, destination);
        }
#endif

		public static StreamReader GetReader(this Stream stream)
		{
			return new StreamReader(stream);
		}

		public static StreamReader GetReader(this Stream stream, Encoding encoding)
		{
			return new StreamReader(stream, encoding);
		}

		public static StreamWriter GetWriter(this Stream stream)
		{
			return new StreamWriter(stream);
		}

		public static StreamWriter GetWriter(this Stream stream, Encoding encoding)
		{
			return new StreamWriter(stream, encoding);
		}

		public static void Write(this Stream stream, byte[] value)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			stream.Write(value, 0, value.Length);
		}

		public static byte[] ReadBytes(this Stream stream, int count)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			var result = new byte[count];
			stream.Read(result, 0, count);
			return result;
		}

        public static byte[] ReadAllBytes(this Stream stream)
        {
            return StreamUtility.GetBytesFromStream(stream);
        }

		public static byte[] ComputeMD5Hash(this Stream stream)
		{
			return StreamUtility.ComputeMD5Hash(stream);
		}

		public static byte[] ComputeSHA1Hash(this Stream stream)
		{
			return StreamUtility.ComputeSHA1Hash(stream);
		}

		public static byte[] ComputeSHA256Hash(this Stream stream)
		{
			return StreamUtility.ComputeSHA256Hash(stream);
		}
	}
}