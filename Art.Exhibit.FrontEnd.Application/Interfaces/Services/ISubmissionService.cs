using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface ISubmissionService
{
    Task<IEnumerable<SubmissionDTO>> GetAllAsync();
    Task<SubmissionDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateSubmissionDTO dto);
    Task UpdateAsync(UpdateSubmissionDTO dto);
    Task DeleteAsync(int id);
}