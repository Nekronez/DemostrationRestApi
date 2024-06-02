using FondApi.Business.Event;
using FondApi.Business.Event.Models;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// EventController
/// </summary>
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="eventService"></param>
    public EventController(
        IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Получение списка мероприятий
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("/events")]
    [ProducesResponseType(typeof(IEnumerable<GetEventsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetEventsAsync(
        [FromQuery] GetEventsRequest request)
        => Ok(await _eventService.GetEventsAsync(request));
}
