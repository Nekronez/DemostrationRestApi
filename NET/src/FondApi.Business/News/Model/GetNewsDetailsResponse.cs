using FondApi.Repository.News.Model;

namespace FondApi.Business.News.Model
{
    public class GetNewsDetailsResponse
    {
        public GetNewsDetailsResponse()
        {
        }

        public GetNewsDetailsResponse(NewsDb news)
        {
            Id = news.Id;
            Title = news.Title;
            Content = news.Content;
            Created = news.Created;
            ImagePath = news.ImagePath;
        }

        public int Id { get; init; }

        public string? Title { get; init; }

        public string? Content { get; init; }

        public DateTime Created { get; init; }

        public string? ImagePath { get; init; }
    }
}
