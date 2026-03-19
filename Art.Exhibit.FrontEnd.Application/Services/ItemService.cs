using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class ItemService : IItemService
{
    private readonly IArtExhibitApiClient _apiClient;
    public ItemService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<ItemDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<ItemDTO>>("item") ?? [];

    public async Task<ItemDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<ItemDTO>($"item/{id}");

    public async Task CreateAsync(CreateItemDTO dto)
        => await _apiClient.PostAsync<CreateItemDTO, object>("item", dto);

    public async Task UpdateAsync(UpdateItemDTO dto)
        => await _apiClient.PutAsync<UpdateItemDTO, object>("item", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"item/{id}");
}