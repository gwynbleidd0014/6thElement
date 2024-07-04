namespace _6thElement.Application.Answers;

public interface IAnswerRepository
{
    public Task<bool> IsCorrectAsync(int id, CancellationToken cancellationToken);
}
