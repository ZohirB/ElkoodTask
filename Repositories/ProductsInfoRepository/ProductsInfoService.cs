using ElkoodTask.CQRS.ProductInfo.Commands.Create;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Repositories.ProductsInfoRepository;

public class ProductsInfoService : IProductsInfoService
{
    private readonly ApplicationDbContext _context;

    public ProductsInfoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDetailsDto>> GetAllProductsInfo()
    {
        var productsInfo = await _context.ProductInfo
            .Include(pi => pi.ProductType)
            .Select(pi => new ProductDetailsDto
            {
                Id = pi.Id,
                Name = pi.Name,
                ProductTypeName = pi.ProductType.Name
            })
            .ToListAsync();
        return productsInfo;
    }

    public async Task<ProductInfo> CreateProductsInfo(CreateProductInfoCommand dto)
    {
        var productInfo = new ProductInfo
        {
            Name = dto.Name,
            ProductTypeId = dto.ProductTypeId
        };
        _context.Add(productInfo);
        await _context.SaveChangesAsync();
        return productInfo;
    }

    public Task<bool> IsValidProductType(int productTypeId)
    {
        return _context.ProductTypes.AnyAsync(pi => pi.Id == productTypeId);
    }
}