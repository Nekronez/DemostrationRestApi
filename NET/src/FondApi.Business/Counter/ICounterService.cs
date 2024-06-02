using FondApi.Business.Counter.Model;

namespace FondApi.Business.Counter
{
    public interface ICounterService
    {
        public Task<IEnumerable<GetCountersResponse>> GetCountersAsync();
    }
}
