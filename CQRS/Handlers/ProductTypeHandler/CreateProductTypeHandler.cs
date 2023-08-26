using ElkoodTask.CQRS.Command.ProductTypeCommand;
using ElkoodTask.Repositories.ProductTypeRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductTypeHandler;

public class CreateProductTypeHandler : IRequestHandler<CreateProductTypeCommand, ProductType>
{
    private readonly IProductTypesService productTypesService;

    public CreateProductTypeHandler(IProductTypesService productTypesService)
    {
        this.productTypesService = productTypesService;
    }

    public async Task<ProductType> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
        var productType = new ProductType { Name = request.Name };
        await productTypesService.CreateProductType(productType);
        return productType;
    }
}