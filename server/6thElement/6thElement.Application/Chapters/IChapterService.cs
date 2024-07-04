using _6thElement.Domain;

namespace _6thElement.Application.Chapters;

public interface IChapterService
{
    public Task<ChapterResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken);
}
