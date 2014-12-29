using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class StreamExtensions
	{
		public static void SaveToFile(this Stream stream, string filePath)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			using (var fileStream = File.OpenWrite(filePath))
			{
				stream.CopyTo(fileStream);
			}
		}

		public static MemoryStream ToMemoryStream(this Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return ToMemoryStream(stream, 4096);
		}

		public static MemoryStream ToMemoryStream(this Stream stream, int contentLength)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			MemoryStream result = (stream as MemoryStream);

			if (result == null)
			{
				result = new MemoryStream(contentLength);

				using (stream)
				{
					stream.CopyTo(result);
				}
			}

			return result;
		}

		public static GZipStream Gzip(this Stream stream, CompressionMode mode)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return new GZipStream(stream, mode);
		}

		public static DeflateStream Deflate(this Stream stream, CompressionMode mode)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return new DeflateStream(stream, mode);
		}

		public static StreamReader GetReader(this Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return stream.GetReader(null);
		}

		public static StreamReader GetReader(this Stream stream, Encoding encoding)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return (encoding != null)
				? new StreamReader(stream, encoding)
				: new StreamReader(stream, true);
		}

		public static XmlReader GetXmlReader(this Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return stream.GetXmlReader(null);
		}

		public static XmlReader GetXmlReader(this Stream stream, Encoding encoding)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			var reader = stream.GetReader(encoding);
			return XmlReader.Create(reader);
		}

		public static XmlReader GetXmlReader(this Stream stream, Encoding encoding, XmlReaderSettings settings)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			if (encoding != null)
			{
				var reader = stream.GetReader(encoding);
				return XmlReader.Create(reader, settings);
			}
			else
			{
				return XmlReader.Create(stream, settings);
			}
		}

		public static StreamWriter GetWriter(this Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return stream.GetWriter(null);
		}

		public static StreamWriter GetWriter(this Stream stream, Encoding encoding)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return (encoding != null)
				? new StreamWriter(stream, encoding)
				: new StreamWriter(stream);
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

		public static byte[] ReadBytes(this Stream stream, int qty)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			var result = new byte[qty];
			stream.Read(result, 0, qty);
			return result;
		}

		public static byte[] GetBytes(this Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return stream
				.ToMemoryStream()
				.ToArray();
		}

		public static byte[] ComputeMd5Hash(this Stream stream)
		{
			using (var algorithm = MD5.Create())
			{
				return stream.ComputeHash(algorithm);
			}			
		}

		public static byte[] ComputeSha1Hash(this Stream stream)
		{
			using (var algorithm = new HMACSHA1())
			{
				return stream.ComputeHash(algorithm);
			}
		}

		public static byte[] ComputeSha1Hash(this Stream stream, byte[] salt)
		{
			using (var algorithm = new HMACSHA1(salt))
			{
				return stream.ComputeHash(algorithm);
			}
		}

		public static byte[] ComputeSha256Hash(this Stream stream)
		{
			using (var algorithm = new HMACSHA256())
			{
				return stream.ComputeHash(algorithm);
			}
		}

		public static byte[] ComputeSha256Hash(this Stream stream, byte[] salt)
		{
			using (var algorithm = new HMACSHA256(salt))
			{
				return stream.ComputeHash(algorithm);
			}
		}

		private static byte[] ComputeHash(this Stream stream, HashAlgorithm algorithm)
		{
			byte[] result;

			if (stream.CanSeek)
			{
				var position = stream.Position;

				stream.Position = 0;
				result = algorithm.ComputeHash(stream);
				stream.Position = position;
			}
			else
			{
				return algorithm.ComputeHash(stream);
			}

			return result;
		}

		public static string GetString(this Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return stream.GetReader().ReadToEnd();
		}

		public static string GetString(this Stream stream, Encoding encoding)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			return stream.GetReader(encoding).ReadToEnd();
		}
	}
}
