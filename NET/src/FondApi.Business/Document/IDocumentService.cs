using FondApi.Business.Document.Models;

namespace FondApi.Business.Document;
public interface IDocumentService
{
    Task<IEnumerable<GetDocumentsResponse>> GetDocumentsAsync(string type);
}