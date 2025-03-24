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

    public async Task<IEnumerable<ConfigParameterDb>> GetByKeysAsync(IEnumerable<string> keys)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
            @"SELECT id, key, value FROM config_parameter WHERE key = ANY(@in_keys);",
            new
            {
                in_keys = keys.ToArray(),
            });

        return await db.QueryAsync<ConfigParameterDb>(command);
    }
}
