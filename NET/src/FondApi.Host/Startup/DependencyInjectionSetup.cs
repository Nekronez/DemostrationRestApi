using FondApi.Business.Email;
using FondApi.Business.Extenstions;
using FondApi.Integration.Extenstions;
using FondApi.Repository;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Extenstions;

namespace FondApi.Host.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<DbSettings>(config.GetSection("DbSettings"));
        services.Configure<EmailConfiguration>(config.GetSection("EmailConfiguration"));

        services.AddRepositories();
        services.AddBusiness();
        services.AddIntegration();

        services.AddSingleton<DbConnectionFactory>();
        services.AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.DateFormatString = "dd.MM.yyyy";
                });

        return services;
    }
}
