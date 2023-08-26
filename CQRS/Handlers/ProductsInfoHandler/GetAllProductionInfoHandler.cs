using ElkoodTask.CQRS.Queries.ProductsInfoQuery;
using ElkoodTask.Repositories.ProductsInfoRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductsInfoHandler;

public class GetAllProductionInfoHandler : IRequestHandler<GetAllProductsInfoQuery, List<ProductDetailsDto>>
{
    private readonly IProductsInfoService _productsInfoService;

    public GetAllProductionInfoHandler(IProductsInfoService productsInfoService)
    {
        _productsInfoService = productsInfoService;
    }

    public async Task<List<ProductDetailsDto>> Handle(GetAllProductsInfoQuery request,
        CancellationToken cancellationToken)
    {
        var productsInfo = await _productsInfoService.GetAllProductsInfo();
        return productsInfo;
    }
}