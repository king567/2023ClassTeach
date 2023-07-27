using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			UpdatePanel();
		}

		private void BtnInsert_Click(object sender, EventArgs e)
		{
			Scores score = GetClassInput();
			SqlTool sqlTool = new SqlTool();
			List<Scores> scores = sqlTool.GetStudentScores(sqlTool.InsertQuery(score));
			DataGridOutput.DataSource = scores;
			UpdatePanel();
		}

		private void BtnSearch_Click(object sender, EventArgs e)
		{
			SqlTool sqlTool = new SqlTool();
			List<Scores> scores = sqlTool.GetStudentScores(sqlTool.SearchQuery());
			DataGridOutput.DataSource = scores;
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			SqlTool sqlTool = new SqlTool();
			List<Scores> scores = sqlTool.GetStudentScores(sqlTool.DeleteQuery());
			DataGridOutput.DataSource = scores;
		}

		private void BtnUpdate_Click(object sender, EventArgs e)
		{
			SqlTool sqlTool = new SqlTool();
			List<Scores> scores = sqlTool.GetStudentScores(sqlTool.UpdateQuery());
			DataGridOutput.DataSource = scores;
		}

		#region Function
		public void UpdatePanel()
		{
			SqlTool sqlTool = new SqlTool();
			List<Scores> scores = sqlTool.GetStudentScores(sqlTool.GETAllQuery());
			DataGridOutput.DataSource = scores;
		}
		public string GetTxtboxText(TextBox textBox)
		{
			if (!string.IsNullOrWhiteSpace(textBox.Text))
			{
				return textBox.Text;
			}
			
			return string.Empty;
		}


		public int GetInt(string input)
		{
			if (int.TryParse(input, out int result))
			{
				return result;
			}
			
			return 0;
		}

		public Scores GetClassInput()
		{
			Scores score = new Scores();
			score.Math = GetInt(GetTxtboxText(TxtMath));
			score.Chinese = GetInt(GetTxtboxText(TxtChinese));
			score.English = GetInt(GetTxtboxText(TxtEnglish));
			score.Name = GetTxtboxText(TxtName);
			return score;
		}

		#endregion
	}
}
