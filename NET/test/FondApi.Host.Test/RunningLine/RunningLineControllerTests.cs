using FondApi.Business.RunningLine;
using FondApi.Business.RunningLine.Models;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.RunningLine;

public class RunningLineControllerTests
{
    private readonly IRunningLineService _service;
    private readonly RunningLineController _controller;

    public RunningLineControllerTests()
    {
        _service = Substitute.For<IRunningLineService>();
        _controller = new RunningLineController(_service);
    }

    [Fact]
    public async void GetRunningLineAsync_Success()
    {
        // Arrange
        var runnungLine = new GetRunnungLineResponse
        {
            Title = "title",
            TargetUrl = "url",
        };

        _service.GetRunnungLineAsync().Returns(runnungLine);

        // Act
        var response = await _controller.GetRunningLineAsync();

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}
