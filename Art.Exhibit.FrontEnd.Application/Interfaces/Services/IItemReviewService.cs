using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IItemReviewService
{
    Task<IEnumerable<ItemReviewDTO>> GetByItemIdAsync(int itemId);
    Task CreateAsync(CreateItemReviewDTO dto);
}