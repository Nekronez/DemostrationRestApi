using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Vacancy.Models;

namespace FondApi.Repository.Vacancy;

public class VacancyDepartmentRepository : IVacancyDepartmentRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public VacancyDepartmentRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<VacancyDepartmentDb>> GetListAsync()
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT *
                  FROM f_api_get_vacancy_departments()");

        return await db.QueryAsync<VacancyDepartmentDb>(command);
    }
}
