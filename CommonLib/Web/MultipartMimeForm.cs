using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using jaytwo.CommonLib.ExtensionMethods;
using jaytwo.CommonLib.Time;

namespace jaytwo.CommonLib.Web
{
	public class MultipartMimeForm : IDisposable
	{
		public MultipartMimeForm()
		{
			Form = new NameValueCollection();
			Files = new List<MimeFile>();

			Boundary = string.Format("boundary_{0}", Guid.NewGuid());
		}

		public string Boundary
		{
			get;
			private set;
		}

		public NameValueCollection Form
		{
			get;
			private set;
		}

		public List<MimeFile> Files
		{
			get;
			private set;
		}

		public string GetContentType()
		{
			return string.Format("{0}; boundary={1}", MimeTypes.multipart_form_data, Boundary);
		}

		public long GetContentLength(Encoding encoding)
		{
			return GetContentAsStream(encoding).Length;
		}

		public string GetContentMd5(Encoding encoding)
		{
			return GetContentAsStream(encoding).ComputeMd5Hash().ToBase64String();
		}

		private MemoryStream contentStream;
		public Stream GetContentAsStream(Encoding encoding)
		{
			if (contentStream == null)
			{
				contentStream = new MemoryStream();

				StreamWriter writer = contentStream.GetWriter(encoding);
				for (int i = 0; i < Form.Count; i++)
				{
					string key = Form.Keys[i];
					string value = Form.Get(i);

					writer.Write("\r\n--{0}", Boundary);
					writer.Write("\r\nContent-Disposition: form-data; name=\"{0}\"", key);
					writer.Write("\r\n");
					writer.Write("\r\n{0}", value);

					writer.Flush();
				}

				foreach (MimeFile file in Files)
				{
					writer.Write("\r\n--{0}", Boundary);

					writer.Write("\r\nContent-Disposition: form-data; name=\"{0}\"", file.FormFieldName);

					if (file.ContentDisposition != null)
					{
						if (!string.IsNullOrEmpty(file.ContentDisposition.FileName))
						{
							writer.Write("; filename=\"{0}\"",
								file.ContentDisposition.FileName);
						}
						if (file.ContentDisposition.CreationDate > DateTime.MinValue)
						{
							writer.Write("; creation-date=\"{0}\"",
								TimeUtility.GetHttpDate(file.ContentDisposition.CreationDate.ToUniversalTime()));
						}
						if (file.ContentDisposition.ModificationDate > DateTime.MinValue)
						{
							writer.Write("; modification-date=\"{0}\"",
								TimeUtility.GetHttpDate(file.ContentDisposition.ModificationDate.ToUniversalTime()));
						}
						if (file.ContentDisposition.ReadDate > DateTime.MinValue)
						{
							writer.Write("; read-date=\"{0}\"",
								TimeUtility.GetHttpDate(file.ContentDisposition.ReadDate.ToUniversalTime()));
						}
						if (file.ContentDisposition.Size >= 0)
						{
							writer.Write("; size={0}", file.ContentDisposition.Size);
						}
					}

					if (file.ContentType != null)
					{
						writer.Write("\r\nContent-Type: {0}", file.ContentType);
					}

					writer.Write("\r\n\r\n");
					writer.Flush();

					file.ContentStream.CopyTo(contentStream);
				}

				writer.Write(string.Format("\r\n--{0}--\r\n", Boundary));
				writer.Flush();
			}

			contentStream.Position = 0;
			return contentStream;
		}

		public void WriteToStream(Stream stream, Encoding encoding)
		{
			GetContentAsStream(encoding).CopyTo(stream);
		}

		~MultipartMimeForm()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (contentStream != null)
			{
				contentStream.Dispose();
				contentStream = null;
			}

			foreach (MimeFile mimeFile in Files)
			{
				mimeFile.Dispose();
			}
		}
	}
}
