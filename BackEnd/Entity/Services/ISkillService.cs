using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface ISkillService
    {
        Task<string> CreateSkill(SkillDto skillDto);
        Task<SkillDto> UpdateSkill(SkillDto skillDto);
        string DeleteSkill(int skillId);
        Task<List<SkillDto>> GetAllSkills();
        Task<List<SkillDto>> GetSkillsBySkillCategory(int skillCategoryId);
        Task<List<SkillDto>> GetAllWithSkillCategory();
    }
}
