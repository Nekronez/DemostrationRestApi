using FondApi.Business.Counter;
using FondApi.Business.Document;
using FondApi.Business.Event;
using FondApi.Business.Feedback;
using FondApi.Business.News;
using FondApi.Business.Photoreport;
using FondApi.Business.RunningLine;
using FondApi.Business.Tender;
using FondApi.Business.Vacancy;
using FondApi.Business.Video;
using Microsoft.Extensions.DependencyInjection;

namespace FondApi.Business.Extenstions
{
    public static class BusinessRegistration
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ICounterService, CounterService>()
                    .AddScoped<INewsService, NewsService>()
                    .AddScoped<IFeedbackService, FeedbackService>()
                    .AddScoped<IPhotoreportService, PhotoreportService>()
                    .AddScoped<IRunningLineService, RunningLineService>()
                    .AddScoped<IDocumentService, DocumentService>()
                    .AddScoped<IVacancyService, VacancyService>()
                    .AddScoped<ITenderService, TenderService>()
                    .AddScoped<IVideoService, VideoService>()
                    .AddScoped<IEventService, EventService>();
        }
    }
}
