namespace FondApi.Business.Tender.Models;

public class GetTendersResponse
{
    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public IList<TenderInfo>? Items { get; init; }
}
