using MediatR;

namespace ElkoodTask.CQRS.BranchType.Queries.GetAll;

public class GetAllBranchTypeQuery : IRequest<IEnumerable<ElkoodTask.Models.BranchType>>
{
}