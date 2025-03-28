using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO_s
{
    public class SkillDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public string SkillText { get; set; }
        public int SkillPoint { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public int SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}
