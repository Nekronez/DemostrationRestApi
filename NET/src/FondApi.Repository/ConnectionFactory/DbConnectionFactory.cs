using Microsoft.Extensions.Options;
using Npgsql;

namespace FondApi.Repository.ConnectionFactory;

public class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IOptions<DbSettings> dbSettings)
    {
        _connectionString = dbSettings.Value.Connection;
    }

    public NpgsqlConnection GetConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
