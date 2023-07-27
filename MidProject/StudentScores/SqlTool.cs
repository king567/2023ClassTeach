using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace StudentScores
{
	public class SqlTool
	{
		public string server = @".\sql2022";
		public string initCatalog = @"StudentScores";
		public string username = @"sa";
		public string password = @"Happydaygo4";

		public string GetConnectString() 
		{
			return $"Data Source={server};Initial Catalog={initCatalog};User Id={username};Password={password};";
		}

		public string InsertQuery(Scores score)
		{
			/*
				INSERT INTO "表格名" ("欄位1", "欄位2", ...)
				VALUES ("值1", "值2", ...);
			 */
			return $"INSERT INTO Scores (Name,Chinese,Math,English) VALUES ('{score.Name}','{score.Chinese}','{score.Math}','{score.English}')";
		}

		public string UpdateQuery()
		{
			/*
				UPDATE "表格"
				SET "欄位1" = [值1], "欄位2" = [值2]
				WHERE "條件";
			 */
			return @"UPDATE Scores SET Chinese = 100, Math = 100,English = 50 WHERE Name = 'king' ";
		}

		public string DeleteQuery()
		{
			/*
				DELETE FROM "表格名"
				WHERE "條件";
			 */
			return @"DELETE FROM Scores WHERE Name = 'king';";
		}

		public string GETAllQuery() 
		{ 
			return "SELECT * FROM Scores"; 
		}
		public string SearchQuery()
		{
			return "SELECT * FROM Scores WHERE Chinese > 50";
		}

		public List<Scores> GetStudentScores(string sqlQuery)
		{
			using (IDbConnection dbConnection = new SqlConnection(GetConnectString()))
			{
				dbConnection.Open();

				// Execute the query using Dapper
				List<Scores> students = dbConnection.Query<Scores>(sqlQuery).ToList();

				dbConnection.Close();

				return students;
			}
		}

	}
}
