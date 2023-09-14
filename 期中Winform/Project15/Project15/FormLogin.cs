using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project15
{
	public partial class FormLogin : Form
	{
		public FormLogin()
		{
			InitializeComponent();
			buttonLogin.Click += ButtonLogin_Click;
			buttonCreateAccount.Click += ButtonCreateAccount_Click; 
		}

		private void ButtonCreateAccount_Click(object sender, EventArgs e)
		{
			var frm = new FormCreateAccount();

			frm.Owner = this;

			frm.Show();

			this.Hide();
		}

		private void ButtonLogin_Click(object sender, EventArgs e)
		{
			// 測試用登陸 帳號 密碼
			//string account = "test";
			//string password = "123";

			var account = this.textBoxAccount.Text;
			var password = this.textBoxPassword.Text;

			//Precondition check
			if (string.IsNullOrEmpty(account))
			{
				MessageBox.Show("請輸入帳號");
				return;
			}
			if (string.IsNullOrEmpty(password))
			{
				MessageBox.Show("請輸入密碼");
				return;
			}
			var service = new Services.UserService();
			try
			{
				service.ValidLogin(account, password);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}


			var frm = new FormMain();

			frm.Owner = this;

			frm.Show();

			this.Hide();
		}
	}
}
