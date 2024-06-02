using FondApi.Business.Vacancy;
using FondApi.Business.Vacancy.Models;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// VacancyController
/// </summary>
[ApiController]
public class VacancyController : ControllerBase
{
    private readonly IVacancyService _vacancyService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="vacancyService"></param>
    public VacancyController(
        IVacancyService vacancyService)
    {
        _vacancyService = vacancyService;
    }

    /// <summary>
    /// Получение списка ваканций
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("/vacancy")]
    [ProducesResponseType(typeof(IEnumerable<GetVacancyResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetVacanciesAsync(
        [FromQuery] GetVacancyRequest request)
        => Ok(await _vacancyService.GetVacanciesAsync(request));

    /// <summary>
    /// Получение списка отделов
    /// </summary>
    /// <returns></returns>
    [HttpGet("/vacancy/departments")]
    [ProducesResponseType(typeof(IEnumerable<GetVacancyDepartmentsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetVacancyDepartmentsAsync()
        => Ok(await _vacancyService.GetVacancyDepartmentsAsync());
}
