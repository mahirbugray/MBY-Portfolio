using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO_s
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public string SchoolUrl { get; set; }
        public string SchoolName { get; set; }
        public string SchoolEpisode { get; set; }
        public string SchoolLisans { get; set; }
        public string SchoolYear { get; set; }
        public bool IsApproved { get; set; }
    }
}
