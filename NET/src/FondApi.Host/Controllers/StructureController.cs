using FondApi.Business.RunningLine;
using FondApi.Business.RunningLine.Models;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// StructureController.
/// </summary>
[ApiController]
public class StructureController : ControllerBase
{
    private readonly IStructureService _structureService;

    /// <summary>
    /// Initializes a new instance of the <see cref="StructureController"/> class.
    /// </summary>
    /// <param name="structureService"></param>
    public StructureController(
        IStructureService structureService)
    {
        _structureService = structureService;
    }

    /// <summary>
    /// Получение структуры.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/structure")]
    [ProducesResponseType(typeof(GetRunnungLineResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetStructureAsync()
    {
        var response = await _structureService.GetStructureAsync();

        if (response.Image == null)
        {
            return StatusCode(500, new ErrorDetails(500, "Не указана бегущая строка или ссылка бегущей строки"));
        }

        return Ok(response);
    }
}
