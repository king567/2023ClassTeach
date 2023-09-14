using Project15.Models.DTOs;
using Project15.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.VMs
{
	public class GetAllVM
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Category { get; set; }
		public string Title { get; set; }
		public string OverView { get; set; }
        //      public List<VideoOttTypesVM> OTTs { get; set; }
        //public List<VideoGenresVM> Genres { get; set; }
        public string OTTs { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
	}
}
