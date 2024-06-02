using FondApi.Business.Vacancy.Models;
using FondApi.Repository.Vacancy;

namespace FondApi.Business.Vacancy;

public class VacancyService : IVacancyService
{
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IVacancyDepartmentRepository _vacancyDepartmentRepository;

    public VacancyService(
        IVacancyRepository vacancyRepository,
        IVacancyDepartmentRepository vacancyDepartmentRepository)
    {
        _vacancyRepository = vacancyRepository;
        _vacancyDepartmentRepository = vacancyDepartmentRepository;
    }

    public async Task<IEnumerable<GetVacancyResponse>> GetVacanciesAsync(
        GetVacancyRequest request)
    {
        var result = await _vacancyRepository.GetListByDepartmentIdAsync(request.DepartmentId);

        return result.Select(v => new GetVacancyResponse(v));
    }

    public async Task<IEnumerable<GetVacancyDepartmentsResponse>> GetVacancyDepartmentsAsync()
    {
        var result = await _vacancyDepartmentRepository.GetListAsync();

        return result.Select(t => new GetVacancyDepartmentsResponse(t));
    }
}
