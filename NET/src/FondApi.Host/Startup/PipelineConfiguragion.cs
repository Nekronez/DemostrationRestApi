using FondApi.Host.Extenstions.ExceptionMiddleware;

namespace FondApi.Host.Startup;

public static class PipelineConfiguragion
{
    public static WebApplication ConfigurePipelene(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        app.MapControllers();

        return app;
    }
}
