using Project15.Models.Entities;
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
	public partial class FormCreateAccount : Form
	{
		public FormCreateAccount()
		{
			InitializeComponent();
			buttonCreate.Click += ButtonCreate_Click;
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			UserEntity newUser = new UserEntity()
			{
				Account = this.textBoxAccount.Text,
				Password = this.textBoxPassword.Text,
				Email = this.textBoxEmail.Text,
			};

			//Precondition check
			if (string.IsNullOrEmpty(newUser.Account))
			{
				MessageBox.Show("請輸入帳號");
				return;
			}
			if (string.IsNullOrEmpty(newUser.Password))
			{
				MessageBox.Show("請輸入密碼");
				return;
			}
			if (string.IsNullOrEmpty(newUser.Email))
			{
				MessageBox.Show("請輸入信箱");
				return;
			}

			var service = new Services.UserService();
			try
			{
				service.IsAccountCreated(newUser);

				MessageBox.Show("創建成功");

				(Owner as FormLogin).Show();

				this.Hide();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}


		}
	}
}
