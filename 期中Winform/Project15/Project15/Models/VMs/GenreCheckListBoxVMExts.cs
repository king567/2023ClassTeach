using Project15.Models.DTOs;
using Project15.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.VMs
{
	public static class GenreCheckListBoxVMExts
	{
		/// <summary>
		/// 將全部的影片類別資料轉成 GenreCheckListBoxVM，並將輸入的影片類別 IsSelected 設定為勾選
		/// </summary>
		/// <param name="videoGenresIds">該影片的類別</param>
		/// <param name="genres">全部的影片類別</param>
		/// <returns></returns>
		public static List<CheckListBoxVM> GenreToViewModel(this List<VideoGenresEntity> videoGenresIds, List<GenresEntity> genres)
		{
			var vms = new List<CheckListBoxVM>();

			foreach (var item in genres)
			{
				vms.Add(new CheckListBoxVM()
				{
					ID = item.Id, 
					Name = item.Name,
					IsSelected = false
				});
			}

			foreach (var item in videoGenresIds)
			{
				var modifyVms = vms.Where(c => c.ID == item.GenreId).FirstOrDefault();
				modifyVms.IsSelected = true;
			}
			
			return vms;
		}
	}
}