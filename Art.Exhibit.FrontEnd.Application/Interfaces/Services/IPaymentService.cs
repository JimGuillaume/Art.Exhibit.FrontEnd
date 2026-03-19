using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDTO>> GetAllAsync();
    Task<PaymentDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreatePaymentDTO dto);
    Task UpdateAsync(UpdatePaymentDTO dto);
    Task DeleteAsync(int id);
}