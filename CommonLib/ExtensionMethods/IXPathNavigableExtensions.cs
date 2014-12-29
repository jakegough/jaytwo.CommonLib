using System;
using System.Xml.XPath;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class IXPathNavigableExtensions
	{
		public static string GetXPathInnerXml(this IXPathNavigable node, string xpath)
		{
			if (node == null) throw new ArgumentNullException("node");

			var outNode = node.CreateNavigator().SelectSingleNode(xpath);

			return (outNode != null)
				? outNode.InnerXml
				: string.Empty;
		}

		public static string GetXPathValue(this IXPathNavigable node, string xpath)
		{
			if (node == null) throw new ArgumentNullException("node");

			var outNode = node.CreateNavigator().SelectSingleNode(xpath);

			return (outNode != null)
				? outNode.Value
				: string.Empty;
		}
	}
}