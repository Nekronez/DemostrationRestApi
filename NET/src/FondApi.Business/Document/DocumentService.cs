using FondApi.Business.Document.Models;
using FondApi.Repository.Document;

namespace FondApi.Business.Document;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentService(
        IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<IEnumerable<GetDocumentsResponse>> GetDocumentsAsync(
        string type)
    {
        IList<GetDocumentsResponse> results = new List<GetDocumentsResponse>();

        try
        {
            var result = await _documentRepository.GetListByTypeAsync(type);

            foreach (var typeId in result.Select(t => t.TypeId).Distinct())
            {
                var typeName = result.Where(t => t.TypeId == typeId).First().TypeName;
                var docs = result.Where(t => t.TypeId == typeId);

                results.Add(new GetDocumentsResponse(typeId, typeName, docs));
            };
        }
        catch { }
        
        return results;
    }
}
