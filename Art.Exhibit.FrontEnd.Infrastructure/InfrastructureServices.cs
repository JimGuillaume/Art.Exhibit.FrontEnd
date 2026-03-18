using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Infrastructure.HttpClients;

namespace Art.Exhibit.FrontEnd.Infrastructure;

public static class InfrastructureServicesExtension
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient<IArtExhibitApiClient, ArtExhibitApiClient>(client =>
            client.BaseAddress = new Uri("https://localhost:7199/api/"));

        return services;
    }
}