using Entity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                return Unauthorized(new { message = "Geçersiz kullanıcı kimliği." });

            var user = await _userService.GetByIdUser(userId);
            if (user == null)
                return NotFound(new { message = "Kullanıcı bulunamadı." });

            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            });
        }
    }
}
