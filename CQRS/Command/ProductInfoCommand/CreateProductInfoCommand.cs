using MediatR;

namespace ElkoodTask.CQRS.Command.ProductInfoCommand;

public class CreateProductInfoCommand : IRequest<ProductInfo>
{
    [MaxLength(100)] public string Name { get; set; }
    public int ProductTypeId { get; set; }
}