namespace Project15
{
	partial class FormMediaInfo
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.comboBoxGenres = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBoxOTT = new System.Windows.Forms.ComboBox();
			this.comboBoxCategory = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.buttonReloadAll = new System.Windows.Forms.Button();
			this.buttonAddNew = new System.Windows.Forms.Button();
			this.dateTimePickerDateOfStart = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerDateOfEnd = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title:";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(73, 21);
			this.textBoxTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(86, 22);
			this.textBoxTitle.TabIndex = 0;
			// 
			// comboBoxGenres
			// 
			this.comboBoxGenres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGenres.FormattingEnabled = true;
			this.comboBoxGenres.Location = new System.Drawing.Point(220, 20);
			this.comboBoxGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxGenres.Name = "comboBoxGenres";
			this.comboBoxGenres.Size = new System.Drawing.Size(104, 20);
			this.comboBoxGenres.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(173, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "Genres:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(333, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "OTT:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(477, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "Category:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(651, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 12);
			this.label5.TabIndex = 0;
			this.label5.Text = "ReleaseDate:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(860, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(11, 12);
			this.label6.TabIndex = 0;
			this.label6.Text = "~";
			// 
			// comboBoxOTT
			// 
			this.comboBoxOTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxOTT.FormattingEnabled = true;
			this.comboBoxOTT.Location = new System.Drawing.Point(368, 20);
			this.comboBoxOTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxOTT.Name = "comboBoxOTT";
			this.comboBoxOTT.Size = new System.Drawing.Size(104, 20);
			this.comboBoxOTT.TabIndex = 2;
			// 
			// comboBoxCategory
			// 
			this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCategory.FormattingEnabled = true;
			this.comboBoxCategory.Location = new System.Drawing.Point(535, 20);
			this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxCategory.Name = "comboBoxCategory";
			this.comboBoxCategory.Size = new System.Drawing.Size(104, 20);
			this.comboBoxCategory.TabIndex = 3;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(28, 62);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 62;
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.Size = new System.Drawing.Size(970, 334);
			this.dataGridView1.TabIndex = 6;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			// 
			// buttonSearch
			// 
			this.buttonSearch.Location = new System.Drawing.Point(933, 403);
			this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(65, 31);
			this.buttonSearch.TabIndex = 9;
			this.buttonSearch.Text = "Search";
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// buttonReloadAll
			// 
			this.buttonReloadAll.Location = new System.Drawing.Point(851, 403);
			this.buttonReloadAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonReloadAll.Name = "buttonReloadAll";
			this.buttonReloadAll.Size = new System.Drawing.Size(65, 31);
			this.buttonReloadAll.TabIndex = 8;
			this.buttonReloadAll.Text = "Reload All";
			this.buttonReloadAll.UseVisualStyleBackColor = true;
			this.buttonReloadAll.Click += new System.EventHandler(this.buttonReloadAll_Click);
			// 
			// buttonAddNew
			// 
			this.buttonAddNew.Location = new System.Drawing.Point(767, 403);
			this.buttonAddNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonAddNew.Name = "buttonAddNew";
			this.buttonAddNew.Size = new System.Drawing.Size(65, 31);
			this.buttonAddNew.TabIndex = 7;
			this.buttonAddNew.Text = "Add New";
			this.buttonAddNew.UseVisualStyleBackColor = true;
			this.buttonAddNew.Click += new System.EventHandler(this.buttonReloadAll_Click);
			// 
			// dateTimePickerDateOfStart
			// 
			this.dateTimePickerDateOfStart.Location = new System.Drawing.Point(737, 21);
			this.dateTimePickerDateOfStart.Name = "dateTimePickerDateOfStart";
			this.dateTimePickerDateOfStart.Size = new System.Drawing.Size(117, 22);
			this.dateTimePickerDateOfStart.TabIndex = 4;
			// 
			// dateTimePickerDateOfEnd
			// 
			this.dateTimePickerDateOfEnd.Location = new System.Drawing.Point(883, 20);
			this.dateTimePickerDateOfEnd.Name = "dateTimePickerDateOfEnd";
			this.dateTimePickerDateOfEnd.Size = new System.Drawing.Size(115, 22);
			this.dateTimePickerDateOfEnd.TabIndex = 5;
			// 
			// FormMediaInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1021, 445);
			this.Controls.Add(this.dateTimePickerDateOfEnd);
			this.Controls.Add(this.dateTimePickerDateOfStart);
			this.Controls.Add(this.buttonAddNew);
			this.Controls.Add(this.buttonReloadAll);
			this.Controls.Add(this.buttonSearch);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.comboBoxCategory);
			this.Controls.Add(this.comboBoxOTT);
			this.Controls.Add(this.comboBoxGenres);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMediaInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "搜尋影片資料";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.ComboBox comboBoxGenres;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBoxOTT;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.Button buttonReloadAll;
		private System.Windows.Forms.Button buttonAddNew;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateOfStart;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateOfEnd;
	}
}