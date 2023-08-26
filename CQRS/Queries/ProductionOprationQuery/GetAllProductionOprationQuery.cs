using MediatR;

namespace ElkoodTask.CQRS.Queries.ProductionOprationQuery;

public class GetAllProductionOprationQuery : IRequest<List<ProductionDetailsDto>>
{
}