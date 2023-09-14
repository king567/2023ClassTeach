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
using System.Windows.Forms;

namespace Project15.Repositories
{
	public class GenresRepository
	{
		public List<VideoGenresEntity> Get(VideoGenresEntity entity)
		{
			List<VideoGenresEntity> genres = new List<VideoGenresEntity>();

			string sql = "SELECT Id,MediaInfoId,GenreId FROM VideoGenres AS VG WHERE VG.MediaInfoId = @Id";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder()
				.AddInt("@Id", entity.Id)
				.Build();

			using (var conn = db.GetConnection("default"))
			{
				conn.Open();

				var command = new SqlCommand(sql, conn);

				command.Parameters.AddRange(parameters);

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					VideoGenresEntity item = new VideoGenresEntity()
					{
						Id = reader.GetInt("Id"),
						MediaInfoId = reader.GetInt("MediaInfoId"),
						GenreId = reader.GetInt("GenreId")
					};
					genres.Add(item);
				}
				return genres;
			}
		}
		public List<GenresEntity> GetAll()
		{
			List<GenresEntity> genres = new List<GenresEntity>();
			string sql = "SELECT * FROM Genres";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder().Build();
			using (var conn = db.GetConnection("default"))
			{
				conn.Open();

				var command = new SqlCommand(sql, conn);

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					GenresEntity item = new GenresEntity()
					{
						Id = reader.GetInt("Id"),
						Name = reader.GetString("Name")
					};
					genres.Add(item);
				}
				return genres;
			}
		}
		public void Update(List<VideoGenresEntity> entities)
		{
			string sql = @"INSERT INTO VideoGenres (MediaInfoId, GenreId) VALUES (@MediaInfoId,@GenreId);";

			this.Delete(entities);

			var db = new SqlDb();

			foreach (var entity in entities)
			{
				SqlParameter[] parameters = new SqlParameterBuilder()
					.AddInt("@MediaInfoId", entity.MediaInfoId)
					.AddInt("@GenreId", entity.GenreId)
					.Build();

				db.UpdateOrDelete(sql, parameters);
			}
		}
		public virtual void Delete(List<VideoGenresEntity> entities)
		{
			int mediaInfoId = entities[0].MediaInfoId;

			string sql = @"DELETE FROM VideoGenres WHERE MediaInfoId = @MediaInfoId";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder()
					.AddInt("@MediaInfoId", mediaInfoId)
					.Build();

			db.UpdateOrDelete(sql, parameters);
		}
		public void Delete(VideoGenresEntity entity)
		{

			string sql = @"DELETE FROM VideoGenres WHERE MediaInfoId = @MediaInfoId";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder()
					.AddInt("@MediaInfoId", entity.MediaInfoId)
					.Build();

			db.UpdateOrDelete(sql, parameters);
		}
		public void Create(List<VideoGenresEntity> entities)
		{
			string sql = @"INSERT INTO VideoGenres (MediaInfoId, GenreId) VALUES (@MediaInfoId,@GenreId);";

			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				conn.Execute(sql, entities);
			}
		}

		public List<VideoGenresEntity> GetAllVideoGenres()
		{
			List<VideoGenresEntity> genres = new List<VideoGenresEntity>();

			string sql = "SELECT * FROM VideoGenres";
			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				return conn.Query<VideoGenresEntity>(sql).ToList();

			}
		}
		
		public List<VideoGenresDTO> GetVideoGenresDTOs()
		{
			string sql = @"SELECT VG.MediaInfoId,Genres.Id AS GenreId,Genres.Name AS Name FROM VideoGenres AS VG
							INNER JOIN Genres ON VG.GenreId = GenreId
							WHERE VG.GenreId = Genres.Id";

			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				return conn.Query<VideoGenresDTO>(sql).ToList();

			}
		}
	}
}
