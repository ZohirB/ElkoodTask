using MediatR;

namespace ElkoodTask.CQRS.BranchInfo.Queries.GetAll;

public class GetAllBranchInfoQuery : IRequest<IEnumerable<BranchDetailsDto>>
{
}