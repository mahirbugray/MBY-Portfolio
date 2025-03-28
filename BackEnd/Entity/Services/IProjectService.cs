using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IProjectService
    {
        Task<string> CreateProject(ProjectDto projectDto);
        string DeleteProject (int projectId);
        Task<ProjectDto> GetProjectById (int projectId);
        Task<List<ProjectDto>> GetAllProjects();
        Task<ProjectDto> UpdateProject(ProjectDto projectDto);
    }
}
