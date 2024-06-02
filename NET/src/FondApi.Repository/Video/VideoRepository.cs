using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Video.Models;

namespace FondApi.Repository.Video;

public class VideoRepository : IVideoRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public VideoRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<VideoDb>> GetListAsync(int page, int count)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT *
                  FROM f_api_get_videos(@in_page, @in_count);",
                new
                {
                    in_page = page,
                    in_count = count,
                });

        return await db.QueryAsync<VideoDb>(command);
    }
}
