using _6thElement.Application.Answers;
using _6thElement.Domain;
using _6thElement.Persistance.DbContext;
using Microsoft.EntityFrameworkCore;

namespace _6thElement.Infrastructure;

public class AnswerRepository : IAnswerRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Answer> _answer;

    public AnswerRepository(AppDbContext context)
    {
        _context = context;
        _answer = context.Answers;
    }

    public async Task<bool> IsCorrectAsync(int id, CancellationToken cancellationToken)
    {
        var answer = await _answer.SingleOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new Exception("No Such answer");

        return answer.IsCorrect;

    }
}
