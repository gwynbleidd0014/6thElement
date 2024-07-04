using _6thElement.Application.Questions;
using _6thElement.Domain;
using _6thElement.Persistance.DbContext;
using Microsoft.EntityFrameworkCore;

namespace _6thElement.Infrastructure;

public class QuestionRepository : IQuestionRepository
{

    private readonly AppDbContext _context;
    private readonly DbSet<Question> _question;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
        _question = context.Questions;
    }
    public async Task<Question?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _question
            .Include(x => x.Answers)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
