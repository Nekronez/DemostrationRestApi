using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Vacancy.Models;

namespace FondApi.Repository.Vacancy;

public class VacancyRepository : IVacancyRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public VacancyRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<VacancyDb>> GetListByDepartmentIdAsync(int? departmentId)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT *
                  FROM f_api_get_vacancies(@in_department_id)",
                new
                {
                    in_department_id = departmentId,
                }
            );

        return await db.QueryAsync<VacancyDb>(command);
    }
}
