using ElkoodTask.CQRS.Command.ProductsInfoCommand;

namespace ElkoodTask.Repositories.ProductsInfoRepository;

public interface IProductsInfoService
{
    Task<List<ProductDetailsDto>> GetAllProductsInfo();
    Task<ProductInfo> CreateProductsInfo(CreateProductsInfoCommand dto);
    Task<bool> IsValidProductType(int productTypeId);
}