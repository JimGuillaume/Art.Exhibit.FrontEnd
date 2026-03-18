using Art.Exhibit.FrontEnd.Application.DTOs;
public interface IReportService
{
    Task<ReportDTO?> GetAsync();
}