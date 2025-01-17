﻿using _6thElement.Application.Answers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _6thElement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _service;

        public AnswerController(IAnswerService service)
        {
            _service = service;
        }

        [HttpGet("checkAnswer/{id}")]
        public async Task<bool> CheckAnswerAsync(int id, CancellationToken cancellationToken)
        { 
            return await _service.IsCorrectAsync(id, cancellationToken);
        }
    }
}
