using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Counter.Model;

namespace FondApi.Repository.Counter
{
    public class CounterRepository : ICounterRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public CounterRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<CounterDb>> GetCountersAsync()
        {
            using var db = _dbConnectionFactory.GetConnection();

            var command = new CommandDefinition(
                    @"SELECT id, name, value, unit
                      FROM counter");

            return await db.QueryAsync<CounterDb>(command);
        }
    }
}
