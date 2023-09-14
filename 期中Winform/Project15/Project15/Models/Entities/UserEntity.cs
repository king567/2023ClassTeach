﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.Entities
{
	public class UserEntity
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public bool Enabled { get; set; }
	}
}
