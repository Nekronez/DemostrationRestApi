using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Counter;
using FondApi.Repository.Document;
using FondApi.Repository.News;
using FondApi.Repository.Feedback;
using FondApi.Repository.Photoreport;
using Microsoft.Extensions.DependencyInjection;
using FondApi.Repository.ConfigParameter;
using FondApi.Repository.Vacancy;
using FondApi.Repository.Tender;
using FondApi.Repository.Video;
using FondApi.Repository.Event;

namespace FondApi.Repository.Extenstions
{
    public static class RepositoryRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INewsRepository, NewsRepository>()
                    .AddScoped<ICounterRepository, CounterRepository>()
                    .AddScoped<IFeedbackRepository, FeedbackRepository>()
                    .AddScoped<DbConnectionFactory>()
                    .AddScoped<IPhotoreportRepository, PhotoreportRepository>()
                    .AddScoped<IConfigParameterRepository, ConfigParameterRepository>()
                    .AddScoped<IDocumentRepository, DocumentRepository>()
                    .AddScoped<IVacancyDepartmentRepository, VacancyDepartmentRepository>()
                    .AddScoped<IVacancyRepository, VacancyRepository>()
                    .AddScoped<ITenderRepository, TenderRepository>()
                    .AddScoped<IVideoRepository, VideoRepository>()
                    .AddScoped<IEventRepository, EventRepository>();
        }
    }
}
