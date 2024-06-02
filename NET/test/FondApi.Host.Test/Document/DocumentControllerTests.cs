using FondApi.Business.Document;
using FondApi.Business.Document.Models;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Document;

public class DocumentControllerTests
{
    private readonly IDocumentService _service;
    private readonly DocumentsController _controller;

    public DocumentControllerTests()
    {
        _service = Substitute.For<IDocumentService>();
        _controller = new DocumentsController(_service);
    }

    [Fact]
    public async void GetDocumentsAsync_Success()
    {
        // Arrange
        var request = new GetDocumentsRequest
        {
            Page = "OTHER",
        };

        var docs = new GetDocumentsResponse[] {
            new GetDocumentsResponse(),
            new GetDocumentsResponse(),
        };

        _service.GetDocumentsAsync(Arg.Any<string>()).Returns(docs);

        // Act
        var response = await _controller.GetDocumentsAsync(request);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}
