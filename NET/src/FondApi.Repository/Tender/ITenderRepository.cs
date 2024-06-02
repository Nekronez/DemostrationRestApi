using FondApi.Repository.Tender.Models;

namespace FondApi.Repository.Tender;
public interface ITenderRepository
{
    Task<IEnumerable<TenderDb>> GetListAsync();
}