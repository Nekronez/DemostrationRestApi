namespace FondApi.Business.Photoreport.Models;

public class Image
{
    public Image(string url)
    {
        Url = url;
    }

    public string Url { get; init; } = default!;
}
