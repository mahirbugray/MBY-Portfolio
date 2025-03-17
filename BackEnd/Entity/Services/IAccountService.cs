using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IAccountService
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<UserDto> Login(LoginDto model);
        Task LogoutAsync();
        Task<bool> ConfirmAccountAsync(ConfirmEmailDto model);
        //Task<string> RequestPasswordReset(ForgotPasswordDto model);
        Task<string> ResetPasswordAsync(ResetPasswordDto model);
        string GetUserIdFromToken(string token);
        Task<UserDto> GetUserFromTokenAsync(string token);
    }

}
