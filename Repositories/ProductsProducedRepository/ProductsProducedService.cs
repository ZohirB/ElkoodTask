namespace ElkoodTask.Repositories.ProductsProducedRepository;

public class ProductsProducedService : IProductsProducedService
{
    private ApplicationDbContext _context;

    public ProductsProducedService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductProducedDetailsDto>> GetAllProductsProduced(int primaryBranchId, DateTime fromDate, DateTime toDate)
    {
        var quantitiesByProductName = _context.ProductionOperations
            .Where(p => p.BranchInfoId == primaryBranchId && p.Date >= fromDate && p.Date <= toDate)
            .GroupBy(p => p.ProductInfo.Name)
            .Select(g => new  ProductProducedDetailsDto
            {
                ProductName = g.Key, 
                TotalQuantityProduced = g.Sum(p => p.Quantity)
            })
            .ToList();
        return quantitiesByProductName;
    }

    public BranchInfo? IsValidPrimaryBranch(int primaryBranchId, string companyName)
    {
        return _context.BranchInfo.FirstOrDefault(b => b.Id == primaryBranchId && b.CompanyInfo.Name.Equals(companyName) && b.BranchType.Name.Equals("Primary"));
    }
}