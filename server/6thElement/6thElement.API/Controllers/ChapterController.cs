using _6thElement.Application.Chapters;
using _6thElement.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _6thElement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterService _service;

        public ChapterController(IChapterService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]

        public async Task<ChapterResponseModel> GetById(int id, CancellationToken cancellationToken)
        { 
            return await _service.GetByIdAsync(id, cancellationToken);
        }
    }
}
