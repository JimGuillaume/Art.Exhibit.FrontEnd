namespace Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;

public interface IArtExhibitApiClient
{
    Task<T?> GetAsync<T>(string endpoint);
    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest body);
    Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest body);
    Task DeleteAsync(string endpoint);
}