using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Models.VMs;
using Project15.Repositories;
using Project15.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project15
{
	public partial class FormUpdate : Form
	{
		private int _id;

		List<GenresEntity> genres = null;

		List<OttEntity> otts = null;

		List<VideoGenresEntity> videoGenres = null;

		List<VideoOttTypesEntity> videoOtts = null;
		public FormUpdate(int id)
		{
			this._id = id;
			InitializeComponent();
			this.Load += FormUpdate_Load;
			buttonSave.Click += ButtonSave_Click;
			buttonDelete.Click += ButtonDelete_Click;
			FormBorderStyle = FormBorderStyle.Fixed3D;
		}
		private void FormUpdate_Load(object sender, EventArgs e)
		{
			BindData();
		}
		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			DeleteData();

			(this.Owner as FormMediaInfo).BindData();

			this.DialogResult = DialogResult.OK;
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			SaveTextBoxAndComboBox();

			SaveCheckListBox();

			(this.Owner as FormMediaInfo).BindData();

			this.DialogResult = DialogResult.OK;
		}
		private void BindData()
		{
			MediaInfoEntity mediaInfoEntity = new MediaInfoEntity { Id = _id };

			var mediaInfo = new MediaInfoRepository().Get(mediaInfoEntity);

			textBoxTitle.Text = mediaInfo.Title;

			dateTimePickerReleaseDate.Value = mediaInfo.ReleaseDate;

			textBoxOverview.Text = mediaInfo.OverView;

			BindControlData bindControlData = new BindControlData();

			bindControlData.ComboBoxCategory(comboBoxCategory);

			this.comboBoxCategory.SelectedIndex = mediaInfo.CategoryId;

			BuildCheckListBoxVM();
		}
		private void SaveCheckListBox()
		{
			CheckboxListFuns checkboxListFuns = new CheckboxListFuns();

			////////// GenresSelectedIDs 從 CheckboxList 取得已勾選的 Genres Id

			List<int> GenresSelectedIDs = checkboxListFuns
				.GetSelectedIDsFromCheckboxList
				(checkedListBoxGenres, genres, entity => entity.Id);

			////////// 建立要修改 Genres 的 Entities

			List<VideoGenresEntity> videoGenresEntities = new List<VideoGenresEntity>();

			foreach (var item in GenresSelectedIDs)
			{
				VideoGenresEntity videoGenresEntity = new VideoGenresEntity();

				videoGenresEntity.GenreId = item;
				videoGenresEntity.MediaInfoId = _id;

				videoGenresEntities.Add(videoGenresEntity);
			}
			//將 videoGenresEntities 傳入 GenresRepository.Update()

			var repo = new GenresRepository();

			repo.Update(videoGenresEntities);

			List<int> OttsSelectedIDs = checkboxListFuns
				.GetSelectedIDsFromCheckboxList
				(checkedListBoxOTTs, otts, entity => entity.Id);


			List<VideoOttTypesEntity> videoOttTypesEntities = new List<VideoOttTypesEntity>();

			if(OttsSelectedIDs.Count == 0)
			{
				VideoOttTypesEntity videoOttTypesEntity = new VideoOttTypesEntity() { MediaInfoId = _id };
				var ottRepo = new OttRepository();
				ottRepo.Delete(videoOttTypesEntity);
			}
			else
			{
				VideoOttTypesEntity videoOttTypesEntity = new VideoOttTypesEntity() { MediaInfoId = _id };
				var ottRepo = new OttRepository();
				ottRepo.Delete(videoOttTypesEntity);

				foreach (var item in OttsSelectedIDs)
				{
					VideoOttTypesEntity ottTypesEntity = new VideoOttTypesEntity();

					ottTypesEntity.OttTypeId = item;
					ottTypesEntity.MediaInfoId = _id;

					videoOttTypesEntities.Add(ottTypesEntity);
				}
				//將 videoGenresEntities 傳入 GenresRepository.Update()

				var repoOtt = new OttRepository();

				repoOtt.Update(videoOttTypesEntities);
			}


		}
		private void SaveTextBoxAndComboBox()
		{
			MediaInfoEntity mediaInfoEntity = new MediaInfoEntity()
			{
				Id = _id,
				Title = textBoxTitle.Text,
				ReleaseDate = dateTimePickerReleaseDate.Value,
				OverView = textBoxOverview.Text,
			};

			CategoryEntity category = comboBoxCategory.SelectedItem as CategoryEntity;

			if (category != null && category.Id > 0)
			{
				mediaInfoEntity.CategoryId = category.Id;
			}

			var repo = new MediaInfoRepository();

			repo.Update(mediaInfoEntity);
		}
		private void DeleteData()
		{
			MediaInfoEntity mediaInfoEntity = new MediaInfoEntity() { Id = _id };
			VideoGenresEntity videoGenresEntity = new VideoGenresEntity() { MediaInfoId = _id };
			VideoOttTypesEntity videoOttTypesEntity = new VideoOttTypesEntity() { MediaInfoId = _id };

			var genreRepo = new GenresRepository();
			genreRepo.Delete(videoGenresEntity);

			var ottRepo = new OttRepository();
			ottRepo.Delete(videoOttTypesEntity);

			var mediaInfoRepo = new MediaInfoRepository();
			mediaInfoRepo.Delete(mediaInfoEntity);
		}
		private void BuildCheckListBoxVM()
		{
			List<CheckListBoxVM> genreVMs = null, ottVms = null;

			VideoOttTypesEntity videoottEntity = new VideoOttTypesEntity { Id = _id };

			VideoGenresEntity videoGenresEntity = new VideoGenresEntity { Id = _id };

			CheckboxListFuns.Generator checkboxListGenerator = new CheckboxListFuns.Generator();

			genres = new GenresRepository().GetAll();

			videoGenres = new GenresRepository().Get(videoGenresEntity);

			otts = new OttRepository().GetAll();

			videoOtts = new OttRepository().Get(videoottEntity);

			genreVMs = checkboxListGenerator.GenresConvert2VM(videoGenres, genres);

			checkboxListGenerator.Build(checkedListBoxGenres, genreVMs);

			ottVms = checkboxListGenerator.OTTConvert2VM(videoOtts, otts);

			checkboxListGenerator.Build(checkedListBoxOTTs, ottVms);
		}
	}
}
