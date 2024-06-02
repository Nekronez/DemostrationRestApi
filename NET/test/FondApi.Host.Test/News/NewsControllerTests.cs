using FondApi.Business.News;
using FondApi.Business.News.Model;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.News;

public class NewsControllerTests
{
    private readonly INewsService _newsService;
    private readonly NewsController _controller;

    public NewsControllerTests()
    {
        _newsService = Substitute.For<INewsService>();
        _controller = new NewsController(_newsService);
    }

    [Fact]
    public async void GetNews_Success()
    {
        // Arrange
        var request = new GetNewsRequest
        {
            Count = 2,
            Page = 1,
        };
        var news = new GetNewsResponse[] {
            new GetNewsResponse(),
            new GetNewsResponse(),
        };

        _newsService.GetNewsAsync(Arg.Any<GetNewsRequest>()).Returns(news);

        // Act
        var response = await _controller.GetNewsAsync(request);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async void GetNewsDetails_Success()
    {
        // Arrange
        _newsService.GetNewsDetailsAsync(Arg.Any<int>()).Returns(new GetNewsDetailsResponse());

        // Act
        var response = await _controller.GetNewsDetailsAsync(1);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async void GetNewsDetails_NotFound()
    {
        // Arrange
        GetNewsDetailsResponse? result = null;
        _newsService.GetNewsDetailsAsync(Arg.Any<int>()).Returns(result);

        // Act
        var response = await _controller.GetNewsDetailsAsync(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(response);
    }
}
