using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class OrderService : IOrderService
{
    private readonly IArtExhibitApiClient _apiClient;
    public OrderService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<OrderDTO>>("order") ?? [];

    public async Task<OrderDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<OrderDTO>($"order/{id}");

    public async Task CreateAsync(CreateOrderDTO dto)
        => await _apiClient.PostAsync<CreateOrderDTO, object>("order", dto);

    public async Task UpdateAsync(UpdateOrderDTO dto)
        => await _apiClient.PutAsync<UpdateOrderDTO, object>("order", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"order/{id}");
}