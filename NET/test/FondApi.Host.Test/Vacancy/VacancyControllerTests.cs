using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;
using FondApi.Business.Vacancy;
using FondApi.Business.Vacancy.Models;

namespace FondApi.Host.Test.Vacancy;

public class VacancyControllerTests
{
    private readonly IVacancyService _service;
    private readonly VacancyController _controller;

    public VacancyControllerTests()
    {
        _service = Substitute.For<IVacancyService>();
        _controller = new VacancyController(_service);
    }

    [Fact]
    public async void GetVacanciesAsync_Success()
    {
        // Arrange
        var request = new GetVacancyRequest
        {
            DepartmentId = 1,
        };

        var vacancies = new GetVacancyResponse[] {
            new GetVacancyResponse(),
            new GetVacancyResponse(),
        };

        _service.GetVacanciesAsync(Arg.Any<GetVacancyRequest>()).Returns(vacancies);

        // Act
        var response = await _controller.GetVacanciesAsync(request);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async void GetVacancyDepartmentsAsync_Success()
    {
        // Arrange
        var departments = new GetVacancyDepartmentsResponse[] {
            new GetVacancyDepartmentsResponse(),
            new GetVacancyDepartmentsResponse(),
        };

        _service.GetVacancyDepartmentsAsync().Returns(departments);

        // Act
        var response = await _controller.GetVacancyDepartmentsAsync();

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}
