namespace _6thElement.Application.Answers;

public interface IAnswerService
{
    public Task<bool> IsCorrectAsync(int id, CancellationToken cancellationToken);
}
