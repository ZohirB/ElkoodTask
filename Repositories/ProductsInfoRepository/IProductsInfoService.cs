using ElkoodTask.CQRS.ProductInfo.Commands.Create;

namespace ElkoodTask.Repositories.ProductsInfoRepository;

public interface IProductsInfoService
{
    Task<List<ProductDetailsDto>> GetAllProductsInfo();
    Task<ProductInfo> CreateProductsInfo(CreateProductInfoCommand dto);
    Task<bool> IsValidProductType(int productTypeId);
}