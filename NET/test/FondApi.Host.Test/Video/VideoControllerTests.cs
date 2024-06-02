using FondApi.Business.Video;
using FondApi.Business.Video.Models;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Video;

public class VideoControllerTests
{
    private readonly IVideoService _videoService;
    private readonly VideoController _controller;

    public VideoControllerTests()
    {
        _videoService = Substitute.For<IVideoService>();
        _controller = new VideoController(_videoService);
    }

    [Fact]
    public async void GetVideosAsync_Success()
    {
        // Arrange
        var videos = new GetVideoResponse[] {
            new GetVideoResponse(),
            new GetVideoResponse(),
        };

        _videoService.GetVideosAsync(Arg.Any<GetVideoRequest>()).Returns(videos);

        // Act
        var response = await _controller.GetVideosAsync(default!);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}
