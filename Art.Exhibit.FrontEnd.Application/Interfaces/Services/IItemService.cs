using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IItemService
{
    Task<IEnumerable<ItemDTO>> GetAllAsync();
    Task<ItemDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateItemDTO dto);
    Task UpdateAsync(int id, UpdateItemDTO dto);
}