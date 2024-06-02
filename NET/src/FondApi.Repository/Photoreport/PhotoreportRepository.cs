using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Photoreport.Models;

namespace FondApi.Repository.Photoreport;

public class PhotoreportRepository : IPhotoreportRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public PhotoreportRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<PhotoreportDb>> GetListAsync(
        int page,
        int count,
        int? year)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT *
                  FROM f_api_get_photoreports(@in_page, @in_count, @in_year);",
                new
                {
                    in_page = page,
                    in_count = count,
                    in_year = year,
                });

        return await db.QueryAsync<PhotoreportDb>(command);
    }
}
