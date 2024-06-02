using FondApi.Repository.Video.Models;

namespace FondApi.Business.Video.Models;

/// <summary>
/// GetVideoResponse
/// </summary>
public class GetVideoResponse
{
    /// <summary>
    /// ctor
    /// </summary>
    public GetVideoResponse()
    {
    }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="videoDb"></param>
    public GetVideoResponse(VideoDb videoDb)
    {
        Id = videoDb.Id;
        Name = videoDb.Name;
        Date = videoDb.Date.ToString("dd.MM.yyyy");
        Resource = videoDb.Resource;
        Url = videoDb.Url;
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
    /// Resource
    /// </summary>
    public string Resource { get; init; } = default!;

    /// <summary>
    /// Url
    /// </summary>
    public string Url { get; init; } = default!;
}
