using Art.Exhibit.FrontEnd.Application.DTOs;

namespace Art.Exhibit.FrontEnd.Application.Interfaces.Services;

public interface ISaleService
{
    Task<IEnumerable<SaleDTO>> GetAllAsync();
    Task<SaleDTO?> GetByIdAsync(int id);
    Task CreateAsync(CreateSaleDTO dto);
    Task UpdateAsync(UpdateSaleDTO dto);
    Task DeleteAsync(int id);
}