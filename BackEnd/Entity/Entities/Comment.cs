﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentUserName { get; set; }
        public string CommentEmail { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
