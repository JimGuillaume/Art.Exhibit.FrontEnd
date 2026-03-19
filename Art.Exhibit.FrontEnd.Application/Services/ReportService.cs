using Art.Exhibit.FrontEnd.Application.DTOs;
using Art.Exhibit.FrontEnd.Application.Interfaces.HttpClients;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;

namespace Art.Exhibit.FrontEnd.Application.Services;

public class ReportService : IReportService
{
    private readonly IArtExhibitApiClient _apiClient;
    public ReportService(IArtExhibitApiClient apiClient) => _apiClient = apiClient;

    public async Task<IEnumerable<ReportDTO>> GetAllAsync()
        => await _apiClient.GetAsync<IEnumerable<ReportDTO>>("report") ?? [];

    public async Task<ReportDTO?> GetByIdAsync(int id)
        => await _apiClient.GetAsync<ReportDTO>($"report/{id}");

    public async Task CreateAsync(CreateReportDTO dto)
        => await _apiClient.PostAsync<CreateReportDTO, object>("report", dto);

    public async Task UpdateAsync(UpdateReportDTO dto)
        => await _apiClient.PutAsync<UpdateReportDTO, object>("report", dto);

    public async Task DeleteAsync(int id)
        => await _apiClient.DeleteAsync($"report/{id}");
}