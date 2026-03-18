using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IItemService
{
    Task<IEnumerable<ItemDTO>> GetAllAsync();
    Task<ItemDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateItemDTO dto);
    Task UpdateAsync(int id, UpdateItemDTO dto);
}