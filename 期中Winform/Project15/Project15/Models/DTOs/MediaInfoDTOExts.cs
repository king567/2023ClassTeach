using Project15.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.DTOs
{
	public static class MediaInfoDTOExts
	{
		public static MediaInfoListVM ToViewModel(this MediaInfoListDTO dto)
		{
			return new MediaInfoListVM
			{
				Id = dto.Id,
				CategoryId = dto.CategoryId,
				OTT = dto.OTT,
				OverView = dto.OverView,
				Genre = dto.Genre,
				Title = dto.Title,
				ReleaseDate = dto.ReleaseDate,
				Category = dto.Categories,

			};
		}
	}
}
