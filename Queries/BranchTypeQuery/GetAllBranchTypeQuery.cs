using MediatR;

namespace ElkoodTask.Queries.BranchTypeQuery;

public class GetAllBranchTypeQuery : IRequest<IEnumerable<BranchType>>
{
    
}