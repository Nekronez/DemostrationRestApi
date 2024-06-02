using FondApi.Business.Event.Models;

namespace FondApi.Business.Event;
public interface IEventService
{
    Task<IEnumerable<GetEventsResponse>> GetEventsAsync(GetEventsRequest request);
}