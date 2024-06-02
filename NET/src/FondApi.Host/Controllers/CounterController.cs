using FondApi.Business.Counter;
using FondApi.Business.Counter.Model;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers
{
    /// <summary>
    /// CounterController
    /// </summary>
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counterService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="counterService"></param>
        public CounterController(
            ICounterService counterService)
        {
            _counterService = counterService;
        }

        /// <summary>
        /// Получение значений счётчиков
        /// </summary>
        /// <returns></returns>
        [HttpGet("/main/counters")]
        [ProducesResponseType(typeof(IEnumerable<GetCountersResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountersAsync()
            => Ok(await _counterService.GetCountersAsync());
    }
}
