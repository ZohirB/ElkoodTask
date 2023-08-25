using MediatR;

namespace ElkoodTask.Queries.CompanyInfoQuery;

public class GetAllBranchInfoQuery : IRequest<IEnumerable<BranchDetailsDto>>
{
    
}