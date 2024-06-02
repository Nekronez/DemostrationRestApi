using FondApi.Business.Photoreport.Models;
using FondApi.Business.Video.Models;

namespace FondApi.Business.Video;
public interface IVideoService
{
    Task<IEnumerable<GetVideoResponse>> GetVideosAsync(GetVideoRequest request);
}