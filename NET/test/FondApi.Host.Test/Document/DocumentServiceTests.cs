using FondApi.Business.Document;
using FondApi.Business.Document.Models;
using FondApi.Repository.Document;
using FondApi.Repository.Document.Models;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FondApi.Host.Test.Document;

public class DocumentServiceTests
{
    private readonly IDocumentRepository _repository;
    private readonly IDocumentService _service;

    public DocumentServiceTests()
    {
        _repository = Substitute.For<IDocumentRepository>();
        _service = new DocumentService(_repository);
    }

    [Fact]
    public async void GetDocumentsAsync_Success()
    {
        // Arrange
        var docs = new DocumentDb[] {
            new DocumentDb() { TypeId = 1 },
            new DocumentDb() { TypeId = 2 },
        };

        _repository.GetListByTypeAsync(Arg.Any<string>()).Returns(docs);

        // Act
        var response = await _service.GetDocumentsAsync(default!);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetDocumentsResponse>>(response);
        Assert.Equal(docs.Length, response.Count());
        
        await _repository.Received(1).GetListByTypeAsync(Arg.Any<string>());
    }
}
