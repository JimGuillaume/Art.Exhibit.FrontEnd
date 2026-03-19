using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class ShipmentService : IShipmentService
{
    private readonly IArtExhibitApiClient _apiClient;
    public ShipmentService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<ShipmentDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<ShipmentDTO>>("shipment") ?? [];

    public async Task<ShipmentDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<ShipmentDTO>($"shipment/{id}");

    public async Task CreateAsync(CreateShipmentDTO dto)
        => await _apiClient.PostAsync<CreateShipmentDTO, object>("shipment", dto);

    public async Task UpdateAsync(UpdateShipmentDTO dto)
        => await _apiClient.PutAsync<UpdateShipmentDTO, object>("shipment", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"shipment/{id}");
}