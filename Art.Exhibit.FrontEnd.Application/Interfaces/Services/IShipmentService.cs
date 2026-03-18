using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IShipmentService
{
    Task<ShipmentDTO?> GetByOrderIdAsync(int orderId);
}