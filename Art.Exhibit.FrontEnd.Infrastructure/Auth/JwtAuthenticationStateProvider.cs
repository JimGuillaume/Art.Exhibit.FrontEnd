using System.Security.Claims;
using System.Text.Json;
using Art.Exhibit.FrontEnd.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace Art.Exhibit.FrontEnd.Infrastructure.Auth;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ITokenStore _tokenStore;

    public JwtAuthenticationStateProvider(ITokenStore tokenStore)
    {
        _tokenStore = tokenStore;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _tokenStore.GetAccessTokenAsync();
        var expiresAtUtc = await _tokenStore.GetAccessTokenExpiresAtUtcAsync();

        if (string.IsNullOrWhiteSpace(token) || expiresAtUtc is null || expiresAtUtc <= DateTime.UtcNow)
        {
            await _tokenStore.ClearAsync();
            return Anonymous();
        }

        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public void NotifyUserAuthentication(string jwtToken)
    {
        var identity = new ClaimsIdentity(ParseClaimsFromJwt(jwtToken), "jwt");
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void NotifyUserLogout()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(Anonymous()));
    }

    private static AuthenticationState Anonymous()
        => new(new ClaimsPrincipal(new ClaimsIdentity()));

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var parts = jwt.Split('.');
        if (parts.Length < 2)
            return claims;

        var jsonBytes = ParseBase64WithoutPadding(parts[1]);
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonBytes);
        if (payload is null)
            return claims;

        foreach (var kvp in payload)
        {
            if (kvp.Value.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in kvp.Value.EnumerateArray())
                    claims.Add(new Claim(kvp.Key, item.ToString()));
            }
            else
            {
                claims.Add(new Claim(kvp.Key, kvp.Value.ToString()));
            }
        }

        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        base64 = base64.Replace('-', '+').Replace('_', '/');
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }
}