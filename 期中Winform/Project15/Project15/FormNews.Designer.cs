namespace Project15
{
	partial class FormNews
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonAddNew = new System.Windows.Forms.Button();
			this.checkedListBoxOTTs = new System.Windows.Forms.CheckedListBox();
			this.checkedListBoxGenres = new System.Windows.Forms.CheckedListBox();
			this.comboBoxCategory = new System.Windows.Forms.ComboBox();
			this.textBoxOverview = new System.Windows.Forms.TextBox();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridViewMediaInfos = new System.Windows.Forms.DataGridView();
			this.dataGridViewGenres = new System.Windows.Forms.DataGridView();
			this.dataGridViewOtts = new System.Windows.Forms.DataGridView();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dateTimePickerRelease = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMediaInfos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenres)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtts)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonAddNew
			// 
			this.buttonAddNew.Location = new System.Drawing.Point(443, 441);
			this.buttonAddNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonAddNew.Name = "buttonAddNew";
			this.buttonAddNew.Size = new System.Drawing.Size(64, 27);
			this.buttonAddNew.TabIndex = 6;
			this.buttonAddNew.Text = "Add New";
			this.buttonAddNew.UseVisualStyleBackColor = true;
			// 
			// checkedListBoxOTTs
			// 
			this.checkedListBoxOTTs.FormattingEnabled = true;
			this.checkedListBoxOTTs.Location = new System.Drawing.Point(344, 41);
			this.checkedListBoxOTTs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkedListBoxOTTs.Name = "checkedListBoxOTTs";
			this.checkedListBoxOTTs.Size = new System.Drawing.Size(166, 106);
			this.checkedListBoxOTTs.TabIndex = 2;
			// 
			// checkedListBoxGenres
			// 
			this.checkedListBoxGenres.FormattingEnabled = true;
			this.checkedListBoxGenres.Location = new System.Drawing.Point(105, 39);
			this.checkedListBoxGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkedListBoxGenres.Name = "checkedListBoxGenres";
			this.checkedListBoxGenres.Size = new System.Drawing.Size(166, 106);
			this.checkedListBoxGenres.TabIndex = 1;
			// 
			// comboBoxCategory
			// 
			this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCategory.FormattingEnabled = true;
			this.comboBoxCategory.Location = new System.Drawing.Point(105, 185);
			this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxCategory.Name = "comboBoxCategory";
			this.comboBoxCategory.Size = new System.Drawing.Size(149, 20);
			this.comboBoxCategory.TabIndex = 3;
			// 
			// textBoxOverview
			// 
			this.textBoxOverview.Location = new System.Drawing.Point(105, 262);
			this.textBoxOverview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxOverview.Multiline = true;
			this.textBoxOverview.Name = "textBoxOverview";
			this.textBoxOverview.Size = new System.Drawing.Size(405, 171);
			this.textBoxOverview.TabIndex = 5;
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(105, 7);
			this.textBoxTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(405, 22);
			this.textBoxTitle.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 224);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 12);
			this.label5.TabIndex = 30;
			this.label5.Text = "ReleaseDate:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 185);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 12);
			this.label4.TabIndex = 31;
			this.label4.Text = "Category:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(298, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 12);
			this.label3.TabIndex = 32;
			this.label3.Text = "OTT:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 262);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 34;
			this.label6.Text = "Overview:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 12);
			this.label2.TabIndex = 33;
			this.label2.Text = "Genres:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 35;
			this.label1.Text = "Title:";
			// 
			// dataGridViewMediaInfos
			// 
			this.dataGridViewMediaInfos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewMediaInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMediaInfos.Location = new System.Drawing.Point(553, 31);
			this.dataGridViewMediaInfos.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewMediaInfos.Name = "dataGridViewMediaInfos";
			this.dataGridViewMediaInfos.RowHeadersWidth = 62;
			this.dataGridViewMediaInfos.RowTemplate.Height = 33;
			this.dataGridViewMediaInfos.Size = new System.Drawing.Size(686, 184);
			this.dataGridViewMediaInfos.TabIndex = 7;
			// 
			// dataGridViewGenres
			// 
			this.dataGridViewGenres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGenres.Location = new System.Drawing.Point(553, 253);
			this.dataGridViewGenres.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewGenres.Name = "dataGridViewGenres";
			this.dataGridViewGenres.RowHeadersWidth = 62;
			this.dataGridViewGenres.RowTemplate.Height = 33;
			this.dataGridViewGenres.Size = new System.Drawing.Size(333, 199);
			this.dataGridViewGenres.TabIndex = 8;
			// 
			// dataGridViewOtts
			// 
			this.dataGridViewOtts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewOtts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewOtts.Location = new System.Drawing.Point(910, 253);
			this.dataGridViewOtts.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewOtts.Name = "dataGridViewOtts";
			this.dataGridViewOtts.RowHeadersWidth = 62;
			this.dataGridViewOtts.RowTemplate.Height = 33;
			this.dataGridViewOtts.Size = new System.Drawing.Size(329, 199);
			this.dataGridViewOtts.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(551, 11);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 12);
			this.label7.TabIndex = 43;
			this.label7.Text = "MediaInfos:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(551, 224);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(151, 12);
			this.label8.TabIndex = 43;
			this.label8.Text = "MediaInfo 一對多關聯 Genre:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(908, 226);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(118, 12);
			this.label9.TabIndex = 43;
			this.label9.Text = "MediaInfo 一對多 OTT";
			// 
			// dateTimePickerRelease
			// 
			this.dateTimePickerRelease.Location = new System.Drawing.Point(105, 224);
			this.dateTimePickerRelease.Name = "dateTimePickerRelease";
			this.dateTimePickerRelease.Size = new System.Drawing.Size(200, 22);
			this.dateTimePickerRelease.TabIndex = 44;
			// 
			// FormNews
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1260, 479);
			this.Controls.Add(this.dateTimePickerRelease);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dataGridViewOtts);
			this.Controls.Add(this.dataGridViewGenres);
			this.Controls.Add(this.dataGridViewMediaInfos);
			this.Controls.Add(this.checkedListBoxOTTs);
			this.Controls.Add(this.checkedListBoxGenres);
			this.Controls.Add(this.comboBoxCategory);
			this.Controls.Add(this.textBoxOverview);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonAddNew);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.Name = "FormNews";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "新增資料";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNews_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMediaInfos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenres)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtts)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonAddNew;
		private System.Windows.Forms.CheckedListBox checkedListBoxOTTs;
		private System.Windows.Forms.CheckedListBox checkedListBoxGenres;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.TextBox textBoxOverview;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridViewMediaInfos;
		private System.Windows.Forms.DataGridView dataGridViewGenres;
		private System.Windows.Forms.DataGridView dataGridViewOtts;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dateTimePickerRelease;
	}
}