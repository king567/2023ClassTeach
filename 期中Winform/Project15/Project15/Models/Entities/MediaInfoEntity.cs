﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project15.Models.Entities
{
	public class MediaInfoEntity
	{
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string OverView { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Adult { get; set; }
        public double Popularity { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public bool Video { get; set; }
        public string BackdropPath { get; set; }
        public string PosterPath { get; set; }

    }
}
