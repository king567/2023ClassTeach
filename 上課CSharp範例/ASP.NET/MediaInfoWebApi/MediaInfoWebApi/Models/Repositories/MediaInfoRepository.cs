using MediaInfoWebApi.Models.Entities;
using MediaInfoWebApi.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediaInfoWebApi.Models.Repositories
{
	public class MediaInfoRepository
	{
		// 取得所有媒體資訊
		public List<MediaInfoEntity> GetAll()
		{
			List<MediaInfoEntity> mediaInfos = new List<MediaInfoEntity>();

			string sql = @"SELECT * FROM MediaInfos";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder().Build();

			using (var conn = db.GetConnection("default"))
			{
				conn.Open();

				var command = new SqlCommand(sql, conn);

				command.Parameters.AddRange(parameters);

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					MediaInfoEntity item = new MediaInfoEntity()
					{
						Id = reader.GetInt("Id"),
						CategoryId = reader.GetInt("CategoryId"),
						Title = reader.GetString("Title"),
						OverView = reader.GetString("OverView"),
						ReleaseDate = reader.GetDateTime("ReleaseDate"),
						//Adult = reader.GetBoolean("Adult"),
						//Popularity = reader.GetDouble("Popularity"),
						//OriginalLanguage = reader.GetString("OriginalLanguage"),
						//OriginalTitle = reader.GetString("OriginalTitle"),
						//Video = reader.GetBoolean("Video"),
						//BackdropPath = reader.GetString("BackdropPath"),
						//PosterPath = reader.GetString("PosterPath"),
						//OTT = reader.GetString("OTT"),
						//Genre = reader.GetString("Genre"),
						//Categories = reader.GetString("Category")
					};
					mediaInfos.Add(item);
				}
				return mediaInfos;
			};

		}
	}
}