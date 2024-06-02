using FondApi.Business.Tender;
using FondApi.Business.Tender.Models;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Tender;

public class TenderControllerTests
{
    private readonly ITenderService _service;
    private readonly TenderController _controller;

    public TenderControllerTests()
    {
        _service = Substitute.For<ITenderService>();
        _controller = new TenderController(_service);
    }

    [Fact]
    public async void GetTendersAsync_Success()
    {
        // Arrange
        var tenders = new GetTendersResponse[] {
            new GetTendersResponse(),
            new GetTendersResponse(),
        };

        _service.GetTendersAsync().Returns(tenders);

        // Act
        var response = await _controller.GetTendersAsync();

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}
