using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface ISchoolService
    {
        Task<string> CreateSchool(SchoolDto schoolDto);
        string DeleteSchool(int schoolId);
        Task<SchoolDto> UpdateSchool(SchoolDto schoolDto);
        Task<List<SchoolDto>> GetAllSchools();
    }
}
