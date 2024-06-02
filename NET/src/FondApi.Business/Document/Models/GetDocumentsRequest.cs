using System.ComponentModel.DataAnnotations;

namespace FondApi.Business.Document.Models;

public class GetDocumentsRequest
{
    [Required]
    public string Page { get; init; } = default!;
}
