using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class School : BaseEntity
    {
        public string SchoolUrl { get; set; }
        public string SchoolName { get; set; }
        public string SchoolEpisode { get; set; }
        public string SchoolLisans { get; set; }
        public string SchoolYear { get; set; }
        public bool IsApproved { get; set; }
    }
}
