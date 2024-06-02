using FondApi.Business.Counter;
using FondApi.Business.Counter.Model;
using FondApi.Repository.Counter;
using FondApi.Repository.Counter.Model;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FondApi.Host.Test.Counter
{
    public class CounterServiceTests
    {
        private readonly ICounterRepository _counterRepo;
        private readonly CounterService _service;

        public CounterServiceTests()
        {
            _counterRepo = Substitute.For<ICounterRepository>();
            _service = new CounterService(_counterRepo);
        }

        [Fact]
        public async void GetCountersAsync_Success()
        {
            // Arrange
            var news = new CounterDb[] {
                new CounterDb(),
                new CounterDb(),
            };

            _counterRepo.GetCountersAsync().Returns(news);

            // Act
            var response = await _service.GetCountersAsync();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<GetCountersResponse>>(response);
            Assert.Equal(news.Length, response.Count());
            await _counterRepo.Received(1).GetCountersAsync();
        }
    }
}
