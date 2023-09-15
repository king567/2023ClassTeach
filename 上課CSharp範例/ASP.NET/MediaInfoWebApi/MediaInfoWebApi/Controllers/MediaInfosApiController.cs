using Dapper;
using MediaInfoWebApi.Models.DTOs;
using MediaInfoWebApi.Models.EFModels;
using MediaInfoWebApi.Models.Entities;
using MediaInfoWebApi.Models.Repositories;
using MediaInfoWebApi.Models.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;

namespace MediaInfoWebApi.Controllers
{
    public class MediaInfosApiController : ApiController
    {

		// dapper 測試 目前失敗
		//		public IHttpActionResult GetAll()
		//		{
		//			var query = @"
		//SELECT
		//    m.Id AS Id,
		//    m.Title AS Title,
		//    m.OverView AS OverView,
		//    m.ReleaseDate AS ReleaseDate,
		//    m.Adult AS Adult,
		//    m.Popularity AS Popularity,
		//    m.OriginalLanguage AS OriginalLanguage,
		//    m.OriginalTitle AS OriginalTitle,
		//    m.Video AS Video,
		//    m.BackdropPath AS BackdropPath,
		//    m.PosterPath AS PosterPath,
		//    m.CategoryId AS CategoryId,
		//    g.GenreId AS GenreId,
		//    o.OttTypeId AS OttTypeId
		//FROM MediaInfos m
		//LEFT JOIN MediaInfos_Genres_Rel g ON m.Id = g.MediaInfoId
		//LEFT JOIN MediaInfos_OttTypes_Rel o ON m.Id = o.MediaInfoId

		//        ";

		//			var db = new SqlDb();

		//			using (var conn = db.GetConnection("default"))
		//			{
		//				var result = conn.Query<MediaInfosRelDTO>(query);

		//				return Ok(result);
		//			}
		//		}

		// GET: api/MediaInfosApi
		// EF 測試 成功
		public IHttpActionResult GetAll()
		{
			var db = new AppDbContext();

			var mediaInfos= db.MediaInfos
				.Include(m => m.Category)
				.Include(m => m.MediaInfos_Genres_Rel)
				.Include(m => m.MediaInfos_OttTypes_Rel)
				.Select(m => new MediaInfosRelDTO
				{
					Id = m.Id,
					Title = m.Title,
					OverView = m.OverView,
					ReleaseDate = (DateTime)m.ReleaseDate,
					Adult = (bool)m.Adult,
					Popularity = (double)m.Popularity,
					OriginalLanguage = m.OriginalLanguage,
					OriginalTitle = m.OriginalTitle,
					Video = (bool)m.Video,
					BackdropPath = m.BackdropPath,
					PosterPath = m.PosterPath,
					CategoryId = m.CategoryId,
					GenreId = m.MediaInfos_Genres_Rel.Select(rel => rel.GenreId).ToList(),
					OttTypeId = m.MediaInfos_OttTypes_Rel.Select(rel => rel.OttTypeId).ToList()
				})
				.ToList();

			return Ok(mediaInfos);
		}


		//public List<MediaInfoEntity> Get()
		//{
		//    var repo = new MediaInfoRepository();
		//    var list = repo.GetAll();
		//    return repo.GetAll();
		//    //return new string[] { "value1", "value2" };
		//}

		// GET: api/MediaInfosApi/5
		public string Get(int id)
        {
            return "value";
        }

        // POST: api/MediaInfosApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MediaInfosApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MediaInfosApi/5
        public void Delete(int id)
        {
        }
    }
}
