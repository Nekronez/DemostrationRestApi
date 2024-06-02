using FondApi.Business.News;
using FondApi.Business.News.Model;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// NewsController
/// </summary>
[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="newsService"></param>
    public NewsController(
        INewsService newsService)
    {
        _newsService = newsService;
    }

    /// <summary>
    /// Получение списка новостей
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("/news")]
    [ProducesResponseType(typeof(IEnumerable<GetNewsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetNewsAsync(
        [FromQuery] GetNewsRequest request)
        => Ok(await _newsService.GetNewsAsync(request));

    /// <summary>
    /// Получение деталей новости
    /// </summary>
    /// <param name="newsId"></param>
    /// <returns></returns>
    [HttpGet("/news/{newsId}")]
    [ProducesResponseType(typeof(GetNewsDetailsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetNewsDetailsAsync(
        [FromRoute] int newsId)
    {
        var result = await _newsService.GetNewsDetailsAsync(newsId);

        if (result is null)
        {
            return NotFound(new ErrorDetails(404, "Новость не найдена"));
        }

        return Ok(result);
    }
}
