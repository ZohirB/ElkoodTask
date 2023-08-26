using ElkoodTask.CQRS.Command.ProductInfoCommand;
using ElkoodTask.Repositories.ProductsInfoRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductInfoHandler;

public class CreateProductInfoHandler : IRequestHandler<CreateProductInfoCommand, ProductInfo>
{
    private readonly IProductsInfoService _productsInfoService;

    public CreateProductInfoHandler(IProductsInfoService productsInfoService)
    {
        _productsInfoService = productsInfoService;
    }

    public async Task<ProductInfo> Handle(CreateProductInfoCommand request, CancellationToken cancellationToken)
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