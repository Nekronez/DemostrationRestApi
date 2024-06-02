using FondApi.Business.Photoreport;
using FondApi.Business.Photoreport.Models;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Photoreport;

public class PhotoreportControllerTests
{
    private readonly IPhotoreportService _photoreportService;
    private readonly PhotoreportController _controller;

    public PhotoreportControllerTests()
    {
        _photoreportService = Substitute.For<IPhotoreportService>();
        _controller = new PhotoreportController(_photoreportService);
    }

    [Fact]
    public async void GetPhotoreportsAsync_Success()
    {
        // Arrange
        var reports = new GetPhotoreportResponse[] {
            new GetPhotoreportResponse(),
            new GetPhotoreportResponse(),
        };

        _photoreportService.GetPhotoreportsAsync(Arg.Any<GetPhotoreportRequest>()).Returns(reports);

        // Act
        var response = await _controller.GetPhotoreportsAsync(default!);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}
