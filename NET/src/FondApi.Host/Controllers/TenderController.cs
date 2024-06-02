using FondApi.Business.Tender;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// TenderController
/// </summary>
[ApiController]
public class TenderController : ControllerBase
{
    private readonly ITenderService _tenderService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="tenderService"></param>
    public TenderController(
        ITenderService tenderService)
    {
        _tenderService = tenderService;
    }

    /// <summary>
    /// Получение информации о закупках
    /// </summary>
    /// <returns></returns>
    [HttpGet("/documents/tenders")]
    public async Task<IActionResult> GetTendersAsync()
        => Ok(await _tenderService.GetTendersAsync());
}
