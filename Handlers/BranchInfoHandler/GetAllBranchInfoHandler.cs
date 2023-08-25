using ElkoodTask.Queries.CompanyInfoQuery;
using ElkoodTask.Repositories.BranchInfoRepository;
using MediatR;

namespace ElkoodTask.Handlers.CompanyInfoHandler;

public class GetAllBranchInfoHandler : IRequestHandler<GetAllBranchInfoQuery, IEnumerable<BranchDetailsDto>>
{
    private readonly IBranchesInfoService _branchesInfoService;

    public GetAllBranchInfoHandler(IBranchesInfoService branchesInfoService)
    {
        _branchesInfoService = branchesInfoService;
    }

    public async Task<IEnumerable<BranchDetailsDto>> Handle(GetAllBranchInfoQuery request, CancellationToken cancellationToken)
    {
        var branchInfo = await _branchesInfoService.GetAllBranchInfo();
        return branchInfo;
    }
}