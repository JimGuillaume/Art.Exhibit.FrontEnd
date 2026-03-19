using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IArtExhibitApiClient _apiClient;
    public CategoryService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<CategoryDTO>>("category") ?? [];

    public async Task<CategoryDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<CategoryDTO>($"category/{id}");
}