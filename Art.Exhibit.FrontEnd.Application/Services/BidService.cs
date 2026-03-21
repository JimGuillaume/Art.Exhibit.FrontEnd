using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class BidService : IBidService
{
    private readonly IArtExhibitApiClient _apiClient;

    public BidService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<BidDTO>> GetBySaleIdAsync(int saleId)
        => await _apiClient.GetAsync<IEnumerable<BidDTO>>($"sale/{saleId}/bid") ?? [];

    public async Task<BidDTO?> PlaceBidAsync(int saleId, PlaceBidDTO dto)
        => await _apiClient.PostAsync<PlaceBidDTO, BidDTO>($"sale/{saleId}/bid", dto);
}