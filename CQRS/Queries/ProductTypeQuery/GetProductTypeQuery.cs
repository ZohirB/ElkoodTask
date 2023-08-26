using MediatR;

namespace ElkoodTask.CQRS.Queries.ProductTypeQuery;

public class GetProductTypeQuery : IRequest<IEnumerable<ProductType>>
{
}