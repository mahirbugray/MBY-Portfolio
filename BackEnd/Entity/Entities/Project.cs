using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectTitle { get; set; }
        public string ProjectImageUrl { get; set; }
        public string ProjectImageUrl2 { get; set; }
        public string ProjectImageUrl3 { get; set; }
        public string ProjectImageUrl4 { get; set; }
        public string ProjectImageUrl5 { get; set; }
        public string ProjectImageUrl6 { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }
        public DateTime ProjectDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
    }
}
