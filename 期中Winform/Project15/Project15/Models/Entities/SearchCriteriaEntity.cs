using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Utilities
{
	public class SearchCriteriaEntity
	{
		public string Title { get; set; }
        public int? GenreId { get; set; }
        public int? OttId { get; set; }
        public int? CategoryId { get; set; }
		public DateTime? DateTimeLow { get; set; }
		public DateTime? DateTimeHeight { get; set; }
	}
}
