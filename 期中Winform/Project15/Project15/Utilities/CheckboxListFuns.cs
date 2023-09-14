using Project15.Models.Entities;
using Project15.Models.VMs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project15.Utilities
{
	public class CheckboxListFuns
	{
		public List<int> GetSelectedIDsFromCheckboxList<T>(CheckedListBox checkboxList, List<T> itemSource, Func<T, int> idSelector)
		{
			List<int> selectedIDs = new List<int>();

			for (int i = 0; i < checkboxList.CheckedIndices.Count; i++)
			{
				int selectedIndex = checkboxList.CheckedIndices[i];
				var selectedItem = idSelector(itemSource[selectedIndex]);
				selectedIDs.Add(selectedItem);
			}

			return selectedIDs;
		}

		public class Generator
		{
			/// <summary>
			/// 將全部的影片類別資料轉成 GenreCheckListBoxVM，並將輸入的影片類別 IsSelected 設定為勾選
			/// </summary>
			/// <param name="videoGenresIds">該影片的類別</param>
			/// <param name="genres">全部的影片類別</param>
			/// <returns></returns>
			public List<CheckListBoxVM> GenresConvert2VM(List<VideoGenresEntity> videoGenresIds, List<GenresEntity> genres)
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
			public List<CheckListBoxVM> GenresConvert2VM(List<GenresEntity> genres)
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
				return vms;
			}
			public List<CheckListBoxVM> OTTConvert2VM(List<VideoOttTypesEntity> OttTypesIds, List<OttEntity> otts)
			{
				var vms = new List<CheckListBoxVM>();

				foreach (var item in otts)
				{
					vms.Add(new CheckListBoxVM()
					{
						ID = item.Id,
						Name = item.Name,
						IsSelected = false
					});
				}

				foreach (var item in OttTypesIds)
				{
					var modifyVms = vms.Where(c => c.ID == item.OttTypeId).FirstOrDefault();
					modifyVms.IsSelected = true;
				}
				return vms;
			}
			public List<CheckListBoxVM> OTTConvert2VM(List<OttEntity> otts)
			{
				var vms = new List<CheckListBoxVM>();

				foreach (var item in otts)
				{
					vms.Add(new CheckListBoxVM()
					{
						ID = item.Id,
						Name = item.Name,
						IsSelected = false
					});
				}
				return vms;
			}
			public List<CheckListBoxVM> ConvertEntitiesToVM<T>(List<T> entities, Func<T, CheckListBoxVM> convertFunc)
			{
				var vms = new List<CheckListBoxVM>();

				foreach (var item in entities)
				{
					vms.Add(convertFunc(item));
				}

				return vms;
			}

			//List<OttEntity> otts = GetOTTEntities(); // Replace with your data retrieval logic
			//List<GenresEntity> genres = GetGenresEntities(); // Replace with your data retrieval logic

			//List<CheckListBoxVM> ottVMs = ConvertEntitiesToVM(otts, item => new CheckListBoxVM
			//{
			//	ID = item.Id,
			//	Name = item.Name,
			//	IsSelected = false
			//});

			//List<CheckListBoxVM> genresVMs = ConvertEntitiesToVM(genres, item => new CheckListBoxVM
			//{
			//	ID = item.Id,
			//	Name = item.Name,
			//	IsSelected = false
			//});


			public void Build(CheckedListBox checkedListBox, List<CheckListBoxVM> vm)
			{
				foreach (var item in vm)
				{
					checkedListBox.Items.Add(item.Name, item.IsSelected);
				}
			}
		}
	}
}
