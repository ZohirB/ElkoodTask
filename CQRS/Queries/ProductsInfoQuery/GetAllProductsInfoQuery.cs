using MediatR;

namespace ElkoodTask.CQRS.Queries.ProductsInfoQuery;

public class GetAllProductsInfoQuery : IRequest<List<ProductDetailsDto>>
{
}