using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Skill : BaseEntity
    {
        public string SkillText { get; set; }
        public int SkillPoint { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public List<SkillCategory> SkillCategories { get; set; }
    }
}
