using FondApi.Repository.Document.Models;

namespace FondApi.Repository.Document;
public interface IDocumentRepository
{
    Task<IEnumerable<DocumentDb>> GetListByTypeAsync(string page);
}