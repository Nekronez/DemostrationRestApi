namespace FondApi.Repository.Event.Models;

public class EventDb
{
    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public DateTime Date { get; init; }

    public IList<string> Images { get; init; }
}
