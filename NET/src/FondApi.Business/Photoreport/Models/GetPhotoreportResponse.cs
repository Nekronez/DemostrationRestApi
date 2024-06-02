using FondApi.Repository.Photoreport.Models;

namespace FondApi.Business.Photoreport.Models;

public class GetPhotoreportResponse
{
    public GetPhotoreportResponse()
    {
    }

    public GetPhotoreportResponse(PhotoreportDb photoreportDb)
    {
        Id = photoreportDb.Id;
        Address = photoreportDb.Address;
        Type = photoreportDb.Type;
        Cost = photoreportDb.Cost;
        Contractor = photoreportDb.Contractor;
        PhotoBefore = photoreportDb.ImageBeforeUrl;
        PhotoAfter = photoreportDb.ImageAfterUrl;
        Date = photoreportDb.Date.ToString("dd.MM.yyyy");

        if (photoreportDb.Images != null)
        {
            Images = Images = photoreportDb.Images
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => new Image(i)).ToList();

            if(Images.Count == 0)
            {
                Images = null;
            }
        }
    }

    public uint Id { get; init; }

    public string? Address { get; init; }

    public string Type { get; init; } = default!;

    public string Cost { get; init; } = default!;

    public string Contractor { get; init; } = default!;

    public string PhotoBefore { get; init; } = default!;

    public string PhotoAfter { get; init; } = default!;

    public string Date { get; init; } = default!;

    public IList<Image>? Images { get; set; }
}
