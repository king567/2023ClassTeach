using Project15.Models.Entities;
using Project15.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project15.Services
{
	public class UserService
	{
		public void ValidLogin(string account, string password)
		{
			var repo = new UserRepository();
			var user = repo.GetAccount(account);

			if (user == null)
			{
				throw new Exception("帳號密碼有錯誤");
			}
			if (user.Password != password)
			{
				throw new Exception("帳號或密碼有錯誤");
			}
			if (user.Enabled == false)
			{
				throw new Exception("帳號已停用");
			}
		}

		public void IsAccountCreated(UserEntity entity)
		{
			UserEntity newUser = new UserEntity()
			{
				Account = entity.Account,
				Password = entity.Password,
				Email = entity.Email,
			};

			//判斷使用者是否有創建過

			var repo = new UserRepository();
			var user = repo.GetAccount(newUser.Account);

			if (user != null)
			{
				throw new Exception("帳號已創建過");
			}

			repo.CreateAccount(newUser);
		}
	}
}
