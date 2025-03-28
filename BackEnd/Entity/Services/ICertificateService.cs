using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface ICertificateService
    {
        Task<string> CreateCertificate(CertificateDto certificateDto);
        string DeleteCertificate(int certificateId);
        Task<CertificateDto> UpdateCertificate(CertificateDto certificateDto);
        Task<CertificateDto> GetCertificateById(int certificateId);
        Task<List<CertificateDto>> GetAllCertificates();
    }
}
