using _6thElement.API.infrastructure.JwtAuth;
using _6thElement.Application.Accounts;
using _6thElement.Application.Users;
using _6thElement.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _6thElement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly IConfiguration _configuration;

        public UserController(IAccountsService accountsService, IConfiguration configuration)
        {
            _accountsService = accountsService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = await _accountsService.LoginUserAsync(model);
            var roles = await _accountsService.GetUserRoles(user!);

            return Ok(new { token = JwtHelper.GenerateToken(user, roles, _configuration)});
        }

        [HttpPost("register")]
        public async Task<bool> Register(UserRegisterModel model)
        {
            return await _accountsService.CreateUserAsync(model);
        }

        [Authorize]
        [HttpGet]

        public async Task<UserResponseModel> GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return await _accountsService.GetUserById(userId);
        }


    }
}
