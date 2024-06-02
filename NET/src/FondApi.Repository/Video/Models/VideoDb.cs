namespace FondApi.Repository.Video.Models;

public class VideoDb
{
    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public DateTime Date { get; init; }

    public string Resource { get; init; } = default!;

    public string Url { get; init; } = default!;
}
