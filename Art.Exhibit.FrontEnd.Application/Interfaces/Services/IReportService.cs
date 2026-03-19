using Art.Exhibit.FrontEnd.Application.DTOs;

public interface IReportService
{
    Task<IEnumerable<ReportDTO>> GetAllAsync();
    Task<ReportDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateReportDTO dto);
    Task UpdateAsync(UpdateReportDTO dto);
    Task DeleteAsync(int id);
}