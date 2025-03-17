using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class About : BaseEntity
    {
        public string AboutDetails { get; set; }
        public string AboutImage { get; set; }
        public bool AboutStatus { get; set; }
    }
}
