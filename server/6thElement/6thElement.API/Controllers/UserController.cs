﻿using _6thElement.API.infrastructure.JwtAuth;
using _6thElement.Application.Accounts;
using _6thElement.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            return Ok(new { token = JwtHelper.GenerateToken(user, _configuration)});
        }

        [HttpPost("register")]
        public async Task<bool> Register(UserRegisterModel model)
        {
            return await _accountsService.CreateUserAsync(model);
        }

    }
}
