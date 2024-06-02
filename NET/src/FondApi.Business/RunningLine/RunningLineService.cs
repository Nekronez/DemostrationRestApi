using FondApi.Business.RunningLine.Models;
using FondApi.Repository.ConfigParameter;

namespace FondApi.Business.RunningLine;

public class RunningLineService : IRunningLineService
{
    private readonly IConfigParameterRepository _configParameterRepository;

    public RunningLineService(
        IConfigParameterRepository configParameterRepository)
    {
        _configParameterRepository = configParameterRepository;
    }

    public async Task<GetRunnungLineResponse> GetRunnungLineAsync()
    {
        var configs = await _configParameterRepository
            .GetByKeysAsync();

        return new GetRunnungLineResponse
        {
            Title = configs.Where(c => c.Key == "RUNNING_LINE_TEXT").First()?.Value,
            TargetUrl = configs.Where(c => c.Key == "RUNNING_LINE_URL").First()?.Value,
        };
    }
}
