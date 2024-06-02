using FondApi.Repository.Event.Models;

namespace FondApi.Repository.Event;
public interface IEventRepository
{
    Task<IEnumerable<EventDb>> GetListAsync(int page, int count);
}