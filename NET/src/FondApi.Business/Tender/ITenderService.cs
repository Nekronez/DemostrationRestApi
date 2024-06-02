using FondApi.Business.Tender.Models;

namespace FondApi.Business.Tender;
public interface ITenderService
{
    Task<IEnumerable<GetTendersResponse>> GetTendersAsync();
}