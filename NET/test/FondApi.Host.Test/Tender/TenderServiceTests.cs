using FondApi.Business.Photoreport.Models;
using FondApi.Business.Photoreport;
using FondApi.Repository.Photoreport.Models;
using FondApi.Repository.Photoreport;
using NSubstitute;
using System.Collections.Generic;
using Xunit;
using FondApi.Repository.Tender;
using FondApi.Business.Tender;
using FondApi.Repository.Tender.Models;
using FondApi.Business.Tender.Models;
using System.Linq;

namespace FondApi.Host.Test.Tender;

public class TenderServiceTests
{
    private readonly ITenderRepository _repository;
    private readonly ITenderService _service;

    public TenderServiceTests()
    {
        _repository = Substitute.For<ITenderRepository>();
        _service = new TenderService(_repository);
    }

    [Fact]
    public async void GetTendersAsync_Success()
    {
        // Arrange
        var tenders = new TenderDb[] {
            new TenderDb() { TenderId = 1, },
            new TenderDb() { TenderId = 2, },
        };

        _repository.GetListAsync().Returns(tenders);

        // Act
        var response = await _service.GetTendersAsync();

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetTendersResponse>>(response);
        Assert.Equal(tenders.Length, response.Count());
        await _repository.Received(1).GetListAsync();
    }
}