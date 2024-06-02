using FondApi.Business.News.Model;
using FondApi.Repository.News;

namespace FondApi.Business.News;

public class NewsService : INewsService
{
    private readonly INewsRepository _newsRepo;

    public NewsService(
        INewsRepository newsRepo)
    {
        _newsRepo = newsRepo;
    }

    public async Task<IEnumerable<GetNewsResponse>> GetNewsAsync(
        GetNewsRequest request)
    {
        var result = await _newsRepo.GetNewsAsync(request.Count, request.Page, request.ExcludedId);

        return result.Select(n => new GetNewsResponse(n));
    }

    public async Task<GetNewsDetailsResponse?> GetNewsDetailsAsync(
        int newsId)
    {
        var result = await _newsRepo.GetNewsDetailsAsync(newsId);

        if(result is null)
        {
            return null;
        }

        return new GetNewsDetailsResponse(result);
    }
}
