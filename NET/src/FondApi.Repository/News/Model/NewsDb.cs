namespace FondApi.Repository.News.Model;

public class NewsDb
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Content { get; init; }

    public DateTime Created { get; init; }

    public string? ImagePath { get; init; }
}
