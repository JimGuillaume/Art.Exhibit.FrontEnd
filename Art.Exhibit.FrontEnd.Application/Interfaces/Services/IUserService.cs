using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDTO?> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdateUserDTO dto);
    Task RegisterAsync(RegisterDTO dto);
}