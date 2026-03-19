using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllAsync();
    Task<UserDTO?> GetByIdAsync(int id);
    Task RegisterAsync(RegisterDTO dto);
    Task UpdateAsync(UpdateUserDTO dto);
    Task DeleteAsync(int id);
}