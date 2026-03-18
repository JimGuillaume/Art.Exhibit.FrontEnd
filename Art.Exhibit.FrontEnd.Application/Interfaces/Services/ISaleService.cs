using Art.Exhibit.FrontEnd.Application.DTOs;

public interface ISaleService
{
    Task<IEnumerable<SaleDTO>> GetAllAsync();
}