using System.ComponentModel.DataAnnotations;

namespace FondApi.Business.Photoreport.Models;

public class GetPhotoreportRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Count")]
    public int Count { get; init; } = 5;

    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Page")]
    public int Page { get; init; } = 1;

    public int? Year { get; init; }
}
