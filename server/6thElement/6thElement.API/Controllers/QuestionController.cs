using _6thElement.Application.Questions;
using Microsoft.AspNetCore.Mvc;

namespace _6thElement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService questionService)
        {
            _service = questionService;
        }

        //[HttpGet("{id}")]
        //public async Task<QuestionResponseModel> GetQuestionByIdAsync(int id, CancellationToken cancellationToken)
        //{ 
        //    return await _service.GetByIdAsync(id, cancellationToken);
        //}
    }
}
