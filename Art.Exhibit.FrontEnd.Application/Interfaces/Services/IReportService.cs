using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface IReportService
{
    Task<ReportDTO?> GetAsync();
}