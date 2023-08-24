namespace ElkoodTask.Repositories.ProductsInfoRepository;

public interface IProductsInfoService
{ 
    Task<List<ProductDetailsDto>> GetAllProductsInfo();
    Task<ProductInfo> CreateProductsInfo(ProductInfoDto dto);
    Task<bool> IsValidProductType(int productTypeId);
}