using FondApi.Business.Event.Models;
using FondApi.Repository.Event;

namespace FondApi.Business.Event;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(
        IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<GetEventsResponse>> GetEventsAsync(
        GetEventsRequest request)
    {
        var result = await _eventRepository.GetListAsync(request.Page, request.Count);

        return result.Select(v => new GetEventsResponse(v));
    }
}
