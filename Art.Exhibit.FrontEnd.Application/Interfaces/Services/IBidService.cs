using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IBidService
{
    Task<IEnumerable<BidDTO>> GetBySaleIdAsync(int saleId);
    Task<BidDTO?> PlaceBidAsync(int saleId, PlaceBidDTO dto);
}