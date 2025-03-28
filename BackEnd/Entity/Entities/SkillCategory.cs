using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SkillCategory : BaseEntity
    {
        public string SkillCategoryName { get; set; }
        public string Description { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
