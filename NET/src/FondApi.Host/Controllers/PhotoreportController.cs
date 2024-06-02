using FondApi.Business.Photoreport;
using FondApi.Business.Photoreport.Models;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// PhotoreportController
/// </summary>
[ApiController]
public class PhotoreportController : ControllerBase
{
    private readonly IPhotoreportService _photoreportService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="photoreportService"></param>
    public PhotoreportController(
        IPhotoreportService photoreportService)
    {
        _photoreportService = photoreportService;
    }

    /// <summary>
    /// Получение списка фотоотчётов
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("/photoreport")]
    [ProducesResponseType(typeof(IEnumerable<GetPhotoreportResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPhotoreportsAsync(
        [FromQuery] GetPhotoreportRequest request)
        => Ok(await _photoreportService.GetPhotoreportsAsync(request));
}