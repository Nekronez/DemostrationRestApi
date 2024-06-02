namespace FondApi.Repository.Vacancy.Models;

public class VacancyDb
{
    public int Id { get; init; }

    public string Name { get; init; } = default!;

    public string Department { get; init; } = default!;

    public string Description { get; init; } = default!;
}
