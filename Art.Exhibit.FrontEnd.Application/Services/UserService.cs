using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class UserService : IUserService
{
    private readonly IArtExhibitApiClient _apiClient;
    public UserService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<UserDTO>>("user") ?? [];

    public async Task<UserDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<UserDTO>($"user/{id}");

    public async Task RegisterAsync(RegisterDTO dto)
        => await _apiClient.PostAsync<RegisterDTO, object>("user", dto);

    public async Task UpdateAsync(UpdateUserDTO dto)
        => await _apiClient.PutAsync<UpdateUserDTO, object>("user", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"user/{id}");
}