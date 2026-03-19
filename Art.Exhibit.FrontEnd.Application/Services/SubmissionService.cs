using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class SubmissionService : ISubmissionService
{
    private readonly IArtExhibitApiClient _apiClient;
    public SubmissionService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<SubmissionDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<SubmissionDTO>>("submission") ?? [];

    public async Task<SubmissionDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<SubmissionDTO>($"submission/{id}");

    public async Task CreateAsync(CreateSubmissionDTO dto)
        => await _apiClient.PostAsync<CreateSubmissionDTO, object>("submission", dto);

    public async Task UpdateAsync(UpdateSubmissionDTO dto)
        => await _apiClient.PutAsync<UpdateSubmissionDTO, object>("submission", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"submission/{id}");
}