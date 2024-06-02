using FondApi.Business.Vacancy;
using FondApi.Business.Vacancy.Models;
using FondApi.Repository.Vacancy;
using FondApi.Repository.Vacancy.Models;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FondApi.Host.Test.Vacancy;

public class VacancyServiceTests
{
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IVacancyDepartmentRepository _vacancyDepartmentRepository;
    private readonly IVacancyService _service;

    public VacancyServiceTests()
    {
        _vacancyRepository = Substitute.For<IVacancyRepository>();
        _vacancyDepartmentRepository = Substitute.For<IVacancyDepartmentRepository>();
        _service = new VacancyService(
            _vacancyRepository,
            _vacancyDepartmentRepository);
    }

    [Fact]
    public async void GetVacanciesAsync_Success()
    {
        // Arrange
        var request = new GetVacancyRequest
        {
            DepartmentId = 1,
        };

        var vacancies = new VacancyDb[] {
            new VacancyDb(),
            new VacancyDb(),
        };

        _vacancyRepository.GetListByDepartmentIdAsync(Arg.Any<int?>()).Returns(vacancies);

        // Act
        var response = await _service.GetVacanciesAsync(request);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetVacancyResponse>>(response);
        Assert.Equal(vacancies.Length, response.Count());
        
        await _vacancyRepository.Received(1).GetListByDepartmentIdAsync(Arg.Any<int?>());
    }

    [Fact]
    public async void GetVacancyDepartmentsAsync_Success()
    {
        // Arrange
        var departments = new VacancyDepartmentDb[] {
            new VacancyDepartmentDb(),
            new VacancyDepartmentDb(),
        };

        _vacancyDepartmentRepository.GetListAsync().Returns(departments);

        // Act
        var response = await _service.GetVacancyDepartmentsAsync();

        // Assert
        Assert.IsAssignableFrom<IEnumerable<GetVacancyDepartmentsResponse>>(response);
        Assert.Equal(departments.Length, response.Count());

        await _vacancyDepartmentRepository.Received(1).GetListAsync();
    }
}
