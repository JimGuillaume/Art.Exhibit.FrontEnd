using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IItemReviewService
{
    Task<IEnumerable<ItemReviewDTO>> GetByItemIdAsync(int itemId);
    Task CreateAsync(CreateItemReviewDTO dto);
}