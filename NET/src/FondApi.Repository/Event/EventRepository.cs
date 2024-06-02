using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Event.Models;

namespace FondApi.Repository.Event;

public class EventRepository : IEventRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public EventRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<EventDb>> GetListAsync(int page, int count)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT *
                  FROM f_api_get_events(@in_page, @in_count);",
                new
                {
                    in_page = page,
                    in_count = count,
                });

        return await db.QueryAsync<EventDb>(command);
    }
}
