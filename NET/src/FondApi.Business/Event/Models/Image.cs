namespace FondApi.Business.Event.Models;

/// <summary>
/// Image
/// </summary>
public class Image
{
    public Image(string url)
    {
        Url = url;
    }

    /// <summary>
    /// Url
    /// </summary>
    public string Url { get; init; } = default!;
}
