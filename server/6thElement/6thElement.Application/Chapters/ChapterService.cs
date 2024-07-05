using _6thElement.Application.Exceptions;
using _6thElement.Domain;
using Mapster;

namespace _6thElement.Application.Chapters;

public class ChapterService : IChapterService
{
    private readonly IChapterRepository _repo;

    public ChapterService(IChapterRepository repo)
    {
        _repo = repo;
    }


    public async Task<ChapterResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var chapter = await _repo.GetByIdAsync(id, cancellationToken) ?? throw new NotFound("Chapter with such id was not found");

        return chapter.Adapt<ChapterResponseModel>();
    }
}
