﻿using _6thElement.Application.Modules;
using _6thElement.Domain;
using Microsoft.AspNetCore.Mvc;

namespace _6thElement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _service;

        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ModuleResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);

        }

        [HttpGet("{id}")]
        public async Task<ModuleResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(id, cancellationToken);
        }
    }
}
