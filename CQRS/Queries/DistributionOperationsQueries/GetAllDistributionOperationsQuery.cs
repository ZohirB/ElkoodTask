using MediatR;

namespace ElkoodTask.CQRS.Queries.DistributionOperationsQueries;

public class GetAllDistributionOperationsQuery : IRequest<IEnumerable<DistrubutionDetailsDto>>
{
}