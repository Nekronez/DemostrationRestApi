using FondApi.Business.Vacancy.Models;

namespace FondApi.Business.Vacancy;
public interface IVacancyService
{
    Task<IEnumerable<GetVacancyResponse>> GetVacanciesAsync(GetVacancyRequest request);
    Task<IEnumerable<GetVacancyDepartmentsResponse>> GetVacancyDepartmentsAsync();
}