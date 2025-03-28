using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Certificate : BaseEntity
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateofIssue { get; set; }
        public string CertificateImage { get; set; }
        public string AwardingOrganisation { get; set; }
    }
}
