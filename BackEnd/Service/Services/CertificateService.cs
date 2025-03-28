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
    public class CertificateService : ICertificateService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CertificateService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<string> CreateCertificate(CertificateDto certificateDto)
        {
            try
            {
                var certificate = _mapper.Map<Certificate>(certificateDto);
                await _uow.GetRepository<Certificate>().Add(certificate);
                _uow.Commit();
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteCertificate(int certificateId)
        {
            try
            {
                _uow.GetRepository<Certificate>().DeleteById(certificateId);
                _uow.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<CertificateDto>> GetAllCertificates()
        {
            try
            {
                var certificates = await _uow.GetRepository<Certificate>().GetAllAsync();
                return _mapper.Map<List<CertificateDto>>(certificates);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CertificateDto> GetCertificateById(int certificateId)
        {
            try
            {
                var certificate = await _uow.GetRepository<Certificate>().Get(x=>x.Id == certificateId);
                return _mapper.Map<CertificateDto>(certificate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CertificateDto> UpdateCertificate(CertificateDto certificateDto)
        {
            try
            {
                var oldCertificate = await _uow.GetRepository<Certificate>().Get(x => x.Id == certificateDto.Id);
                oldCertificate.Title = certificateDto.Title ?? oldCertificate.Title;
                oldCertificate.Name = certificateDto.Name ?? oldCertificate.Name;
                oldCertificate.Description = certificateDto.Description ?? oldCertificate.Description;
                oldCertificate.CertificateImage = certificateDto.CertificateImage ?? oldCertificate.CertificateImage;
                oldCertificate.AwardingOrganisation = certificateDto.AwardingOrganisation ?? oldCertificate.AwardingOrganisation;
                if (certificateDto.DateofIssue != null)
                {
                    oldCertificate.DateofIssue = certificateDto.DateofIssue.Value;
                }
                _uow.GetRepository<Certificate>().Update(oldCertificate);
                _uow.Commit();
                return certificateDto;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
