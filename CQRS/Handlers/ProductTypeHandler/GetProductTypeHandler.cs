using ElkoodTask.CQRS.Queries.ProductTypeQuery;
using ElkoodTask.Repositories.ProductTypeRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductTypeHandler;

public class GetProductTypeHandler : IRequestHandler<GetProductTypeQuery, IEnumerable<ProductType>>
{
    private readonly IProductTypesService productTypesService;

    public GetProductTypeHandler(IProductTypesService productTypesService)
    {
        this.productTypesService = productTypesService;
    }

    public async Task<IEnumerable<ProductType>> Handle(GetProductTypeQuery request, CancellationToken cancellationToken)
    {
        var productTypes = await productTypesService.GetAllProductTypes();
        return productTypes;
    }
}