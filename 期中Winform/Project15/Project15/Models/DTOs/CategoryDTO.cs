using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.DTOs
{
	public class CategoryDTO
	{
        public int Id { get; set; }
        public int MediaInfoId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
