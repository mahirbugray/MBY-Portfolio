using AutoMapper;
using DataAccess.Identity.Model;
using Entity.DTO_s;
using Entity.Services;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;

        public AccountService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailService emailService,
            IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _authService = authService;
        }

        public async Task<UserDto> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                BirthDate = user.BirthDate,
                IsConfirmed = user.IsConfirmed,
                AccessToken = _authService.GenerateToken(user.Id.ToString(), user.Email, await _userManager.GetRolesAsync(user))
            };
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> RegisterAsync(RegisterDto model)
        {
            var appUser = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                Address = model.Address,
                IsConfirmed = false
            };

            var identityResult = await _userManager.CreateAsync(appUser, model.Password);

            if (identityResult.Succeeded)
            {
                return "OK";
            }

            return string.Join(", ", identityResult.Errors.Select(e => e.Description));
        }

        public async Task<bool> ConfirmAccountAsync(ConfirmEmailDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return false;
            }

            user.IsConfirmed = true;
            await _userManager.UpdateAsync(user);
            return true;
        }

        public async Task<string> ResetPasswordAsync(ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return "Geçersiz e-posta adresi.";
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            return result.Succeeded ? "Şifreniz başarıyla güncellendi." : string.Join(", ", result.Errors.Select(e => e.Description));
        }

        public string GetUserIdFromToken(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            return jwtToken?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task<UserDto> GetUserFromTokenAsync(string token)
        {
            var userId = GetUserIdFromToken(token);
            if (userId == null)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(userId);
            return user == null ? null : new UserDto
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                BirthDate = user.BirthDate,
                IsConfirmed = user.IsConfirmed
            };
        }
    }
}
