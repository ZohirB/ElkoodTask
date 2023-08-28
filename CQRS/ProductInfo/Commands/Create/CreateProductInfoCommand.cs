using Elkood.Application.OperationResponses;
using MediatR;

namespace ElkoodTask.CQRS.ProductInfo.Commands.Create;

public class CreateProductInfoCommand : IRequest<OperationResponse<Models.ProductInfo>>
{
    [MaxLength(100)] public string Name { get; set; }
    public int ProductTypeId { get; set; }
}