using FondApi.Business.Photoreport.Models;
using FondApi.Business.Video;
using FondApi.Business.Video.Models;
using FondApi.Repository.Video;
using FondApi.Repository.Video.Models;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FondApi.Host.Test.Video;

public class VideoServiceTests
{
    private readonly IVideoRepository _videoRepository;
    private readonly IVideoService _service;

    public VideoServiceTests()
    {
        _videoRepository = Substitute.For<IVideoRepository>();
        _service = new VideoService(_videoRepository);
    }

    [Fact]
    public async void GetVideosAsync_Success()
    {
        // Arrange
        var request = new GetVideoRequest
        {
            Count = 2,
            Page = 1,
        };

        var videos = new VideoDb[] {
            new VideoDb(),
            new VideoDb(),
        };

        _videoRepository.GetListAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(videos);

        // Act
        var response = await _service.GetVideosAsync(request);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetVideoResponse>>(response);
        Assert.Equal(videos.Length, response.Count());
        await _videoRepository.Received(1).GetListAsync(Arg.Any<int>(), Arg.Any<int>());
    }
}
