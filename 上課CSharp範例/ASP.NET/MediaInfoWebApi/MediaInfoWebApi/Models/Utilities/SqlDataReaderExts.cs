using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaInfoWebApi.Models.Utilities
{
	public static class SqlDataReaderExts
	{
		private static T GetValue<T>(this SqlDataReader reader, string columnName, Func<int, T> func)
		{
			try
			{
				int index = reader.GetOrdinal(columnName);
				return func(index);
			}
			catch (IndexOutOfRangeException ex1)
			{
				throw new Exception($"找不到欄位名稱({columnName}),請確認是打錯欄位名稱", ex1);
			}
			catch (Exception)
			{
				throw;
			}
		}
		public static int GetInt(this SqlDataReader reader, string columnName)
		{
			Func<int, int> func = (idx) => reader.GetInt32(idx);
			return GetValue<int>(reader, columnName, func);
		}

		public static string GetString(this SqlDataReader reader, string columnName)
		{
			Func<int, string> func = (idx) => reader.GetString(idx);
			return GetValue<string>(reader, columnName, func);
		}

		public static bool GetBoolean(this SqlDataReader reader, string columnName)
		{
			Func<int, bool> func = (idx) => reader.GetBoolean(idx);
			return GetValue<bool>(reader, columnName, func);
		}

		public static DateTime GetDateTime(this SqlDataReader reader, string columnName)
		{
			Func<int, DateTime> func = (idx) => reader.GetDateTime(idx);
			return GetValue<DateTime>(reader, columnName, func);
		}

		public static double GetDouble(this SqlDataReader reader, string columnName)
		{
			Func<int, double> func = (idx) => reader.GetDouble(idx);
			return GetValue<double>(reader, columnName, func);
		}
	}
}
