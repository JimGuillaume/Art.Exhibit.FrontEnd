using Art.Exhibit.FrontEnd.Application.DTOs;

public interface ISubmissionService
{
    Task<IEnumerable<SubmissionDTO>> GetAllAsync();
    Task CreateAsync(CreateSubmissionDTO dto);
}