using FondApi.Repository.Event.Models;
using FondApi.Repository.Photoreport.Models;

namespace FondApi.Business.Event.Models;

/// <summary>
/// GetEventsResponse
/// </summary>
public class GetEventsResponse
{
    /// <summary>
    /// ctor
    /// </summary>
    public GetEventsResponse() { }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="eventDb"></param>
    public GetEventsResponse(EventDb eventDb)
    {
        Id = eventDb.Id;
        Name = eventDb.Name;
        Date = eventDb.Date.ToString("dd.MM.yyyy");

        if (eventDb.Images != null)
        {
            Images = Images = eventDb.Images
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => new Image(i)).ToList();

            if (Images.Count == 0)
            {
                Images = null;
            }
        }
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Date
    /// </summary>
    public string Date { get; init; } = default!;

    /// <summary>
    /// Images
    /// </summary>
    public IList<Image>? Images { get; set; }
}
