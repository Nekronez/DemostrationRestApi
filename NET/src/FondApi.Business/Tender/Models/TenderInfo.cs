namespace FondApi.Business.Tender.Models;

public class TenderInfo
{
    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public string? TargetUrl { get; init; }

    public IList<Business.Models.Document>? Documents { get; init; }
}
