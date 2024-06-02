using FondApi.Repository.Counter.Model;

namespace FondApi.Business.Counter.Model
{
    public class GetCountersResponse
    {
        public GetCountersResponse()
        {
        }

        public GetCountersResponse(CounterDb news)
        {
            Id = news.Id;
            Name = news.Name;
            Value = news.Value;
            Unit = news.Unit;
        }

        public int Id { get; init; }

        public string? Name { get; init; }

        public string? Value { get; init; }

        public string? Unit { get; init; }
    }
}
