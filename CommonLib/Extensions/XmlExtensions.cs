using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

using jaytwo.Common.System;
using jaytwo.Common.Xml;

namespace jaytwo.Common.Extensions
{
    public static partial class XmlExtensions
    {
        public static string GetXPathInnerXml(this XNode node, string xpath)
        {
            return XmlUtility.GetXPathInnerXml(node, xpath);
        }

        public static string GetXPathValue(this XNode node, string xpath)
        {
            return XmlUtility.GetXPathValue(node, xpath);
        }

        public static string GetXPathInnerXml(this IXPathNavigable node, string xpath)
        {
            return XmlUtility.GetXPathInnerXml(node, xpath);
        }

        public static string GetXPathValue(this IXPathNavigable node, string xpath)
        {
            return XmlUtility.GetXPathValue(node, xpath);
        }
    }
}