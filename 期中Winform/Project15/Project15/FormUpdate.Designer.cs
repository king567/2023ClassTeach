namespace Project15
{
	partial class FormUpdate
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
			this.comboBoxCategory = new System.Windows.Forms.ComboBox();
			this.textBoxOverview = new System.Windows.Forms.TextBox();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.checkedListBoxGenres = new System.Windows.Forms.CheckedListBox();
			this.checkedListBoxOTTs = new System.Windows.Forms.CheckedListBox();
			this.dateTimePickerReleaseDate = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// comboBoxCategory
			// 
			this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCategory.FormattingEnabled = true;
			this.comboBoxCategory.Location = new System.Drawing.Point(110, 187);
			this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxCategory.Name = "comboBoxCategory";
			this.comboBoxCategory.Size = new System.Drawing.Size(149, 20);
			this.comboBoxCategory.TabIndex = 3;
			// 
			// textBoxOverview
			// 
			this.textBoxOverview.Location = new System.Drawing.Point(110, 264);
			this.textBoxOverview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxOverview.Multiline = true;
			this.textBoxOverview.Name = "textBoxOverview";
			this.textBoxOverview.Size = new System.Drawing.Size(405, 171);
			this.textBoxOverview.TabIndex = 5;
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(110, 9);
			this.textBoxTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(405, 22);
			this.textBoxTitle.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 226);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 12);
			this.label5.TabIndex = 15;
			this.label5.Text = "ReleaseDate:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 187);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 12);
			this.label4.TabIndex = 16;
			this.label4.Text = "Category:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(303, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 12);
			this.label3.TabIndex = 17;
			this.label3.Text = "OTT:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 264);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 19;
			this.label6.Text = "Overview:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 12);
			this.label2.TabIndex = 18;
			this.label2.Text = "Genres:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 20;
			this.label1.Text = "Title:";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(350, 439);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(76, 24);
			this.buttonSave.TabIndex = 6;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(438, 439);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(76, 24);
			this.buttonDelete.TabIndex = 7;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.UseVisualStyleBackColor = true;
			// 
			// checkedListBoxGenres
			// 
			this.checkedListBoxGenres.FormattingEnabled = true;
			this.checkedListBoxGenres.Location = new System.Drawing.Point(110, 41);
			this.checkedListBoxGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkedListBoxGenres.Name = "checkedListBoxGenres";
			this.checkedListBoxGenres.Size = new System.Drawing.Size(166, 106);
			this.checkedListBoxGenres.TabIndex = 1;
			// 
			// checkedListBoxOTTs
			// 
			this.checkedListBoxOTTs.FormattingEnabled = true;
			this.checkedListBoxOTTs.Location = new System.Drawing.Point(349, 43);
			this.checkedListBoxOTTs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkedListBoxOTTs.Name = "checkedListBoxOTTs";
			this.checkedListBoxOTTs.Size = new System.Drawing.Size(166, 106);
			this.checkedListBoxOTTs.TabIndex = 2;
			// 
			// dateTimePickerReleaseDate
			// 
			this.dateTimePickerReleaseDate.Location = new System.Drawing.Point(110, 226);
			this.dateTimePickerReleaseDate.Name = "dateTimePickerReleaseDate";
			this.dateTimePickerReleaseDate.Size = new System.Drawing.Size(200, 22);
			this.dateTimePickerReleaseDate.TabIndex = 21;
			// 
			// FormUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 471);
			this.Controls.Add(this.dateTimePickerReleaseDate);
			this.Controls.Add(this.checkedListBoxOTTs);
			this.Controls.Add(this.checkedListBoxGenres);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxCategory);
			this.Controls.Add(this.textBoxOverview);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.Name = "FormUpdate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "更新影片資料";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.TextBox textBoxOverview;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.CheckedListBox checkedListBoxGenres;
		private System.Windows.Forms.CheckedListBox checkedListBoxOTTs;
		private System.Windows.Forms.DateTimePicker dateTimePickerReleaseDate;
	}
}