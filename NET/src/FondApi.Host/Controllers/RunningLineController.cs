using FondApi.Business.RunningLine;
using FondApi.Business.RunningLine.Models;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// RunningLineController
/// </summary>
[ApiController]
public class RunningLineController : ControllerBase
{
    private readonly IRunningLineService _runningLineService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="runningLineService"></param>
    public RunningLineController(
        IRunningLineService runningLineService)
    {
        _runningLineService = runningLineService;
    }

    /// <summary>
    /// Получение данных бегущей строки
    /// </summary>
    /// <returns></returns>
    [HttpGet("/main/alert")]
    [ProducesResponseType(typeof(GetRunnungLineResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRunningLineAsync()
    {
        var runningLine = await _runningLineService.GetRunnungLineAsync();

        if (runningLine.Title == null || runningLine.TargetUrl == null)
        {
            return BadRequest(new ErrorDetails(400, "Не указана бегущая строка или ссылка бегущей строки"));
        }

        return Ok(runningLine);
    }
}
