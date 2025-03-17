using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entity.Entities
{
    public class Blog : BaseEntity
    {
        public string BlogTitle { get; set; }

        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public string BlogTags { get; set; }
        public int CategoryId { get; set; }
        public BlogCategory Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
