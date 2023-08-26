using ElkoodTask.CQRS.Command.BranchInfoCommand;
using ElkoodTask.Repositories.BranchInfoRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.BranchInfoHandler;

public class CreateBranchInfoHandler : IRequestHandler<CreateBranchInfoCommand, BranchInfo>
{
    private readonly IBranchesInfoService _branchesInfoService;

    public CreateBranchInfoHandler(IBranchesInfoService branchesInfoService)
    {
        _branchesInfoService = branchesInfoService;
    }

    public async Task<BranchInfo> Handle(CreateBranchInfoCommand request, CancellationToken cancellationToken)
    {
        //TODO find solution for checking response Create Branch Info
        var isValidBranchType = await _branchesInfoService.IsValidBranchType(request.BranchTypeId);
        var isValidCompanyInfo = await _branchesInfoService.IsValidCompanyInfo(request.CompanyInfoId);

        var result = await _branchesInfoService.CreateBranchInfo(request);
        return result;

        /*
        if (!isValidBranchType) 
        {
            return BadRequest(error: "Invalid Branch Type ID");
        }
        if (!isValidCompanyInfo)
        {
            return BadRequest(error: "Invalid Company Info ID");
        }
        else
        {
            var result = await _branchesInfoService.CreateBranchInfo(request);
            return result;
        }
        */
    }
}