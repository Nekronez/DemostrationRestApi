using FondApi.Business.Photoreport.Models;
using FondApi.Repository.Photoreport;

namespace FondApi.Business.Photoreport;

public class PhotoreportService : IPhotoreportService
{
    private readonly IPhotoreportRepository _photoreportRepository;

    public PhotoreportService(
        IPhotoreportRepository photoreportRepository)
    {
        _photoreportRepository = photoreportRepository;
    }

    public async Task<IEnumerable<GetPhotoreportResponse>> GetPhotoreportsAsync(
        GetPhotoreportRequest request)
    {
        var result = await _photoreportRepository
            .GetListAsync(request.Page, request.Count, request.Year);

        return result.Select(n => new GetPhotoreportResponse(n));
    }
}
