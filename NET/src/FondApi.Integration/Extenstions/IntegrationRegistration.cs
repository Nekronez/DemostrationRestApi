using FondApi.Business.Email;
using Microsoft.Extensions.DependencyInjection;

namespace FondApi.Integration.Extenstions;

public static class IntegrationRegistration
{
    public static void AddIntegration(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
    }
}
