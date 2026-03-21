using System.Globalization;
using Art.Exhibit.FrontEnd.Application.Interfaces.Auth;
using Microsoft.JSInterop;

namespace Art.Exhibit.FrontEnd.Infrastructure.Auth;

public class SessionStorageTokenStore : ITokenStore
{
    private const string AccessTokenKey = "auth.access_token";
    private const string AccessTokenExpiryKey = "auth.access_token_expires_at_utc";
    private readonly IJSRuntime _jsRuntime;

    public SessionStorageTokenStore(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string?> GetAccessTokenAsync()
        => await _jsRuntime.InvokeAsync<string?>("sessionStorage.getItem", AccessTokenKey);

    public async Task<DateTime?> GetAccessTokenExpiresAtUtcAsync()
    {
        var raw = await _jsRuntime.InvokeAsync<string?>("sessionStorage.getItem", AccessTokenExpiryKey);
        if (string.IsNullOrWhiteSpace(raw))
            return null;

        if (DateTime.TryParse(raw, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var value))
            return value.ToUniversalTime();

        return null;
    }

    public async Task SetAsync(string accessToken, DateTime accessTokenExpiresAtUtc)
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", AccessTokenKey, accessToken);
        await _jsRuntime.InvokeVoidAsync(
            "sessionStorage.setItem",
            AccessTokenExpiryKey,
            accessTokenExpiresAtUtc.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture));
    }

    public async Task ClearAsync()
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", AccessTokenKey);
        await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", AccessTokenExpiryKey);
    }
}