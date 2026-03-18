using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface ISaleService
{
    Task<IEnumerable<SaleDTO>> GetAllAsync();
}