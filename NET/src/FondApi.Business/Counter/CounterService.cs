using FondApi.Business.Counter.Model;
using FondApi.Repository.Counter;

namespace FondApi.Business.Counter
{
    public class CounterService : ICounterService
    {
        private readonly ICounterRepository _mainRepo;

        public CounterService(
            ICounterRepository newsRepo)
        {
            _mainRepo = newsRepo;
        }

        public async Task<IEnumerable<GetCountersResponse>> GetCountersAsync()
        {
            var result = await _mainRepo.GetCountersAsync();

            return result.Select(n => new GetCountersResponse(n));
        }
    }
}
