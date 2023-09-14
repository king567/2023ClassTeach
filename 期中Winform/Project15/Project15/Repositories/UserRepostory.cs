using Dapper;
using Project15.Models.Entities;
using Project15.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Repositories
{
	public class UserRepository
	{
		public UserEntity GetAccount(string account)
		{
			string sql = @"SELECT * FROM Users WHERE BINARY_CHECKSUM(Account)=BINARY_CHECKSUM(@Account)";

			using (var conn = new SqlDb().GetConnection("default"))
			{
				UserEntity user = conn.QueryFirstOrDefault<UserEntity>(sql, new { Account = account });

				return user;
			}
		}

		public UserEntity CreateAccount(UserEntity userEntity)
		{
			string sql = @"INSERT INTO Users 
						(Account,Password,Email)
						VALUES (@Account,@Password,@Email)";

			using (var conn = new SqlDb().GetConnection("default"))
			{
				conn.Execute(sql, userEntity);
			}

			return userEntity;
		}
	}
}