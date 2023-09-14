using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.VMs
{
	public class MediaInfoListVM
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Category { get; set; }
		public string Title { get; set; }
		public string OverView { get; set; }
		public string OTT { get; set; }
		public string Genre { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}
