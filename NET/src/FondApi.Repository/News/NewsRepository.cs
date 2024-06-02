using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.News.Model;

namespace FondApi.Repository.News;

public class NewsRepository : INewsRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public NewsRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<NewsDb>> GetNewsAsync(int count, int page, int? excludedId)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT id, title, description, created, image_path ImagePath
                  FROM f_api_get_news(@in_limit, @in_offset, @in_excluded_id)",
                new 
                {
                    in_offset = (page - 1) * count,
                    in_limit = count,
                    in_excluded_id = excludedId
                }
            );

        return await db.QueryAsync<NewsDb>(command);
    }

    public async Task<NewsDb> GetNewsDetailsAsync(int newsId)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT id, title, content, created, image_path ImagePath
                  FROM f_api_get_news_details(@in_news_id)",
                new
                {
                    in_news_id = newsId
                }
            );

        return await db.QueryFirstOrDefaultAsync<NewsDb>(command);
    }
}
