using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IAuthService
    {
        string GenerateToken(string id, string email, IList<string> roles);
    }
}
