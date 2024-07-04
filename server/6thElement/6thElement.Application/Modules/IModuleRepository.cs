using _6thElement.Domain;

namespace _6thElement.Application.Modules;

public interface IModuleRepository
{

    public Task<List<Module>> GetAllAsync(CancellationToken cancellationToken);

    public Task<Module?> GetByIdAsync(int id, CancellationToken cancellationToken);

}
