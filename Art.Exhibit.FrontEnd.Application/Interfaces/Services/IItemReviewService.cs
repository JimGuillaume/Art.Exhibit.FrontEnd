using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IItemReviewService
{
    Task<IEnumerable<ItemReviewDTO>> GetAllAsync();
    Task<ItemReviewDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateItemReviewDTO dto);
    Task UpdateAsync(UpdateItemReviewDTO dto);
    Task DeleteAsync(int id);
}