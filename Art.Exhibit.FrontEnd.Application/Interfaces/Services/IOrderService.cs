using ArtExhibit.BackEnd.Application.DTOs;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllAsync();
    Task<OrderDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateOrderDTO dto);
    Task UpdateAsync(int id, UpdateOrderDTO dto);
}