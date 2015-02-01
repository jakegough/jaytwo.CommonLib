using jaytwo.Common.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.Test
{
    public static class TestUtility
    {
        public static Uri GetUriFromString(string url)
        {
            var kind = (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute)) ? UriKind.Absolute : UriKind.Relative;
            var uri = string.IsNullOrEmpty(url) ? null : new Uri(url, kind);
            return uri;
        }

        public static HttpWebResponse GetResponseFromUrl(string url)
        {
            var uri = GetUriFromString(url);

            if (uri != null)
            {
                return HttpProvider.SubmitGet(uri);
            }
            else
            {
                return null;
            }
        }

		private static bool IsObjectTypeMatch(object a, Type b)
		{
			if (a == null)
			{
				return b.IsClass;
			}
			else
			{
				return b.IsInstanceOfType(a);
			}
		}

		public static IEnumerable<TestCaseData> GetTestCasesWithArgumentTypes<T>(IEnumerable<TestCaseData> testCases)
		{
			foreach (var item in testCases)
			{
				if (item.Arguments.Length == 1
					&& IsObjectTypeMatch(item.Arguments[0], typeof(T)))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<TestCaseData> GetTestCasesWithArgumentTypes<T0, T1>(IEnumerable<TestCaseData> testCases)
		{
			foreach (var item in testCases)
			{
				if (item.Arguments.Length == 2
					&& IsObjectTypeMatch(item.Arguments[0], typeof(T0))
					&& IsObjectTypeMatch(item.Arguments[1], typeof(T1)))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<TestCaseData> GetTestCasesWithArgumentTypes<T0, T1, T2>(IEnumerable<TestCaseData> testCases)
		{
			foreach (var item in testCases)
			{
				if (item.Arguments.Length == 3
					&& IsObjectTypeMatch(item.Arguments[0], typeof(T0))
					&& IsObjectTypeMatch(item.Arguments[1], typeof(T1))
					&& IsObjectTypeMatch(item.Arguments[2], typeof(T2)))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<TestCaseData> GetTestCasesWithArgumentTypes<T0, T1, T2, T3>(IEnumerable<TestCaseData> testCases)
		{
			foreach (var item in testCases)
			{
				if (item.Arguments.Length == 4
					&& IsObjectTypeMatch(item.Arguments[0], typeof(T0))
					&& IsObjectTypeMatch(item.Arguments[1], typeof(T1))
					&& IsObjectTypeMatch(item.Arguments[2], typeof(T2))
					&& IsObjectTypeMatch(item.Arguments[3], typeof(T3)))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<TestCaseData> GetTestCasesWithArgumentTypes<T0, T1, T2, T3, T4>(IEnumerable<TestCaseData> testCases)
		{
			foreach (var item in testCases)
			{
				if (item.Arguments.Length == 5
					&& IsObjectTypeMatch(item.Arguments[0], typeof(T0))
					&& IsObjectTypeMatch(item.Arguments[1], typeof(T1))
					&& IsObjectTypeMatch(item.Arguments[2], typeof(T2))
					&& IsObjectTypeMatch(item.Arguments[3], typeof(T3))
					&& IsObjectTypeMatch(item.Arguments[4], typeof(T4)))
				{
					yield return item;
				}
			}
		}
    }
}
