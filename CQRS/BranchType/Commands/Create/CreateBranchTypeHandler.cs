using ElkoodTask.Repositories.BranchTypeRepository;
using MediatR;

namespace ElkoodTask.CQRS.BranchType.Commands.Create;

public class CreateBranchTypeHandler : IRequestHandler<CreateBranchTypeCommand, ElkoodTask.Models.BranchType>
{
    private readonly IBranchTypesService _branchTypesService;

    public CreateBranchTypeHandler(IBranchTypesService branchTypesService)
    {
        _branchTypesService = branchTypesService;
    }

    public async Task<ElkoodTask.Models.BranchType> Handle(CreateBranchTypeCommand request, CancellationToken cancellationToken)
    {
        var branchType = new ElkoodTask.Models.BranchType { Name = request.Name };
        await _branchTypesService.CreateBranchType(branchType);
        return branchType;
    }
}