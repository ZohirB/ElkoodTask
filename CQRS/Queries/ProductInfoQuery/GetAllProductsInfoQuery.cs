using MediatR;

namespace ElkoodTask.CQRS.Queries.ProductInfoQuery;

public class GetAllProductsInfoQuery : IRequest<List<ProductDetailsDto>>
{
}