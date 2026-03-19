using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
    Task<CategoryDTO?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}