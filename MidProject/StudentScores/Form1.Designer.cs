namespace StudentScores
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.TxtName = new System.Windows.Forms.TextBox();
			this.TxtEnglish = new System.Windows.Forms.TextBox();
			this.TxtMath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.BtnUpdate = new System.Windows.Forms.Button();
			this.TxtChinese = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BtnSearch = new System.Windows.Forms.Button();
			this.BtnInsert = new System.Windows.Forms.Button();
			this.DataGridOutput = new System.Windows.Forms.DataGridView();
			this.BtnDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DataGridOutput)).BeginInit();
			this.SuspendLayout();
			// 
			// TxtName
			// 
			this.TxtName.Location = new System.Drawing.Point(79, 22);
			this.TxtName.Name = "TxtName";
			this.TxtName.Size = new System.Drawing.Size(113, 31);
			this.TxtName.TabIndex = 0;
			// 
			// TxtEnglish
			// 
			this.TxtEnglish.Location = new System.Drawing.Point(268, 22);
			this.TxtEnglish.Name = "TxtEnglish";
			this.TxtEnglish.Size = new System.Drawing.Size(72, 31);
			this.TxtEnglish.TabIndex = 1;
			// 
			// TxtMath
			// 
			this.TxtMath.Location = new System.Drawing.Point(418, 22);
			this.TxtMath.Name = "TxtMath";
			this.TxtMath.Size = new System.Drawing.Size(72, 31);
			this.TxtMath.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "姓名：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(195, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "英文：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(348, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "數學：";
			// 
			// BtnUpdate
			// 
			this.BtnUpdate.Location = new System.Drawing.Point(550, 80);
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.Size = new System.Drawing.Size(97, 39);
			this.BtnUpdate.TabIndex = 7;
			this.BtnUpdate.Text = "修改";
			this.BtnUpdate.UseVisualStyleBackColor = true;
			this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
			// 
			// TxtChinese
			// 
			this.TxtChinese.Location = new System.Drawing.Point(575, 22);
			this.TxtChinese.Name = "TxtChinese";
			this.TxtChinese.Size = new System.Drawing.Size(72, 31);
			this.TxtChinese.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(505, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "中文：";
			// 
			// BtnSearch
			// 
			this.BtnSearch.Location = new System.Drawing.Point(344, 80);
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.Size = new System.Drawing.Size(97, 39);
			this.BtnSearch.TabIndex = 5;
			this.BtnSearch.Text = "查詢";
			this.BtnSearch.UseVisualStyleBackColor = true;
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// BtnInsert
			// 
			this.BtnInsert.Location = new System.Drawing.Point(241, 80);
			this.BtnInsert.Name = "BtnInsert";
			this.BtnInsert.Size = new System.Drawing.Size(97, 39);
			this.BtnInsert.TabIndex = 4;
			this.BtnInsert.Text = "新增";
			this.BtnInsert.UseVisualStyleBackColor = true;
			this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
			// 
			// DataGridOutput
			// 
			this.DataGridOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DataGridOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridOutput.Location = new System.Drawing.Point(12, 135);
			this.DataGridOutput.Name = "DataGridOutput";
			this.DataGridOutput.RowHeadersWidth = 62;
			this.DataGridOutput.RowTemplate.Height = 33;
			this.DataGridOutput.Size = new System.Drawing.Size(635, 416);
			this.DataGridOutput.TabIndex = 8;
			// 
			// BtnDelete
			// 
			this.BtnDelete.Location = new System.Drawing.Point(447, 80);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.Size = new System.Drawing.Size(97, 39);
			this.BtnDelete.TabIndex = 6;
			this.BtnDelete.Text = "刪除";
			this.BtnDelete.UseVisualStyleBackColor = true;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 567);
			this.Controls.Add(this.DataGridOutput);
			this.Controls.Add(this.BtnInsert);
			this.Controls.Add(this.BtnDelete);
			this.Controls.Add(this.BtnSearch);
			this.Controls.Add(this.BtnUpdate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TxtChinese);
			this.Controls.Add(this.TxtMath);
			this.Controls.Add(this.TxtEnglish);
			this.Controls.Add(this.TxtName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "Form1";
			this.Text = "學生成績";
			((System.ComponentModel.ISupportInitialize)(this.DataGridOutput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TxtName;
		private System.Windows.Forms.TextBox TxtEnglish;
		private System.Windows.Forms.TextBox TxtMath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button BtnUpdate;
		private System.Windows.Forms.TextBox TxtChinese;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button BtnSearch;
		private System.Windows.Forms.Button BtnInsert;
		private System.Windows.Forms.DataGridView DataGridOutput;
		private System.Windows.Forms.Button BtnDelete;
	}
}

