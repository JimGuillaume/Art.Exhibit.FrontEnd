using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class SaleService : ISaleService
{
    private readonly IArtExhibitApiClient _apiClient;
    public SaleService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<SaleDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<SaleDTO>>("sale") ?? [];

    public async Task<SaleDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<SaleDTO>($"sale/{id}");

    public async Task CreateAsync(CreateSaleDTO dto)
        => await _apiClient.PostAsync<CreateSaleDTO, object>("sale", dto);

    public async Task UpdateAsync(UpdateSaleDTO dto)
        => await _apiClient.PutAsync<UpdateSaleDTO, object>("sale", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"sale/{id}");
}