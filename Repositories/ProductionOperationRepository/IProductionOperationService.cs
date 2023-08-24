namespace ElkoodTask.Repositories.ProductionOperationRepository;

public interface IProductionOperationService
{
    Task<List<ProductionDetailsDto>> GetAllProductionOperations();
    Task<ProductionOperation> CreateProductionOperation(ProductionOprerationDto productionOprerationDto);
    Task<bool> IsValidBranchInfo(int branchInfoId);
    Task<bool> IsValidProductInfo(int productInfoId);
    Task<bool> IsValidBranchType(int branchInfoId);
}