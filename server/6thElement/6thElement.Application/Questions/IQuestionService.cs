using _6thElement.Domain;

namespace _6thElement.Application.Questions;

public interface IQuestionService
{
    public Task<QuestionResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken);
}
