using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Tender.Models;

namespace FondApi.Repository.Tender;

public class TenderRepository : ITenderRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public TenderRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<TenderDb>> GetListAsync()
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT *
                  FROM f_api_get_tenders();");

        return await db.QueryAsync<TenderDb>(command);
    }
}
