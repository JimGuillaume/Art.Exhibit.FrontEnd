using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class ItemReviewService : IItemReviewService
{
    private readonly IArtExhibitApiClient _apiClient;
    public ItemReviewService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<ItemReviewDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<ItemReviewDTO>>("itemreview") ?? [];

    public async Task<ItemReviewDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<ItemReviewDTO>($"itemreview/{id}");

    public async Task CreateAsync(CreateItemReviewDTO dto)
        => await _apiClient.PostAsync<CreateItemReviewDTO, object>("itemreview", dto);

    public async Task UpdateAsync(UpdateItemReviewDTO dto)
        => await _apiClient.PutAsync<UpdateItemReviewDTO, object>("itemreview", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"itemreview/{id}");

}