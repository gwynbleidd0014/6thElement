using _6thElement.Application.Chapters;
using _6thElement.Domain;
using _6thElement.Persistance.DbContext;
using Microsoft.EntityFrameworkCore;

namespace _6thElement.Infrastructure;

public class ChapterRepository : IChapterRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Chapter> _chapter;

    public ChapterRepository(AppDbContext context)
    {
        _context = context;
        _chapter = context.Chapters;
    }

    public async Task<Chapter?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _chapter
            .Include(x => x.Questions)
            .ThenInclude(x => x.Answers)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
