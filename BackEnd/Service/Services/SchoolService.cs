using AutoMapper;
using Entity.DTO_s;
using Entity.Entities;
using Entity.Services;
using Entity.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SchoolService :ISchoolService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SchoolService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<string> CreateSchool(SchoolDto schoolDto)
        {
            try
            {
                var school = _mapper.Map<School>(schoolDto);
                await _uow.GetRepository<School>().Add(school);
                _uow.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteSchool(int schoolId)
        {
            try
            {
                _uow.GetRepository<School>().DeleteById(schoolId);
                _uow.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<SchoolDto>> GetAllSchools()
        {
            try
            {
                var schools = await _uow.GetRepository<School>().GetAllAsync();
                return _mapper.Map<List<SchoolDto>>(schools);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SchoolDto> UpdateSchool(SchoolDto schoolDto)
        {
            try
            {
                var oldSchool = await _uow.GetRepository<School>().Get(x => x.Id == schoolDto.Id);
                oldSchool.SchoolLisans = schoolDto.SchoolLisans ?? oldSchool.SchoolLisans;
                oldSchool.SchoolUrl = schoolDto.SchoolUrl ?? oldSchool.SchoolUrl;
                oldSchool.SchoolName = schoolDto.SchoolName ?? oldSchool.SchoolName;
                oldSchool.SchoolYear = schoolDto.SchoolYear ?? oldSchool.SchoolYear;
                oldSchool.SchoolEpisode = schoolDto.SchoolEpisode ?? oldSchool.SchoolEpisode;
                _uow.GetRepository<School>().Update(oldSchool);
                _uow.Commit();
                return schoolDto;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
