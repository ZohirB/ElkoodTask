using MediatR;

namespace ElkoodTask.CQRS.ProductionOpration.Queries.GetAll;

public class GetAllProductionOprationQuery : IRequest<List<ProductionDetailsDto>>
{
}