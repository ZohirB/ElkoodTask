using ElkoodTask.Repositories.BranchTypeRepository;
using MediatR;

namespace ElkoodTask.CQRS.BranchType.Queries.GetAll;

public class GetAllBranchTypeHandler : IRequestHandler<GetAllBranchTypeQuery, IEnumerable<ElkoodTask.Models.BranchType>>
{
    private readonly IBranchTypesService _branchTypesService;

    public GetAllBranchTypeHandler(IBranchTypesService branchTypesService)
    {
        _branchTypesService = branchTypesService;
    }

    public async Task<IEnumerable<ElkoodTask.Models.BranchType>> Handle(GetAllBranchTypeQuery request,
        CancellationToken cancellationToken)
    {
        var branchTypes = await _branchTypesService.GetAllBranchType();
        return branchTypes;
    }
}