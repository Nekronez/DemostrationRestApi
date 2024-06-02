using FondApi.Business.RunningLine;
using FondApi.Business.RunningLine.Models;
using FondApi.Repository.ConfigParameter;
using FondApi.Repository.ConfigParameter.Models;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.RunningLine;

public class RunningLineServiceTests
{
    private readonly IConfigParameterRepository _repository;
    private readonly IRunningLineService _service;

    public RunningLineServiceTests()
    {
        _repository = Substitute.For<IConfigParameterRepository>();
        _service = new RunningLineService(_repository);
    }

    [Fact]
    public async void GetRunningLineAsync_Success()
    {
        // Arrange
        var configs = new ConfigParameterDb[] {
            new ConfigParameterDb()
            {
                Key = "RUNNING_LINE_TEXT",
                Value = "text",
            },
            new ConfigParameterDb()
            {
                Key = "RUNNING_LINE_URL",
                Value = "url",
            },
        };

        _repository.GetByKeysAsync().Returns(configs);

        // Act
        var response = await _service.GetRunnungLineAsync();

        // Assert
        Assert.IsAssignableFrom<GetRunnungLineResponse>(response);
        await _repository.Received(1).GetByKeysAsync();
    }
}
