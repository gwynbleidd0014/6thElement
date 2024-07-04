
namespace _6thElement.Application.Answers;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerService;

    public AnswerService(IAnswerRepository answerService)
    {
        _answerService = answerService;
    }

    public async Task<bool> IsCorrectAsync(int id, CancellationToken cancellationToken)
    {
        return await _answerService.IsCorrectAsync(id, cancellationToken);
    }
}
