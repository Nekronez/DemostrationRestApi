using FondApi.Repository.Document.Models;

namespace FondApi.Business.Models;

public class Document
{
    public Document()
    {
    }

    public Document(DocumentDb documentDb)
    {
        Id = documentDb.Id;
        Name = documentDb.Name;
        Url = documentDb.Path;
    }

    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public string Url { get; init; } = default!;
}
