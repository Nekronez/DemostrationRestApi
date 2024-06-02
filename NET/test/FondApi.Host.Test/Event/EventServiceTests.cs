using FondApi.Business.Event;
using FondApi.Business.Event.Models;
using FondApi.Repository.Event;
using FondApi.Repository.Event.Models;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FondApi.Host.Test.Event;

public class EventServiceTests
{
    private readonly IEventRepository _eventRepository;
    private readonly IEventService _service;

    public EventServiceTests()
    {
        _eventRepository = Substitute.For<IEventRepository>();
        _service = new EventService(_eventRepository);
    }

    [Fact]
    public async void GetEventsAsync_Success()
    {
        // Arrange
        var request = new GetEventsRequest
        {
            Count = 2,
            Page = 1,
        };

        var events = new EventDb[] {
            new EventDb(),
            new EventDb(),
        };

        _eventRepository.GetListAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(events);

        // Act
        var response = await _service.GetEventsAsync(request);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetEventsResponse>>(response);
        Assert.Equal(events.Length, response.Count());
        await _eventRepository.Received(1).GetListAsync(Arg.Any<int>(), Arg.Any<int>());
    }
}
