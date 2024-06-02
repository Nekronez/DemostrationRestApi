namespace FondApi.Repository.ConfigParameter.Models;

public class ConfigParameterDb
{
    public int Id { get; init; }

    public string Key { get; init; } = default!;

    public string Value { get; init; } = default!;
}
