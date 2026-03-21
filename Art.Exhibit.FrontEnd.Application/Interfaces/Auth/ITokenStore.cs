namespace Art.Exhibit.FrontEnd.Application.Interfaces.Auth;

public interface ITokenStore
{
    Task<string?> GetAccessTokenAsync();
    Task<DateTime?> GetAccessTokenExpiresAtUtcAsync();
    Task SetAsync(string accessToken, DateTime accessTokenExpiresAtUtc);
    Task ClearAsync();
}