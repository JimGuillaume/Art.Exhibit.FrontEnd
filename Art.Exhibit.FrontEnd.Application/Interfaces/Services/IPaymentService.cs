using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IPaymentService
{
    Task<PaymentDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreatePaymentDTO dto);
}