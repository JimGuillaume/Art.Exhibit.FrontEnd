using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllAsync();
    Task<OrderDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateOrderDTO dto);
    Task UpdateAsync(int id, UpdateOrderDTO dto);
}