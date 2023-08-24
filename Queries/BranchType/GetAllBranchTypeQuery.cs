using MediatR;

namespace ElkoodTask.Queries;

public class GetAllBranchTypeQuery : IRequest<IEnumerable<BranchType>>
{
    
}