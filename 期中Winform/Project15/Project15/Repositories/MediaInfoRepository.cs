using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;

namespace Project15.Repositories
{
	public class MediaInfoRepository
	{
		public List<CriteriaEntity> Search(SearchCriteriaEntity criteria)
		{
			string title = criteria.Title;
			int? genreId = criteria.GenreId;
			int? ottId = criteria.OttId;
			int? categoryId = criteria.CategoryId;
			DateTime? dateTimeLow = criteria.DateTimeLow;
			DateTime? dateTomeHeight = criteria.DateTimeHeight;

			//List<CriteriaEntity> medias = new List<CriteriaEntity>();

			string sql =
					@"SELECT 
					M.*,OttTypes.Id AS OttTypeId,
					C.Name AS Category,
					OttTypes.Name AS OTT,
					Genres.Name AS Genre 
					FROM MediaInfos as M
					INNER JOIN Categories as C ON M.CategoryId = C.Id
					INNER JOIN VideoOttTypes as Ott ON M.Id = Ott.MediaInfoId
					INNER JOIN OttTypes on OttTypeId = Ott.OttTypeId
					INNER JOIN VideoGenres as G ON M.Id = G.MediaInfoId
					INNER JOIN Genres ON Genres.Id = G.GenreId
					WHERE 
					(@CategoryId IS NULL OR CategoryId= @CategoryId)
					AND (@Title IS NULL OR M.Title like '%' + @Title + '%')
					AND (@OttId IS NULL OR OttTypes.Id = @OttId)
					AND (@GenreId IS NULL OR Genres.Id = @GenreId)
					AND (@DateTimeLow IS NULL OR ReleaseDate > @DateTimeLow)
					AND (@DateTimeHeight IS NULL OR ReleaseDate < @DateTimeHeight)";

			var db = new SqlDb();

			SqlParameter p1 = new SqlParameter("CategoryId", System.Data.SqlDbType.Int);
			if (categoryId.HasValue)
				p1.Value = categoryId.Value;
			else
				p1.Value = DBNull.Value;

			SqlParameter p2 = new SqlParameter("Title", System.Data.SqlDbType.VarChar, 150);
			if (string.IsNullOrEmpty(title) == false)
				p2.Value = title;
			else
				p2.Value = DBNull.Value;

			SqlParameter p3 = new SqlParameter("OttId", System.Data.SqlDbType.Int);
			if (ottId.HasValue)
				p3.Value = ottId.Value;
			else
				p3.Value = DBNull.Value;

			SqlParameter p4 = new SqlParameter("GenreId", System.Data.SqlDbType.Int);
			if (genreId.HasValue)
				p4.Value = genreId.Value;
			else
				p4.Value = DBNull.Value;

			SqlParameter p5 = new SqlParameter("DateTimeLow", System.Data.SqlDbType.DateTime);
			if (dateTimeLow.HasValue)
				p5.Value = dateTimeLow.Value;
			else
				p5.Value = DBNull.Value;

			SqlParameter p6 = new SqlParameter("DateTimeHeight", System.Data.SqlDbType.DateTime);
			if (dateTomeHeight.HasValue)
				p6.Value = dateTomeHeight.Value;
			else
				p6.Value = DBNull.Value;

			using (var conn = db.GetConnection("default"))
			{
				List<CriteriaEntity> mediaInfos = new List<CriteriaEntity>();

				conn.Open();

				var command = new SqlCommand(sql, conn);

				command.Parameters.AddRange(new SqlParameter[] { p1, p2, p3, p4, p5, p6 });

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					CriteriaEntity item = new CriteriaEntity()
					{
						Id = reader.GetInt("Id"),
						CategoryId = reader.GetInt("CategoryId"),
						Title = reader.GetString("Title"),
						OverView = reader.GetString("OverView"),
						ReleaseDate = reader.GetDateTime("ReleaseDate"),
						OTT = reader.GetString("OTT"),
						Genre = reader.GetString("Genre"),
						Categories = reader.GetString("Category")
					};
					mediaInfos.Add(item);
				}

				return mediaInfos;
			}

		}
		public MediaInfoEntity Get(MediaInfoEntity entity)
		{
			/*
				SELECT M.*,C.Name AS Category,OttTypes.Name AS OTT,Genres.Name AS Genre FROM MediaInfos as M
				INNER JOIN Categories as C ON M.CategoryId = C.Id
				INNER JOIN VideoOttTypes as Ott ON M.Id = Ott.MediaInfoId
				INNER JOIN OttTypes on OttTypeId = Ott.OttTypeId
				INNER JOIN VideoGenres as G ON M.Id = G.MediaInfoId
				INNER JOIN Genres ON Genres.Id = G.GenreId
				WHERE M.Id=1
			 */
			string sql = "SELECT * FROM MediaInfos WHERE Id=@Id";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder()
				.AddInt("@Id", entity.Id)
				.Build();

			Func<SqlDataReader, MediaInfoEntity> func = (reader) =>
			{
				return new MediaInfoEntity
				{
					Id = entity.Id,
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
					//PosterPath = reader.GetString("PosterPath")
				};
			};

			return db.Get(sql, parameters, func);
		}
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
		public List <MediaInfoListDTO> GetAllByCriteria() 
		{
			List<MediaInfoListDTO> mediaInfos = new List<MediaInfoListDTO>();

			string sql = @" SELECT M.*,C.Name AS Category,OttTypes.Name AS OTT,Genres.Name AS Genre FROM MediaInfos as M
							INNER JOIN Categories as C ON M.CategoryId = C.Id
							INNER JOIN VideoOttTypes as Ott ON M.Id = Ott.MediaInfoId
							INNER JOIN OttTypes on OttTypeId = Ott.OttTypeId
							INNER JOIN VideoGenres as G ON M.Id = G.MediaInfoId
							INNER JOIN Genres ON Genres.Id = G.GenreId
							ORDER BY M.Id";

			//string sql = @"SELECT * FROM MediaInfos";

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
					MediaInfoListDTO item = new MediaInfoListDTO()
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
		public void Update(MediaInfoEntity entity)
		{
			string sql = @" UPDATE MediaInfos 
							SET CategoryId = @CategoryId,Title=@Title,OverView=@OverView,ReleaseDate=@ReleaseDate
							WHERE Id = @Id";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder()
					.AddInt("@Id", entity.Id)
					.AddInt("@CategoryId", entity.CategoryId)
					.AddNVarchar("@Title",150,entity.Title)
					.AddNVarchar("@OverView", int.MaxValue, entity.OverView)
					.AddDateTime("@ReleaseDate",entity.ReleaseDate)
					.Build();

			db.UpdateOrDelete(sql, parameters);
		}
		public void Delete(MediaInfoEntity entity)
		{

			string sql = @"DELETE FROM MediaInfos WHERE Id = @Id";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder()
					.AddInt("@Id", entity.Id)
					.Build();

			db.UpdateOrDelete(sql, parameters);
		}
		public int Create(MediaInfoEntity entity)
		{
			int newId = 0;

			string sql = @"INSERT INTO MediaInfos(CategoryId,Title,OverView,ReleaseDate) 
						VALUES (@CategoryId,@Title,@OverView,@ReleaseDate);
						SELECT CAST(SCOPE_IDENTITY() AS INT);";

			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				newId = conn.QuerySingle<int>(sql, entity);
			}

			return newId;
		}
	}
}
