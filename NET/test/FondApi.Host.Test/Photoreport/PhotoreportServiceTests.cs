using FondApi.Business.Photoreport;
using FondApi.Business.Photoreport.Models;
using FondApi.Repository.Photoreport;
using FondApi.Repository.Photoreport.Models;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FondApi.Host.Test.Photoreport;

public class PhotoreportServiceTests
{
    private readonly IPhotoreportRepository _photoreportRepository;
    private readonly IPhotoreportService _service;

    public PhotoreportServiceTests()
    {
        _photoreportRepository = Substitute.For<IPhotoreportRepository>();
        _service = new PhotoreportService(_photoreportRepository);
    }

    [Fact]
    public async void GetPhotoreportsAsync_Success()
    {
        // Arrange
        var request = new GetPhotoreportRequest
        {
            Count = 2,
            Page = 1,
        };

        var reports = new PhotoreportDb[] {
            new PhotoreportDb(),
            new PhotoreportDb(),
        };

        _photoreportRepository.GetListAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int?>()).Returns(reports);

        // Act
        var response = await _service.GetPhotoreportsAsync(request);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetPhotoreportResponse>>(response);
        Assert.Equal(reports.Length, response.Count());
        await _photoreportRepository.Received(1).GetListAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int?>());
    }
}
