using FondApi.Repository.Counter.Model;

namespace FondApi.Repository.Counter
{
    public interface ICounterRepository
    {
        Task<IEnumerable<CounterDb>> GetCountersAsync();
    }
}
