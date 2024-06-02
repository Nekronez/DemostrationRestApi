using FondApi.Business.Photoreport.Models;

namespace FondApi.Business.Photoreport;
public interface IPhotoreportService
{
    Task<IEnumerable<GetPhotoreportResponse>> GetPhotoreportsAsync(GetPhotoreportRequest request);
}