using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectUrl { get; set; }
        public string ProjectHeader { get; set; }
        public string ProjectImageUrl { get; set; }
        public string ProjectText { get; set; }
        public DateTime ProjectDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<ProjectCategory> ProjectCategories { get; set; }
    }
}
