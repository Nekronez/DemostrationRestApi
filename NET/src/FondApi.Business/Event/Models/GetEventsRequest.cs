using System.ComponentModel.DataAnnotations;

namespace FondApi.Business.Event.Models;

/// <summary>
/// GetEventsRequest
/// </summary>
public class GetEventsRequest
{
    /// <summary>
    /// Count
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Count")]
    public int Count { get; init; } = 5;

    /// <summary>
    /// Page
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Page")]
    public int Page { get; init; } = 1;
}
