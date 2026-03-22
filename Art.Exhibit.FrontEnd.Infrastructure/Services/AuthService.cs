using System.Net;
using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.Auth;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;
using Art.Exhibit.FrontEnd.Infrastructure.Auth;

namespace Art.Exhibit.FrontEnd.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IArtExhibitApiClient _apiClient;
    private readonly ITokenStore _tokenStore;
    private readonly JwtAuthenticationStateProvider _authStateProvider;

    public AuthService(
        IArtExhibitApiClient apiClient,
        ITokenStore tokenStore,
        JwtAuthenticationStateProvider authStateProvider)
    {
        _apiClient = apiClient;
        _tokenStore = tokenStore;
        _authStateProvider = authStateProvider;
    }

    public async Task<AuthResponseDTO?> LoginAsync(LoginDTO dto)
    {
        try
        {
            var response = await _apiClient.PostAsync<LoginDTO, AuthResponseDTO>("user/login", dto);
            if (response is null || string.IsNullOrWhiteSpace(response.AccessToken))
                return null;

            await _tokenStore.SetAsync(response.AccessToken, response.AccessTokenExpiresAtUtc);
            _authStateProvider.NotifyUserAuthentication(response.AccessToken);

            return response;
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            return null;
        }
    }

    public async Task LogoutAsync()
    {
        await _tokenStore.ClearAsync();
        _authStateProvider.NotifyUserLogout();
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await _tokenStore.GetAccessTokenAsync();
        var expiresAtUtc = await _tokenStore.GetAccessTokenExpiresAtUtcAsync();

        return !string.IsNullOrWhiteSpace(token)
               && expiresAtUtc is not null
               && expiresAtUtc > DateTime.UtcNow;
    }
}