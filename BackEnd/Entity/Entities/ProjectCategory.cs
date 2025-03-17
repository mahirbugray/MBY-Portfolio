using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ProjectCategory : BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
