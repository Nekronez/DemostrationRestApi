using FondApi.Repository.Document.Models;

namespace FondApi.Business.Document.Models;

public class GetDocumentsResponse
{ 
    public GetDocumentsResponse()
    {
    }

    public GetDocumentsResponse(int id, string name, IEnumerable<DocumentDb> documents)
    {
        Id = id;
        Name = name;
        foreach (var d in documents) 
        {
            Documents.Add(new Business.Models.Document(d));
        }
    }

    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public IList<Business.Models.Document> Documents { get; init; } = new List<Business.Models.Document>();
}
