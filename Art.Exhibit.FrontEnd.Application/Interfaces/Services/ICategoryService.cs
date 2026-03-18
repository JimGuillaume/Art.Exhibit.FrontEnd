using ArtExhibit.BackEnd.Application.DTOs;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
}