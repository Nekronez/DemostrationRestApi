using FondApi.Business.Video.Models;
using FondApi.Repository.Video;

namespace FondApi.Business.Video;

public class VideoService : IVideoService
{
    private readonly IVideoRepository _videoRepository;

    public VideoService(
        IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<IEnumerable<GetVideoResponse>> GetVideosAsync(
        GetVideoRequest request)
    {
        var result = await _videoRepository
            .GetListAsync(request.Page, request.Count);

        return result.Select(n => new GetVideoResponse(n));
    }
}
