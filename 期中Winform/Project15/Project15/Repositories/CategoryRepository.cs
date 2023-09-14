using Dapper;
using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Repositories
{
	public class CategoryRepository
	{
		//public MediaInfoEntity Get(CategoryEntity entity)
		//{
		//	string sql = "SELECT * FROM MediaInfos WHERE Id = @Id";

		//	var db = new SqlDb();

		//	SqlParameter[] parameters = new SqlParameterBuilder()
		//		.AddInt("@Id", entity.Id)
		//		.Build();

		//	Func<SqlDataReader, MediaInfoEntity> func = (reader) =>
		//	{
		//		return new MediaInfoEntity
		//		{
		//			Id = reader.GetInt("Id"),
		//			CategoryId = reader.GetInt("CategoryId"),
		//			Title = reader.GetString("Title"),
		//			OverView = reader.GetString("OverView"),
		//			ReleaseDate = reader.GetDateTime("ReleaseDate"),
		//		};
		//	};

		//	return db.Get(sql, parameters, func);
		//}

		public List<CategoryEntity> GetAll() 
		{
			List<CategoryEntity> categories = new List<CategoryEntity>();
			string sql = "SELECT * FROM Categories";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder().Build();
			using (var conn = db.GetConnection("default"))
			{
				conn.Open();

				var command = new SqlCommand(sql, conn);

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					CategoryEntity item = new CategoryEntity()
					{
						Id = reader.GetInt("Id"),
						Name = reader.GetString("Name"),
						DisplayOrder = reader.GetInt("DisplayOrder")
					};
					categories.Add(item);
				}
				return categories;
			}
		}

		public List<MediaCategory> GetMediaCategory()
		{
			string sql = @"SELECT MediaInfos.Id AS MediaInfoId,Categories.Name AS CategoryName,MediaInfos.CategoryId AS CategoryId FROM Categories
INNER JOIN MediaInfos ON Categories.Id = MediaInfos.CategoryId";

			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				return conn.Query<MediaCategory>(sql).ToList();
			}
		}
	}
}
