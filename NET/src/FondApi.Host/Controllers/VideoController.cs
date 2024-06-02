using FondApi.Business.Vacancy.Models;
using FondApi.Business.Vacancy;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;
using FondApi.Business.Video;
using FondApi.Business.Video.Models;

namespace FondApi.Host.Controllers;

/// <summary>
/// VideoController
/// </summary>
public class VideoController : ControllerBase
{
    private readonly IVideoService _videoService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="videoService"></param>
    public VideoController(
        IVideoService videoService)
    {
        _videoService = videoService;
    }

    /// <summary>
    /// Получение видеогалереи
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("/videos")]
    [ProducesResponseType(typeof(IEnumerable<GetVideoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetVideosAsync(
        [FromQuery] GetVideoRequest request)
        => Ok(await _videoService.GetVideosAsync(request));
}
