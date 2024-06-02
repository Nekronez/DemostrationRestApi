using System.ComponentModel.DataAnnotations;

namespace FondApi.Business.News.Model;

public class GetNewsRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer ExcludedId")]
    public int? ExcludedId { get; init; }

    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Count")]
    public int Count { get; init; } = 5;

    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Page")]
    public int Page { get; init; } = 1;
}
