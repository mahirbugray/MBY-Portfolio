using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class CategorySkill : BaseEntity
    {
        public string SkillArea { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public List<SkillCategory> SkillCategories { get; set; }
    }
}
