using ElkoodTask.Repositories.ProductTypeRepository;
using MediatR;

namespace ElkoodTask.CQRS.ProductType.Commands.Create;

public class CreateProductTypeHandler : IRequestHandler<CreateProductTypeCommand, ElkoodTask.Models.ProductType>
{
    private readonly IProductTypesService productTypesService;

    public CreateProductTypeHandler(IProductTypesService productTypesService)
    {
        this.productTypesService = productTypesService;
    }

    public async Task<ElkoodTask.Models.ProductType> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
        var productType = new ElkoodTask.Models.ProductType { Name = request.Name };
        await productTypesService.CreateProductType(productType);
        return productType;
    }
}