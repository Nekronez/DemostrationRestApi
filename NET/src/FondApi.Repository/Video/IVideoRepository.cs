using FondApi.Repository.Video.Models;

namespace FondApi.Repository.Video;
public interface IVideoRepository
{
    Task<IEnumerable<VideoDb>> GetListAsync(int page, int count);
}