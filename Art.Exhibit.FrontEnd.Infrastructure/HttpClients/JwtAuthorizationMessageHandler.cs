using System.Net.Http.Headers;
using Art.Exhibit.FrontEnd.Application.Interfaces.Auth;

namespace Art.Exhibit.FrontEnd.Infrastructure.HttpClients;

public class JwtAuthorizationMessageHandler : DelegatingHandler
{
    private readonly ITokenStore _tokenStore;

    public JwtAuthorizationMessageHandler(ITokenStore tokenStore)
    {
        _tokenStore = tokenStore;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _tokenStore.GetAccessTokenAsync();
        var expiresAtUtc = await _tokenStore.GetAccessTokenExpiresAtUtcAsync();

        if (!string.IsNullOrWhiteSpace(token)
            && expiresAtUtc is not null
            && expiresAtUtc > DateTime.UtcNow
            && request.Headers.Authorization is null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}