using MediatR;

namespace ElkoodTask.CQRS.ProductType.Queries.GetAll;

public class GetProductTypeQuery : IRequest<IEnumerable<ElkoodTask.Models.ProductType>>
{
}