using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Repositories.ProductProducedRepository;

public class ProductProducedService : IProductProducedService
{
    private readonly ApplicationDbContext _context;

    public ProductProducedService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductProducedDetailsDto>> GetAllProductProduced(string companyName, DateTime startDate,
        DateTime endDate)
    {
        var productDetails = await _context.ProductionOperations
            .Include(p => p.BranchInfo)
            .ThenInclude(b => b.CompanyInfo)
            .Include(p => p.ProductInfo)
            .Where(p => p.BranchInfo.CompanyInfo.Name == companyName &&
                        p.Date >= startDate &&
                        p.Date <= endDate)
            .GroupBy(p => p.ProductInfo.Name)
            .Select(g => new ProductProducedDetailsDto
            {
                ProductName = g.Key,
                TotalQuantityProduced = g.Sum(p => p.Quantity)
            })
            .ToListAsync();
        return productDetails;
    }

    public async Task<bool> IsValidCompanyName(string companyName)
    {
        return await _context.CompanyInfo.AnyAsync(ci => ci.Name == companyName);
    }
}