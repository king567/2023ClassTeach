using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.Entities
{
	public class VideoGenresEntity
	{
        public int Id { get; set; }
        public int MediaInfoId { get; set; }
        public int GenreId { get; set; }
    }
}
