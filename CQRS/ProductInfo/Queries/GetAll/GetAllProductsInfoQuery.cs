using MediatR;

namespace ElkoodTask.CQRS.ProductInfo.Queries.GetAll;

public class GetAllProductsInfoQuery : IRequest<List<ProductDetailsDto>>
{
}