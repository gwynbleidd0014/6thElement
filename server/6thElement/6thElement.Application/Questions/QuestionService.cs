using Mapster;

namespace _6thElement.Application.Questions;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionService;

    public QuestionService(IQuestionRepository questionService)
    {
        _questionService = questionService;
    }

    public async Task<QuestionResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _questionService.GetByIdAsync(id, cancellationToken) ?? throw new Exception("No such question");

        return result.Adapt<QuestionResponseModel>();
    }
}
