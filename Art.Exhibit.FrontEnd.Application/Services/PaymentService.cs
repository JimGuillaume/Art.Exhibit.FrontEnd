using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IArtExhibitApiClient _apiClient;
    public PaymentService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<PaymentDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<PaymentDTO>>("payment") ?? [];

    public async Task<PaymentDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<PaymentDTO>($"payment/{id}");

    public async Task CreateAsync(CreatePaymentDTO dto)
        => await _apiClient.PostAsync<CreatePaymentDTO, object>("payment", dto);

    public async Task UpdateAsync(UpdatePaymentDTO dto)
        => await _apiClient.PutAsync<UpdatePaymentDTO, object>("payment", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"payment/{id}");
}