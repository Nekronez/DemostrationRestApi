using FondApi.Repository.Vacancy.Models;

namespace FondApi.Business.Vacancy.Models;

public class GetVacancyResponse
{
    public GetVacancyResponse()
    {
    }

    public GetVacancyResponse(
        VacancyDb vacancyDb)
    {
        Id = vacancyDb.Id;
        Title = vacancyDb.Name;
        Department = vacancyDb.Department;
        Description = vacancyDb.Description;
    }

    public int Id { get; init; }

    public string Title { get; init; } = default!;

    public string Department { get; init; } = default!;

    public string Description { get; init; } = default!;
}
