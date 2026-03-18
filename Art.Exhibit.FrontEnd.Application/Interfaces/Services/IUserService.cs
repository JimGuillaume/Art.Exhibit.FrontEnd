using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IUserService
{
    Task<UserDTO?> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdateUserDTO dto);
    Task RegisterAsync(RegisterDTO dto);
}