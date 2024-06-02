using FondApi.Business.News.Model;

namespace FondApi.Business.News;

public interface INewsService
{
    Task<IEnumerable<GetNewsResponse>> GetNewsAsync(
        GetNewsRequest request);

    Task<GetNewsDetailsResponse?> GetNewsDetailsAsync(
        int newsId);
}
