using Project15.Models.Entities;
using Project15.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project15.Utilities
{
	public class BindControlData
	{
		public void ComboBoxCategory(ComboBox comboBox)
		{
			List<CategoryEntity> categories = new CategoryRepository().GetAll();
			categories.Insert(0, new CategoryEntity() { Id = 0, Name = "" });
			comboBox.DataSource = categories;
			comboBox.DisplayMember = "Name";
		}

		public void ComboBoxGenres(ComboBox comboBox)
		{
			List<GenresEntity> genres = new GenresRepository().GetAll();
			genres.Insert(0, new GenresEntity() { Id = 0, Name = "" });
			comboBox.DataSource = genres;
			comboBox.DisplayMember = "Name";
		}
		public void ComboBoxOTTs(ComboBox comboBox)
		{
			List<OttEntity> otts = new OttRepository().GetAll();
			otts.Insert(0, new OttEntity() { Id = 0, Name = "" });
			comboBox.DataSource = otts;
			comboBox.DisplayMember = "Name";
		}

	}
}
