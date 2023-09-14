using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Models.VMs;
using Project15.Repositories;
using Project15.Services;
using Project15.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project15
{
	public partial class FormNews : Form
	{
		List<GenresEntity> genres = null;

		List<OttEntity> otts = null;
		public FormNews()
		{
			InitializeComponent();
			this.Load += FormNews_Load;
			buttonAddNew.Click += ButtonAddNew_Click;
		}

		private void ButtonAddNew_Click(object sender, EventArgs e)
		{
			SaveData();

			BindData();
		}

		private void FormNews_Load(object sender, EventArgs e)
		{
			BindData();
			BindControlData();
		}

		private void BindData()
		{
			// DataGridView MediaInfo

			MediaInfoService mediaInfoService = new MediaInfoService();

			List<GetAllVM> mediaInfoVMs = mediaInfoService.GetAll2ViewModel();

			dataGridViewMediaInfos.DataSource = mediaInfoVMs;

			// DataGridView Genres

			var repoGenre = new GenresRepository();

			dataGridViewGenres.DataSource = repoGenre.GetAllVideoGenres();

			// DataGridView OTTs

			var repoOtt = new OttRepository();

			dataGridViewOtts.DataSource = repoOtt.GetAllVideoOtts();
		}
		public void BindControlData()
		{
			// 產生 Category List
			BindControlData bindControlData = new BindControlData();

			bindControlData.ComboBoxCategory(comboBoxCategory);

			// 產生 checklistbox List

			CheckboxListFuns.Generator checkboxListGenerator = new CheckboxListFuns.Generator();

			genres = new GenresRepository().GetAll();

			var genreVMs = checkboxListGenerator.GenresConvert2VM(genres);

			checkboxListGenerator.Build(checkedListBoxGenres, genreVMs);

			otts = new OttRepository().GetAll();

			var ottVms = checkboxListGenerator.OTTConvert2VM(otts);

			checkboxListGenerator.Build(checkedListBoxOTTs, ottVms);
		}
		private void SaveData()
		{
			var mediaRepo = new MediaInfoRepository();

			MediaInfoEntity mediaInfoEntity = new MediaInfoEntity()
			{
				Title = textBoxTitle.Text,
				ReleaseDate = dateTimePickerRelease.Value,
				OverView = textBoxOverview.Text,
			};

			CategoryEntity category = comboBoxCategory.SelectedItem as CategoryEntity;

			if (category != null && category.Id > 0)
			{
				mediaInfoEntity.CategoryId = category.Id;
			}

			//GET NEW ID When Insert Data

			int newId = mediaRepo.Create(mediaInfoEntity);

			// 獲取CheckListBox 選取的ID值

			CheckboxListFuns checkboxListFuns = new CheckboxListFuns();

			////////// GenresSelectedIDs 從 CheckboxList 取得已勾選的 Genres Id

			List<int> GenresSelectedIDs = checkboxListFuns
				.GetSelectedIDsFromCheckboxList
				(checkedListBoxGenres, genres, entity => entity.Id);

			////////// 建立 MedioInfo & Genres 的關聯 Entities

			List<VideoGenresEntity> videoGenresEntities = new List<VideoGenresEntity>();

			foreach (var item in GenresSelectedIDs)
			{
				VideoGenresEntity videoGenresEntity = new VideoGenresEntity();

				videoGenresEntity.GenreId = item;
				videoGenresEntity.MediaInfoId = newId;

				videoGenresEntities.Add(videoGenresEntity);
			}

			var repo = new GenresRepository();

			repo.Create(videoGenresEntities);

			////////// OttsSelectedIDs 從 CheckboxList 取得已勾選的 Otts Id
			///
			List<int> OttsSelectedIDs = checkboxListFuns
				.GetSelectedIDsFromCheckboxList
				(checkedListBoxOTTs, otts, entity => entity.Id);


			List<VideoOttTypesEntity> videoOttTypesEntities = new List<VideoOttTypesEntity>();

			foreach (var item in OttsSelectedIDs)
			{
				VideoOttTypesEntity ottTypesEntity = new VideoOttTypesEntity();

				ottTypesEntity.OttTypeId = item;
				ottTypesEntity.MediaInfoId = newId;

				videoOttTypesEntities.Add(ottTypesEntity);
			}

			//將 videoOttTypesEntities 傳入 GenresRepository.Create()

			var repoOtt = new OttRepository();

			repoOtt.Create(videoOttTypesEntities);

			
		}

		private List<MediaInfoListVM> Convert2ViewModel(List<MediaInfoListDTO> dtos)
		{
			var medias = new List<MediaInfoListVM>();
			foreach (var dto in dtos)
			{
				medias.Add(dto.ToViewModel());
			}
			return medias;
		}

		private void FormNews_FormClosed(object sender, FormClosedEventArgs e)
		{
			(this.Owner as FormMediaInfo).BindData();

			this.DialogResult = DialogResult.OK;
		}
	}
}
