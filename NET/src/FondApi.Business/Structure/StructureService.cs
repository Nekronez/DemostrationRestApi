using FondApi.Business.RunningLine.Models;
using FondApi.Repository.ConfigParameter;

namespace FondApi.Business.RunningLine;

public class StructureService : IStructureService
{
    private const string _structureImageKey = "STRUCTURE_IMAGE";

    private readonly IConfigParameterRepository _configParameterRepository;

    public StructureService(
        IConfigParameterRepository configParameterRepository)
    {
        _configParameterRepository = configParameterRepository;
    }

    public async Task<GetStructureResponse> GetStructureAsync()
    {
        var configs = await _configParameterRepository
            .GetByKeysAsync(new[] { _structureImageKey });

        return new GetStructureResponse
        {
            Image = configs.Where(c => c.Key == _structureImageKey).First()?.Value,
        };
    }
}
