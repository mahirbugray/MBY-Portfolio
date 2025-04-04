﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class BlogCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
