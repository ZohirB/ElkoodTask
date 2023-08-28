using MediatR;

namespace ElkoodTask.CQRS.DistributionOperation.Queries.GetAll;

public class GetAllDistributionOperationsQuery : IRequest<IEnumerable<DistrubutionDetailsDto>>
{
}