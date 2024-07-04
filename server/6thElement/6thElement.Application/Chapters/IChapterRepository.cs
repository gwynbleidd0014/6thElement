using _6thElement.Domain;

namespace _6thElement.Application.Chapters;

public interface IChapterRepository
{
    public Task<Chapter?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
