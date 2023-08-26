using MediatR;

namespace ElkoodTask.CQRS.Queries.BranchTypeQuery;

public class GetAllBranchTypeQuery : IRequest<IEnumerable<BranchType>>
{
}