namespace FondApi.Repository.Document.Models;

public class DocumentDb
{
    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public string Path { get; init; } = default!;

    public string TypeName { get; init; } = default!;

    public string PagePath { get; init; } = default!;

    public int TypeId { get; init; }
}
