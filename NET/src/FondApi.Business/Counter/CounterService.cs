using FondApi.Business.Counter.Model;
using FondApi.Repository.Counter;

namespace FondApi.Business.Counter
{
    public class CounterService : ICounterService
    {
        private readonly ICounterRepository _repo;

        public CounterService(
            ICounterRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GetCountersResponse>> GetCountersAsync()
        {
            var result = await _repo.GetCountersAsync();

            return result.Select(n => new GetCountersResponse(n));
        }
    }
}
