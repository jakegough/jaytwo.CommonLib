using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mime;

namespace jaytwo.CommonLib.Web
{
    public class MimeFile : IDisposable
    {
        public Stream ContentStream
        {
            get;
            set;
        }

        public string FormFieldName
        {
            get;
            set;
        }

        public ContentType ContentType
        {
            get;
            set;
        }

        public ContentDisposition ContentDisposition
        {
            get;
            set;
        }

        public void Dispose()
        {
			if (ContentStream != null)
			{
				using (ContentStream)
				{
				}
			}
        }
    }
}
