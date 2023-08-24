namespace ElkoodTask.Repositories.ProductsProducedRepository;

public interface IProductsProducedService
{
    Task<List<ProductProducedDetailsDto>> GetAllProductsProduced(int primaryBranchId, DateTime fromDate, DateTime toDate);
    BranchInfo? IsValidPrimaryBranch(int primaryBranchId, string companyName);
}