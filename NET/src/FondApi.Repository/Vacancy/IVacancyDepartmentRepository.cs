using FondApi.Repository.Vacancy.Models;

namespace FondApi.Repository.Vacancy;
public interface IVacancyDepartmentRepository
{
    Task<IEnumerable<VacancyDepartmentDb>> GetListAsync();
}