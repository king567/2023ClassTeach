using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Models.VMs;
using Project15.Repositories;
using Project15.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Services
{
	public class MediaInfoService
	{
		public MediaInfoListDTO Get(MediaInfoEntity entity) 
		{
			var repo = new MediaInfoRepository();
			var result = repo.Get(entity);
			MediaInfoListDTO dto = new MediaInfoListDTO()
			{
				Id = result.Id,
				CategoryId = result.CategoryId,
				Title = result.Title,
				OverView = result.OverView,
				ReleaseDate = result.ReleaseDate,
			};
			return dto;
		}
		public List<MediaInfoListDTO> GetAll()
		{
			var repo = new MediaInfoRepository();

			var result = repo.GetAll();

			List<MediaInfoListDTO> dTOs = new List<MediaInfoListDTO>();

            foreach (var item in result)
            {
				MediaInfoListDTO dto = new MediaInfoListDTO()
				{
					Id = item.Id,
					CategoryId = item.CategoryId,
					Title = item.Title,
					OverView = item.OverView,
					ReleaseDate = item.ReleaseDate
				};
				dTOs.Add(dto);
			}

			return dTOs;
		}
		public List<MediaInfoListDTO> SearchCriteria(SearchCriteriaEntity entity)
		{
			var repo = new MediaInfoRepository();
			List<MediaInfoListDTO> dtos = new List<MediaInfoListDTO>();
			var result = repo.Search(entity);
			foreach (var item in result)
			{
				MediaInfoListDTO dto = new MediaInfoListDTO()
				{
					Id= item.Id,
					CategoryId = item.CategoryId,
					Title = item.Title,
					OverView= item.OverView,
					ReleaseDate = item.ReleaseDate,
					OTT = item.OTT,
					Genre = item.Genre,
					Categories = item.Categories,
				};
				dtos.Add(dto);
			}

			return dtos;
		}
		public List<GetAllVM> Criteria2ViewModel(List<MediaInfoListDTO> dtos)
		{
			List<GetAllVM> vms = new List<GetAllVM>();

			List<int> groupedMediaId = dtos.GroupBy(media => media.Id)
				.Select(group => group.Key)
				.ToList();

			if (dtos == null)
			{
				return null;
			}

			foreach (int id in groupedMediaId)
			{
				var MediaInfo = dtos.FirstOrDefault(media => media.Id == id);

				List<string> genresString = dtos
					.Where(media => media.Id == id)
					.Select(media => media.Genre)
					.Distinct()
					.ToList();

				List<string> ottString = dtos
					.Where(media => media.Id == id)
					.Select(media => media.OTT)
					.Distinct()
					.ToList();

				GetAllVM vm = new GetAllVM()
				{
					Id = id,
					CategoryId = MediaInfo.CategoryId,
					Category = MediaInfo.Categories,
					Title = MediaInfo.Title,
					OverView = MediaInfo.OverView,
					ReleaseDate = MediaInfo.ReleaseDate,
					Genres = string.Join("\r\n", genresString),
					OTTs = string.Join("\r\n", ottString)
				};

				vms.Add(vm);
			}

			return vms;
		}
		public List<GetAllVM> GetAll2ViewModel()
		{
			var mediaRepo = new MediaInfoRepository();
			var videoGenreRepo = new GenresRepository();
			var ottRepo = new OttRepository();
			var categoryRepo = new CategoryRepository();

			var medias = mediaRepo.GetAll();
			var videoGenres = videoGenreRepo.GetVideoGenresDTOs();
			var videoOtts = ottRepo.GetVideoOttDTOs();

			var categoryService = new CategoryService();

			var categorys = categoryService.GetMediaCategory();

			//var categorys = categoryRepo.GetMediaCategory();

			var getAlls = medias.Select(dto => new GetAllVM
			{
				Id = dto.Id,
				CategoryId = dto.CategoryId,
				Title = dto.Title,
				OverView = dto.OverView,
				ReleaseDate = dto.ReleaseDate
			}).ToList();

			foreach (var vm in getAlls)
			{
				var matchVideo = categorys.FirstOrDefault(x => x.MediaInfoId == vm.Id);
				vm.Category = matchVideo?.CategoryName;

				var genresVMs = videoGenres.Where(genre => genre.MediaInfoId == vm.Id).ToList();
				vm.Genres = string.Join("\r\n", genresVMs.Select(item => item.Name));

				var ottsVMs = videoOtts.Where(otts => otts.MediaInfoId == vm.Id).ToList();
				vm.OTTs = string.Join("\r\n", ottsVMs.Select(item => item.Name));
			}

			return getAlls;
		}
		public class MediaInfoSearchCriteriaBuilder
		{
			private readonly SearchCriteriaEntity _criteria;

			public MediaInfoSearchCriteriaBuilder()
			{
				_criteria = new SearchCriteriaEntity();
			}

			public MediaInfoSearchCriteriaBuilder WithCategory(CategoryEntity category)
			{
				if (category != null && category.Id > 0)
				{
					_criteria.CategoryId = category.Id;
				}
				return this;
			}

			public MediaInfoSearchCriteriaBuilder WithTitle(string title)
			{
				_criteria.Title = title;
				return this;
			}

			public MediaInfoSearchCriteriaBuilder WithGenre(GenresEntity genres)
			{
				if (genres != null && genres.Id > 0)
				{
					_criteria.GenreId = genres.Id;
				}
				return this;
			}

			public MediaInfoSearchCriteriaBuilder WithOTT(OttEntity otts)
			{
				if (otts != null && otts.Id > 0)
				{
					_criteria.OttId = otts.Id;
				}
				return this;
			}

			public MediaInfoSearchCriteriaBuilder WithDateRange(string start, string end)
			{
				if (DateTime.TryParse(start, out DateTime startDate))
				{
					_criteria.DateTimeLow = startDate;
				}

				if (DateTime.TryParse(end, out DateTime endDate))
				{
					_criteria.DateTimeHeight = endDate;
				}

				return this;
			}

			public SearchCriteriaEntity Build()
			{
				return _criteria;
			}
		}
	}
}
