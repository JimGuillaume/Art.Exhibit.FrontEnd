using Art.Exhibit.FrontEnd.Application.Interfaces.Auth;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;
using Art.Exhibit.FrontEnd.Infrastructure.Auth;
using Art.Exhibit.FrontEnd.Infrastructure.HttpClients;
using Art.Exhibit.FrontEnd.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Art.Exhibit.FrontEnd.Infrastructure;

public static class InfrastructureServicesExtension
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ITokenStore, SessionStorageTokenStore>();
        services.AddScoped<JwtAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(sp =>
            sp.GetRequiredService<JwtAuthenticationStateProvider>());
        services.AddScoped<IAuthService, AuthService>();

        services.AddTransient<JwtAuthorizationMessageHandler>();

        services.AddHttpClient<IArtExhibitApiClient, ArtExhibitApiClient>(client =>
                client.BaseAddress = new Uri("https://localhost:7199/api/"))
            .AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

        return services;
    }
}