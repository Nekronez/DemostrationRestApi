using FondApi.Repository.Photoreport.Models;

namespace FondApi.Repository.Photoreport;

public interface IPhotoreportRepository
{
    Task<IEnumerable<PhotoreportDb>> GetListAsync(int page, int count, int? year);
}