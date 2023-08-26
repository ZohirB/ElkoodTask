using MediatR;

namespace ElkoodTask.CQRS.Command.ProductsInfoCommand;

public class CreateProductsInfoCommand : IRequest<ProductInfo>
{
    [MaxLength(100)] public string Name { get; set; }

    public int ProductTypeId { get; set; }
}