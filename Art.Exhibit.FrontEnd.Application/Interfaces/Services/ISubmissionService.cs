using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface ISubmissionService
{
    Task<IEnumerable<SubmissionDTO>> GetAllAsync();
    Task CreateAsync(CreateSubmissionDTO dto);
}