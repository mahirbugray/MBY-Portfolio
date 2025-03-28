using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface ISkillCategoryService
    {
        Task<string> CreateSkillCategory(SkillCategoryDto skillCategoryDto);
        Task<SkillCategoryDto> UpdateSkillCategory(SkillCategoryDto skillCategoryDto);
        string DeleteSkillCategory(int skillCategoryId);
        Task<List<SkillCategoryDto>> GetAllSkillCategories();
    }
}
