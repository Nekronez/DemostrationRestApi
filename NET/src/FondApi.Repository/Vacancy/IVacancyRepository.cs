using FondApi.Repository.Vacancy.Models;

namespace FondApi.Repository.Vacancy;
public interface IVacancyRepository
{
    Task<IEnumerable<VacancyDb>> GetListByDepartmentIdAsync(int? departmentId);
}