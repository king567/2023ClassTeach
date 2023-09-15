using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediaInfoWebApi.Models.Utilities
{
	public class SqlDb
	{
		public string GetConnString(string key)
		{
			var setting = System.Configuration.ConfigurationManager.ConnectionStrings[key];

			if (setting == null)
			{
				throw new Exception("找不到key值");
			}

			return setting.ConnectionString;
		}

		public SqlConnection GetConnection(string key)
		{
			var connString = GetConnString(key);
			return new SqlConnection(connString);
		}

		public void UpdateOrDelete(string sql, SqlParameter[] parameters)
		{
			var db = new SqlDb();
			using (var conn = db.GetConnection("default"))
			{
				conn.Open();

				var command = new SqlCommand(sql, conn);
				if (parameters != null && parameters.Length > 0)
				{
					command.Parameters.AddRange(parameters);
				}
				command.ExecuteNonQuery();
			}
		}

		public int Create(string sql, SqlParameter[] parameters)
		{
			var db = new SqlDb();
			using (var conn = db.GetConnection("default"))
			{
				conn.Open();

				var command = new SqlCommand(sql, conn);
				if (parameters != null && parameters.Length > 0)
				{
					command.Parameters.AddRange(parameters);
				}
				int newId = Convert.ToInt32(command.ExecuteScalar());
				return newId;
			}
		}

		public T Get<T>(string sql, SqlParameter[] parameters, Func<SqlDataReader, T> func)
		{

			var db = new SqlDb();
			using (var conn = db.GetConnection("default"))
			{
				conn.Open();
				var command = new SqlCommand(sql, conn);

				if (parameters != null && parameters.Length > 0)
				{
					command.Parameters.AddRange(parameters);
				}

				var reader = command.ExecuteReader();
				if (reader.Read() == false)
				{
					return default(T);
				}
				return func(reader);
			}
		}
	}
}