using ElkoodTask.Command.ProductionOprationCommand;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Repositories.ProductionOperationRepository;

public class ProductionOperationsService : IProductionOperationService
{
    private readonly ApplicationDbContext _context;

    public ProductionOperationsService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProductionDetailsDto>> GetAllProductionOperations()
    {
        var productionOperations = await _context.ProductionOperations
            .Include(po => po.ProductInfo)
            .Select(po => new ProductionDetailsDto
            {
                Id = po.Id,
                BranchInfoName = po.BranchInfo.Name,
                ProductInfoName = po.ProductInfo.Name, 
                quantity = po.Quantity,
                RemainingQuantity = po.RemainingQuantity,  
                date = po.Date
            })
            .ToListAsync();
        return productionOperations;
    }

    public async Task<ProductionOperation> CreateProductionOperation(CreateProductionOprationCommand productionOprerationDto)
    {
        var productionOperation = new ProductionOperation
        {
            ProductInfoId = productionOprerationDto.ProductInfoId,
            BranchInfoId = productionOprerationDto.BranchInfoId,
            Quantity = productionOprerationDto.quantity,
            Date = productionOprerationDto.date
        };
        _context.Add(productionOperation);
        await _context.SaveChangesAsync();
        return productionOperation;
    }

    public async Task<bool> IsValidBranchInfo(int branchInfoId)
    {
        return await _context.BranchInfo.AnyAsync(bi => bi.Id == branchInfoId);
    }

    public async Task<bool> IsValidProductInfo(int productInfoId)
    {
        return await _context.ProductInfo.AnyAsync(pi => pi.Id == productInfoId);
    }

    public async Task<bool> IsValidBranchType(int branchInfoId)
    {
        var isValidBranchType = await _context.BranchInfo
            .Where(bi => bi.BranchTypeId == 1)
            .AnyAsync(bi => bi.Id == branchInfoId);
        return isValidBranchType;
    }
}