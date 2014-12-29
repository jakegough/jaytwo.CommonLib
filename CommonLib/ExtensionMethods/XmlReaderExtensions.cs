using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class XmlReaderExtensions
	{
		public static XmlDocument GetXmlDocument(this XmlReader reader)
		{
			using (reader)
			{
				var result = new XmlDocument();
				result.Load(reader);
				return result;
			}			
		}
	}
}
