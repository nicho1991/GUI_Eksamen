﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaJamAjax.Models
{
    public class Music
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbNailUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
