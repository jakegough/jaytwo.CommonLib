using jaytwo.Common.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace jaytwo.Common.Extensions
{
	public static partial class HttpWebResponseExtensions
	{
		public static byte[] DownloadBytes(this HttpWebResponse httpWebResponse)
		{
			return HttpProvider.DownloadBytes(httpWebResponse);
		}

		public static Image DownloadImage(this HttpWebResponse httpWebResponse)
		{
			return HttpProvider.DownloadImage(httpWebResponse);
		}

		public static string DownloadString(this HttpWebResponse httpWebResponse)
		{
			return HttpProvider.DownloadString(httpWebResponse);
		}
	}
}