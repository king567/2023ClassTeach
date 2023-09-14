using Project15.Models.DTOs;
using Project15.Models.Entities;
using Project15.Models.VMs;
using Project15.Repositories;
using Project15.Services;
using Project15.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project15.Services.MediaInfoService;

namespace Project15
{
	public partial class FormMediaInfo : Form
	{
		List<GetAllVM> mediaInfoVMs = null;
		public FormMediaInfo()
		{
			InitializeComponent();
			this.Load += FormMediaInfo_Load;
			this.buttonAddNew.Click += ButtonAddNew_Click;
		}
		private void ButtonAddNew_Click(object sender, EventArgs e)
		{
			var frm = new FormNews();
			frm.Owner = this;
			frm.ShowDialog();
		}
		private void FormMediaInfo_Load(object sender, EventArgs e)
		{
			BindData();
		}
		private void buttonSearch_Click(object sender, EventArgs e)
		{
			BindCriteriaData();
		}
		private void buttonReloadAll_Click(object sender, EventArgs e)
		{
			BindMediaInfos();
		}
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			GetAllVM getAllVM = mediaInfoVMs[e.RowIndex];
			int id = getAllVM.Id;
			var frm = new FormUpdate(id);
			frm.Owner = this;
			frm.ShowDialog();
		}
		public void BindData()
		{
			BindControlData bindControlData = new BindControlData();
			bindControlData.ComboBoxCategory(comboBoxCategory);
			bindControlData.ComboBoxGenres(comboBoxGenres);
			bindControlData.ComboBoxOTTs(comboBoxOTT);

			BindMediaInfos();
		}
		private void BindMediaInfos()
		{
			MediaInfoService mediaInfoService = new MediaInfoService();

			mediaInfoVMs = mediaInfoService.GetAll2ViewModel();

			dataGridView1.DataSource = mediaInfoVMs;
		}
		private void BindCriteriaData()
		{
			List<GetAllVM> vms = new List<GetAllVM>();

			var repo = new MediaInfoRepository();

			var criteria = new MediaInfoSearchCriteriaBuilder()
				.WithCategory(comboBoxCategory.SelectedItem as CategoryEntity)
				.WithTitle(textBoxTitle.Text)
				.WithGenre(comboBoxGenres.SelectedItem as GenresEntity)
				.WithOTT(comboBoxOTT.SelectedItem as OttEntity)
				.WithDateRange(dateTimePickerDateOfStart.Text, dateTimePickerDateOfEnd.Text)
				.Build();

			MediaInfoService mediaInfoService = new MediaInfoService();

			var dtos = mediaInfoService.SearchCriteria(criteria);

			vms = mediaInfoService.Criteria2ViewModel(dtos);

			dataGridView1.DataSource = vms;

			mediaInfoVMs = vms;
		}
	}
}
