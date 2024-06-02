using Dapper;
using FondApi.Repository.ConfigParameter.Models;
using FondApi.Repository.ConnectionFactory;

namespace FondApi.Repository.ConfigParameter;

public class ConfigParameterRepository : IConfigParameterRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public ConfigParameterRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<ConfigParameterDb>> GetByKeysAsync()
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT * FROM f_api_get_running_line_data();"
            );

        return await db.QueryAsync<ConfigParameterDb>(command);
    }
}
