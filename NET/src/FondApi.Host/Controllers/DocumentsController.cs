using FondApi.Business.Document;
using FondApi.Business.Document.Models;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers;

/// <summary>
/// DocumentsController
/// </summary>
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="documentService"></param>
    public DocumentsController(
        IDocumentService documentService)
    {
        _documentService = documentService;
    }

    /// <summary>
    /// Получение документов
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("/documents")]
    [ProducesResponseType(typeof(IEnumerable<GetDocumentsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDocumentsAsync(
        [FromQuery] GetDocumentsRequest request)
        => Ok(await _documentService.GetDocumentsAsync(request.Page));
}
