using MediatR;

namespace ElkoodTask.CQRS.Queries.BranchInfoQuery;

public class GetAllBranchInfoQuery : IRequest<IEnumerable<BranchDetailsDto>>
{
}