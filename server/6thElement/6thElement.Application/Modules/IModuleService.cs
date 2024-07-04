using _6thElement.Domain;

namespace _6thElement.Application.Modules;

public interface IModuleService
{
    public  Task<List<ModuleResponseModel>> GetAllAsync(CancellationToken cancellationToken);

    public  Task<ModuleResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken);

}
