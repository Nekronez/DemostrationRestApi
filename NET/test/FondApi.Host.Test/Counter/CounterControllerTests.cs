using FondApi.Business.Counter;
using FondApi.Business.Counter.Model;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Counter
{
    public class CounterControllerTests
    {
        private readonly ICounterService _counterService;
        private readonly CounterController _controller;

        public CounterControllerTests()
        {
            _counterService = Substitute.For<ICounterService>();
            _controller = new CounterController(_counterService);
        }

        [Fact]
        public async void GetCounters_Success()
        {
            // Arrange
            var counters = new GetCountersResponse[] {
                new GetCountersResponse(),
                new GetCountersResponse(),
            };

            _counterService.GetCountersAsync().Returns(counters);

            // Act
            var response = await _controller.GetCountersAsync();

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
