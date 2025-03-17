using Entity.DTO_s;
using Entity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var user = await _accountService.Login(model);
                if (user == null)
                {
                    return NotFound(new { message = "Kullanıcı adınız ya da şifreniz hatalı!" });
                }

                return Ok(new
                {
                    user,
                    message = user.IsConfirmed ? "" : "Mail adresinizi onaylayın"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Giriş işlemi sırasında bir hata oluştu.", error = ex.Message });
            }
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return Ok(new { message = "Başarıyla çıkış yapıldı." });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                string msg = await _accountService.RegisterAsync(model);
                if (msg == "OK")
                {
                    return Ok(new { message = "Kayıt başarılı! Lütfen e-posta adresinize gelen onay kodunu girerek hesabınızı onaylayın." });
                }
                return BadRequest(new { message = msg });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Kayıt sırasında bir hata oluştu.", error = ex.Message });
            }
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                {
                    return Unauthorized(new { message = "Token bulunamadı veya hatalı." });
                }

                var token = authHeader.Replace("Bearer ", string.Empty);
                var user = await _accountService.GetUserFromTokenAsync(token);

                if (user == null)
                {
                    return Unauthorized(new { message = "Geçersiz token." });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Kullanıcı bilgisi alınırken bir hata oluştu.", error = ex.Message });
            }
        }

        [HttpPost("ConfirmAccount")]
        public async Task<IActionResult> ConfirmAccount([FromBody] ConfirmEmailDto model)
        {
            try
            {
                var result = await _accountService.ConfirmAccountAsync(model);
                if (result)
                {
                    return Ok(new { message = "Hesabınız başarıyla onaylandı. Artık giriş yapabilirsiniz." });
                }
                return BadRequest(new { message = "Geçersiz kod veya e-posta adresi! Lütfen tekrar deneyin." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Hesap onaylama sırasında bir hata oluştu.", error = ex.Message });
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            try
            {
                var result = await _accountService.ResetPasswordAsync(model);
                if (result == "Şifreniz başarıyla güncellendi.")
                {
                    return Ok(new { message = result });
                }
                return BadRequest(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Şifre sıfırlama sırasında bir hata oluştu.", error = ex.Message });
            }
        }
    }
}
