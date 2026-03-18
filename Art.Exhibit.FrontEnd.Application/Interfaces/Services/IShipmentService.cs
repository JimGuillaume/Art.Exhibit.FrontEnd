using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IShipmentService
{
    Task<ShipmentDTO?> GetByOrderIdAsync(int orderId);
}