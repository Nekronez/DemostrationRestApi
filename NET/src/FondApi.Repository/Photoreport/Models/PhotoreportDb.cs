namespace FondApi.Repository.Photoreport.Models;

public class PhotoreportDb
{
    public uint Id { get; init; }

    public string? Address { get; init; }

    public string Type { get; init; } = default!;

    public string Cost { get; init; } = default!;

    public string Contractor { get; init; } = default!;

    public int ImageBefore { get; init; }

    public int ImageAfter { get; init; }

    public string ImageBeforeUrl { get; init; } = default!;

    public string ImageAfterUrl { get; init; } = default!;

    public DateTime Date { get; init; }

    public IList<string>? Images { get; init; }
}
