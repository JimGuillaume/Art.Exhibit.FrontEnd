using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponseDTO?> LoginAsync(LoginDTO dto);
    Task<AuthResponseDTO?> RegisterAsync(RegisterDTO dto);
    Task LogoutAsync();
    Task<bool> IsAuthenticatedAsync();
}