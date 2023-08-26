using ElkoodTask.CQRS.Command.DistributionOperationCommand;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Repositories.DistributionOperationRepository;

public class DistributionOperationService : IDistributionOperationService
{
    private readonly ApplicationDbContext _context;

    public DistributionOperationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DistrubutionDetailsDto>> GetAllDistributionOperation()
    {
        var distributionOperation = await _context.DistributionOperations
            .Include(dio => dio.ProductInfo)
            .Select(dio => new DistrubutionDetailsDto
            {
                Id = dio.Id,
                PrimaryBranchInfoName = dio.PrimaryBranchInfo.Name,
                SecondaryBranchInfoName = dio.SecondaryBranchInfo.Name,
                ProductInfoName = dio.ProductInfo.Name,
                Quantity = dio.Quantity,
                Date = dio.Date
            })
            .ToListAsync();
        return distributionOperation;
    }

    public async void CreateDistributionOperation(CreateDistributionOperationCommand distrubutionOperationDto)
    {
        var distribution = new DistributionOperation
        {
            PrimaryBranchInfoId = distrubutionOperationDto.PrimaryBranchInfoId,
            SecondaryBranchInfoId = distrubutionOperationDto.SecondaryBranchInfoId,
            ProductInfoId = distrubutionOperationDto.ProductInfoId,
            Quantity = distrubutionOperationDto.quantity,
            Date = distrubutionOperationDto.date
        };
        _context.DistributionOperations.Add(distribution);
        var remainingQuantityToUpdate = distrubutionOperationDto.quantity;
        var productionOperations = await _context.ProductionOperations
            .Where(po =>
                po.BranchInfoId == distrubutionOperationDto.PrimaryBranchInfoId &&
                po.ProductInfoId == distrubutionOperationDto.ProductInfoId)
            .OrderBy(po => po.Date)
            .ToListAsync();
        foreach (var production in productionOperations)
        {
            if (remainingQuantityToUpdate <= 0) break;
            var quantityToUpdate = Math.Min(remainingQuantityToUpdate, production.RemainingQuantity);
            production.RemainingQuantity -= quantityToUpdate;
            remainingQuantityToUpdate -= quantityToUpdate;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<int> TotalRemainingQuantity(CreateDistributionOperationCommand distrubutionOperationDto)
    {
        var totalRemainingQuantity = await _context.ProductionOperations
            .Where(po =>
                po.BranchInfoId == distrubutionOperationDto.PrimaryBranchInfoId &&
                po.ProductInfoId == distrubutionOperationDto.ProductInfoId)
            .SumAsync(po => po.RemainingQuantity);
        return totalRemainingQuantity;
    }

    public async Task<bool> IsValidPrimaryBranchTypeTask(CreateDistributionOperationCommand distrubutionOperationDto)
    {
        var isValidPrimaryBranchType = await _context.BranchInfo
            .Where(bt => bt.BranchTypeId == 1)
            .AnyAsync(bt => bt.Id == distrubutionOperationDto.PrimaryBranchInfoId);
        return isValidPrimaryBranchType;
    }

    public async Task<bool> IsValidSecondaryBranchType(CreateDistributionOperationCommand distrubutionOperationDto)
    {
        var isValidSecondaryBranchType = await _context.BranchInfo
            .Where(bt => bt.BranchTypeId == 2)
            .AnyAsync(bt => bt.Id == distrubutionOperationDto.SecondaryBranchInfoId);
        return isValidSecondaryBranchType;
    }
}