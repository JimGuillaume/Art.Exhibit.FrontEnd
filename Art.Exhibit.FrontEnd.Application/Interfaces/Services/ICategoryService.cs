using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
}