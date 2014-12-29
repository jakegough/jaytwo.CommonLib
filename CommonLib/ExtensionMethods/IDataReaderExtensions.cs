using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace jaytwo.CommonLib.ExtensionMethods
{
	public static class IDataReaderExtensions
	{
		public static IEnumerable<IDataRecord> AsEnumerable(this IDataReader dataReader)
		{
			if (dataReader == null) throw new ArgumentNullException("dataReader");

			while (dataReader.Read())
			{
				yield return dataReader;
			}
		}
	}
}
