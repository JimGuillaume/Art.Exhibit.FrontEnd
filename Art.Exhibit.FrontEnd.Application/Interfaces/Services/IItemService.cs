using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IItemService
{
    Task<IEnumerable<ItemDTO>> GetAllAsync();
    Task<ItemDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateItemDTO dto);
    Task UpdateAsync(UpdateItemDTO dto);
    Task DeleteAsync(int id);
}