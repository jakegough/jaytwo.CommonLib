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
		public static void SaveToFile(this Stream stream, string filePath)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			using (var fileStream = File.OpenWrite(filePath))
			{
				StreamUtility.CopyStreamToStream(stream, fileStream);
			}
		}

	}
}