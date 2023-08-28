using MediatR;

namespace ElkoodTask.CQRS.ProductType.Commands.Create;

public class CreateProductTypeCommand : IRequest<ElkoodTask.Models.ProductType>
{
    [MaxLength(100)] public string Name { get; set; }
}