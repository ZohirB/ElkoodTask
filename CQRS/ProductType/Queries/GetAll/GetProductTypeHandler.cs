using ElkoodTask.Repositories.ProductTypeRepository;
using MediatR;

namespace ElkoodTask.CQRS.ProductType.Queries.GetAll;

public class GetProductTypeHandler : IRequestHandler<GetProductTypeQuery, IEnumerable<ElkoodTask.Models.ProductType>>
{
    private readonly IProductTypesService productTypesService;

    public GetProductTypeHandler(IProductTypesService productTypesService)
    {
        this.productTypesService = productTypesService;
    }

    public async Task<IEnumerable<ElkoodTask.Models.ProductType>> Handle(GetProductTypeQuery request, CancellationToken cancellationToken)
    {
        var productTypes = await productTypesService.GetAllProductTypes();
        return productTypes;
    }
}