using System.Linq;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace jaytwo.Common.Xml
{
    public static class XmlUtility
    {
		public static string GetXPathInnerXml(XNode node, string xpath)
		{
            if (node != null)
            {
                var outNode = node.CreateNavigator().SelectSingleNode(xpath);
                return GetNodeInnerXml(outNode);
            }
            else
            {
                return null;
            }
		}

		public static string GetXPathValue(XNode node, string xpath)
		{
            if (node != null)
            {
                var outNode = node.CreateNavigator().SelectSingleNode(xpath);
                return GetNodeValue(outNode);
            }
            else
            {
                return null;
            }
		}

        public static string GetXPathInnerXml(IXPathNavigable node, string xpath)
        {
            if (node != null)
            {
                var outNode = node.CreateNavigator().SelectSingleNode(xpath);
                return GetNodeInnerXml(outNode);
            }
            else
            {
                return null;
            }
        }

        public static string GetXPathValue(IXPathNavigable node, string xpath)
        {
            if (node != null)
            {
                var outNode = node.CreateNavigator().SelectSingleNode(xpath);
                return GetNodeValue(outNode);
            }
            else
            {
                return null;
            }
        }

        private static string GetNodeInnerXml(XPathNavigator node)
        {
            return (node != null)
                ? node.InnerXml
                : null;
        }

        private static string GetNodeValue(XPathNavigator node)
        {
            return (node != null)
                ? node.Value
                : null;
        }
    }
}
