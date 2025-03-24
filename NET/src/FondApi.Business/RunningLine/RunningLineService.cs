using FondApi.Business.RunningLine.Models;
using FondApi.Repository.ConfigParameter;

namespace FondApi.Business.RunningLine;

public class RunningLineService : IRunningLineService
{
    private const string _runningLineTextKey = "RUNNING_LINE_TEXT";
    private const string _runningLineUrlKey = "RUNNING_LINE_URL";

    private readonly IConfigParameterRepository _configParameterRepository;

    public RunningLineService(
        IConfigParameterRepository configParameterRepository)
    {
        _configParameterRepository = configParameterRepository;
    }

    public async Task<GetRunnungLineResponse> GetRunnungLineAsync()
    {
        var configs = await _configParameterRepository
            .GetByKeysAsync(new[] { _runningLineTextKey, _runningLineUrlKey });

        return new GetRunnungLineResponse
        {
            Title = configs.Where(c => c.Key == _runningLineTextKey).First()?.Value,
            TargetUrl = configs.Where(c => c.Key == _runningLineUrlKey).First()?.Value,
        };
    }
}
