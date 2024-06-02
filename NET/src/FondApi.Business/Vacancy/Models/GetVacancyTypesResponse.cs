using FondApi.Repository.Vacancy.Models;

namespace FondApi.Business.Vacancy.Models;

public class GetVacancyDepartmentsResponse
{
    public GetVacancyDepartmentsResponse()
    {
    }

    public GetVacancyDepartmentsResponse(
        VacancyDepartmentDb vacancyDepartmentDb)
    {
        Id = vacancyDepartmentDb.Id;
        Name = vacancyDepartmentDb.Name;
    }
    
    public int Id { get; init; }

    public string Name { get; init; } = default!;
}
