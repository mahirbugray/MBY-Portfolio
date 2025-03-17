using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SkillCategory : BaseEntity
    {
        public CategorySkill CategorySkill { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
