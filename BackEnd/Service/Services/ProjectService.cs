using AutoMapper;
using Entity.DTO_s;
using Entity.Entities;
using Entity.Services;
using Entity.UnitOfWork;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProjectService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<string> CreateProject(ProjectDto projectDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectDto);
                await _uow.GetRepository<Project>().Add(project);
                _uow.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteProject(int projectId)
        {
            try
            {
                _uow.GetRepository<Project>().DeleteById(projectId);
                _uow.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            try
            {
                var projects = await _uow.GetRepository<Project>().GetAllAsync();
                return _mapper.Map<List<ProjectDto>>(projects); 
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProjectDto> GetProjectById(int projectId)
        {
            try
            {
                var project = _uow.GetRepository<Project>().GetByIdNoAsync(projectId);
                return _mapper.Map<ProjectDto>(project);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto projectDto)
        {
            try
            {
                var oldProject = await _uow.GetRepository<Project>().Get(x => x.Id == projectDto.Id);
                if (projectDto.ProjectDate != null)
                {
                    oldProject.ProjectDate = projectDto.ProjectDate.Date;
                }
                oldProject.ProjectTitle = projectDto.ProjectTitle ?? oldProject.ProjectTitle;
                oldProject.ProjectImageUrl = projectDto.ProjectImageUrl ?? oldProject.ProjectImageUrl;
                oldProject.ProjectImageUrl2 = projectDto.ProjectImageUrl2 ?? oldProject.ProjectImageUrl2;
                oldProject.ProjectImageUrl3 = projectDto.ProjectImageUrl3 ?? oldProject.ProjectImageUrl3;
                oldProject.ProjectImageUrl4 = projectDto.ProjectImageUrl4 ?? oldProject.ProjectImageUrl4;
                oldProject.ProjectImageUrl5 = projectDto.ProjectImageUrl5 ?? oldProject.ProjectImageUrl5;
                oldProject.Description = projectDto.Description ?? oldProject.Description;
                oldProject.Technologies = projectDto.Technologies ?? oldProject.Technologies;
                _uow.GetRepository<Project>().Update(oldProject);
                _uow.Commit();
                return projectDto;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
