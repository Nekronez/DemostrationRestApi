using FondApi.Repository.News.Model;

namespace FondApi.Repository.News;

public interface INewsRepository
{
    Task<IEnumerable<NewsDb>> GetNewsAsync(int count, int page, int? excludedId);

    Task<NewsDb> GetNewsDetailsAsync(int newsId);
}
