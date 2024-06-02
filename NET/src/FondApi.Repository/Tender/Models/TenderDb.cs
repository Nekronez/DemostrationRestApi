namespace FondApi.Repository.Tender.Models;

public class TenderDb
{
    public int TenderId { get; init; }

    public string TenderName { get; init; } = default!;

    public int TenderInfoId { get; init; }

    public string TenderInfoName { get; init; } = default!;

    public string TenderInfoUrl { get; init; } = default!;

    public int? DocumentId { get; init; }

    public string? DocumentName { get; init; }

    public string? DocumentPath { get; init; }
}
