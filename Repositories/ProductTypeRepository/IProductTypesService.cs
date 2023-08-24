namespace ElkoodTask.Repositories.ProductTypeRepository
{
    public interface IProductTypesService
    {
        Task<IEnumerable<ProductType>> GetAllProductTypes();
        Task<ProductType> GetProductTypeById(int id);
        Task<ProductType> CreateProductType(ProductType productType);
        ProductType UpdateProductType(ProductType productType);
        ProductType DeleteProductType(ProductType productType);
    }
}
