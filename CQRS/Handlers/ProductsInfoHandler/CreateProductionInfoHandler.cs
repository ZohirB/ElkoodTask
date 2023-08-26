using ElkoodTask.CQRS.Command.ProductsInfoCommand;
using ElkoodTask.Repositories.ProductsInfoRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductsInfoHandler;

public class CreateProductionInfoHandler : IRequestHandler<CreateProductsInfoCommand, ProductInfo>
{
    private readonly IProductsInfoService _productsInfoService;

    public CreateProductionInfoHandler(IProductsInfoService productsInfoService)
    {
        _productsInfoService = productsInfoService;
    }

    public async Task<ProductInfo> Handle(CreateProductsInfoCommand request, CancellationToken cancellationToken)
    {
        //TODO find solution for checking response Create Create new Products Info

        /*
        var isValidProductType = await _productsInfoService.IsValidProductType(productInfoDto.ProductTypeId);
        if (!isValidProductType)
        {
            return BadRequest(error: "Invalid Product Type ID");
        }
        */
        var productInfo = await _productsInfoService.CreateProductsInfo(request);
        return productInfo;
    }
}