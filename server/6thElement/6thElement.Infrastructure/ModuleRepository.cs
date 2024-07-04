using _6thElement.Application.Modules;
using _6thElement.Domain;
using _6thElement.Persistance.DbContext;
using Microsoft.EntityFrameworkCore;

namespace _6thElement.Infrastructure;

public class ModuleRepository : IModuleRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Module> _module;

    public ModuleRepository(AppDbContext context)
    {
        _context = context;
        _module = context.Modules;
    }

    public async Task<List<Module>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _module.ToListAsync(cancellationToken);
    }

    public async Task<Module?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _module
            .Include(x => x.Chapters)
            .SingleOrDefaultAsync(module => module.Id == id, cancellationToken);
    }
}
