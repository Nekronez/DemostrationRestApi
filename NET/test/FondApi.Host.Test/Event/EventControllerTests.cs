using FondApi.Business.Event;
using FondApi.Business.Event.Models;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Event;

public class EventControllerTests
{
    private readonly IEventService _eventService;
    private readonly EventController _controller;

    public EventControllerTests()
    {
        _eventService = Substitute.For<IEventService>();
        _controller = new EventController(_eventService);
    }

    [Fact]
    public async void GetEventsAsync_Success()
    {
        // Arrange
        var events = new GetEventsResponse[] {
            new GetEventsResponse(),
            new GetEventsResponse(),
        };

        _eventService.GetEventsAsync(Arg.Any<GetEventsRequest>()).Returns(events);

        // Act
        var response = await _controller.GetEventsAsync(default!);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}
