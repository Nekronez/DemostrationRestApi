using FondApi.Business.News;
using FondApi.Business.News.Model;
using FondApi.Repository.News;
using FondApi.Repository.News.Model;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FondApi.Host.Test.News;

public class NewsServiceTests
{
    private readonly INewsRepository _newsRepo;
    private readonly NewsService _service;

    public NewsServiceTests()
    {
        _newsRepo = Substitute.For<INewsRepository>();
        _service = new NewsService(_newsRepo);
    }

    [Fact]
    public async void GetNewsAsync_Success()
    {
        // Arrange
        var request = new GetNewsRequest
        {
            ExcludedId = 5,
            Count = 2,
            Page = 1,
        };
        var news = new NewsDb[] {
            new NewsDb(),
            new NewsDb(),
        };

        _newsRepo.GetNewsAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int?>()).Returns(news);

        // Act
        var response = await _service.GetNewsAsync(request);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetNewsResponse>>(response);
        Assert.Equal(news.Length, response.Count());
        await _newsRepo.Received(1).GetNewsAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>());
    }

    [Fact]
    public async void GetNewsDetailsAsync_Success()
    {
        // Arrange
        _newsRepo.GetNewsDetailsAsync(Arg.Any<int>()).Returns(new NewsDb());

        // Act
        var response = await _service.GetNewsDetailsAsync(1);

        // Assert
        Assert.IsAssignableFrom<GetNewsDetailsResponse>(response);
        Assert.NotNull(response);
        await _newsRepo.Received(1).GetNewsDetailsAsync(Arg.Any<int>());
    }
}
