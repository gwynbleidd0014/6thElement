using _6thElement.Application.Exceptions;
using _6thElement.Domain;
using Mapster;

namespace _6thElement.Application.Modules;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _repo;

    public ModuleService(IModuleRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ModuleResponseModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var modules = await _repo.GetAllAsync(cancellationToken);
        return modules.Adapt<List<ModuleResponseModel>>();
    }

    public async Task<ModuleResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var module =  await _repo.GetByIdAsync(id, cancellationToken) ?? throw new NotFound("Module with such id was not found");
        return module.Adapt<ModuleResponseModel>();
    }

}
