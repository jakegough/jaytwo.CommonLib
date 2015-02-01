using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace jaytwo.Common.IO
{
	public static class StreamUtility
	{
		public static void CopyStreamToStream(Stream inputStream, Stream outputStream)
		{
            if (inputStream == null)
            {
                throw new ArgumentNullException("inputStream");
            }

#if GTENET40
            inputStream.CopyTo(outputStream);
#else
            // basically taken from decompiled Stream.CopyTo in ILSpy

            if (outputStream == null)
            {
                throw new ArgumentNullException("outputStream");
            }

            byte[] array = new byte[81920];
            int count;
            while ((count = inputStream.Read(array, 0, array.Length)) != 0)
            {
                outputStream.Write(array, 0, count);
            }
#endif
		}

		public static byte[] GetBytesFromStream(Stream stream)
		{
			using (var memoryStream = new MemoryStream())
			{
				CopyStreamToStream(stream, memoryStream);
				return memoryStream.ToArray();
			}
		}

		public static byte[] ComputeMD5Hash(Stream stream)
		{
			using (var algorithm = MD5.Create())
			{
				return ComputeHash(stream, algorithm);
			}
		}

		public static byte[] ComputeSHA1Hash(Stream stream)
		{
            using (var algorithm = SHA1CryptoServiceProvider.Create())
			{
				return ComputeHash(stream, algorithm);
			}
		}

		public static byte[] ComputeSHA256Hash(Stream stream)
		{
            using (var algorithm = SHA256CryptoServiceProvider.Create())
			{
				return ComputeHash(stream, algorithm);
			}
		}

		private static byte[] ComputeHash(Stream stream, HashAlgorithm algorithm)
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

	}
}
