using Dapper;
using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Project15.Repositories
{
	public class OttRepository
	{
		public List<VideoOttTypesEntity> Get(VideoOttTypesEntity entity)
		{
			List<VideoOttTypesEntity> Otts = new List<VideoOttTypesEntity>();

			string sql = @"SELECT Id,MediaInfoId,OttTypeId FROM VideoOttTypes WHERE MediaInfoId = @Id";

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
					VideoOttTypesEntity item = new VideoOttTypesEntity()
					{
						Id = reader.GetInt("Id"),
						MediaInfoId = reader.GetInt("MediaInfoId"),
						OttTypeId = reader.GetInt("OttTypeId")
					};
					Otts.Add(item);
				}
				return Otts;
			}

		}
		/// <summary>
		/// test
		/// </summary>
		/// <returns></returns>
		public List<OttEntity> GetAll()
		{
			List<OttEntity> otts = new List<OttEntity>();
			string sql = @"SELECT * FROM OttTypes";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder().Build();
			using (var conn = db.GetConnection("default"))
			{
				conn.Open();

				var command = new SqlCommand(sql, conn);

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					OttEntity item = new OttEntity()
					{
						Id = reader.GetInt("Id"),
						Name = reader.GetString("Name")
					};
					otts.Add(item);
				}
				return otts;
			}
		}

		public void Update(List<VideoOttTypesEntity> entities)
		{
			//VideoOttTypesEntity videoOttTypesEntity = new VideoOttTypesEntity() { MediaInfoId = entities.First().MediaInfoId };

			//var ottRepo = new OttRepository();

			//this.Delete(videoOttTypesEntity);

			//this.Delete(entities);

			string sql = @"INSERT INTO VideoOttTypes (MediaInfoId, OttTypeId) VALUES (@MediaInfoId,@OttTypeId);";

			var db = new SqlDb();

			foreach (var entity in entities)
			{
				SqlParameter[] parameters = new SqlParameterBuilder()
					.AddInt("@MediaInfoId", entity.MediaInfoId)
					.AddInt("@OttTypeId", entity.OttTypeId)
					.Build();

				db.UpdateOrDelete(sql, parameters);
			}
		}
		//public virtual void Delete(List<VideoOttTypesEntity> entities)
		//{
		//	int mediaInfoId = entities.First().MediaInfoId;

		//	string sql = @"DELETE FROM VideoOttTypes WHERE MediaInfoId = @MediaInfoId";

		//	var db = new SqlDb();

		//	SqlParameter[] parameters = new SqlParameterBuilder()
		//			.AddInt("@MediaInfoId", mediaInfoId)
		//			.Build();

		//	db.UpdateOrDelete(sql, parameters);
		//}

		public void Delete(VideoOttTypesEntity entity)
		{
			string sql = @"DELETE FROM VideoOttTypes WHERE MediaInfoId = @MediaInfoId";

			var db = new SqlDb();

			SqlParameter[] parameters = new SqlParameterBuilder()
					.AddInt("@MediaInfoId", entity.MediaInfoId)
					.Build();

			db.UpdateOrDelete(sql, parameters);
		}

		public void Create(List<VideoOttTypesEntity> entities)
		{
			string sql = @"INSERT INTO VideoOttTypes (MediaInfoId, OttTypeId) VALUES (@MediaInfoId,@OttTypeId);";

			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				conn.Execute(sql, entities);
			}
		}

		public List<VideoOttTypesEntity> GetAllVideoOtts()
		{
			List<VideoOttTypesEntity> genres = new List<VideoOttTypesEntity>();

			string sql = "SELECT * FROM VideoOttTypes";
			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				return conn.Query<VideoOttTypesEntity>(sql).ToList();
			}
		}

		public List<VideoOttTypesDTO> GetVideoOttDTOs()
		{
			string sql = @"SELECT VOT.MediaInfoId,OttTypes.Id AS OTTtypesId,OttTypes.Name AS Name FROM VideoOttTypes AS VOT
			INNER JOIN OttTypes ON VOT.OttTypeId = OttTypes.Id";

			var db = new SqlDb();

			using (var conn = db.GetConnection("default"))
			{
				return conn.Query<VideoOttTypesDTO>(sql).ToList();
			}
		}
	}
}
