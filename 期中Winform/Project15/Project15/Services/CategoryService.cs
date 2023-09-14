using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Services
{
	public class CategoryService
	{
		public List<CategoryDTO> GetMediaCategory()
		{
			List<CategoryDTO> dtos = new List<CategoryDTO>();
			var repo = new CategoryRepository();
			var result = repo.GetMediaCategory();

			foreach (var item in result)
			{
				CategoryDTO dto = new CategoryDTO()
				{
					Id = item.Id,
					MediaInfoId = item.MediaInfoId,
					CategoryId = item.CategoryId,
					CategoryName = item.CategoryName,
				};
				dtos.Add(dto);
			}

			return dtos;
		}
	}
}
