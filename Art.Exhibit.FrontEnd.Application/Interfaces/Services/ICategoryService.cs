using Art.Exhibit.FrontEnd.Application.DTOs;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
}