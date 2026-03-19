using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IShipmentService
{
    Task<IEnumerable<ShipmentDTO>> GetAllAsync();
    Task<ShipmentDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateShipmentDTO dto);
    Task UpdateAsync(UpdateShipmentDTO dto);
    Task DeleteAsync(int id);
}