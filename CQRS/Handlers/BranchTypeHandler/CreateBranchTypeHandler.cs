﻿using ElkoodTask.CQRS.Command.BranchTypeCommand;
using ElkoodTask.Repositories.BranchTypeRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.BranchTypeHandler;

public class CreateBranchTypeHandler : IRequestHandler<CreateBranchTypeCommand, BranchType>
{
    private readonly IBranchTypesService _branchTypesService;

    public CreateBranchTypeHandler(IBranchTypesService branchTypesService)
    {
        _branchTypesService = branchTypesService;
    }

    public async Task<BranchType> Handle(CreateBranchTypeCommand request, CancellationToken cancellationToken)
    {
        var branchType = new BranchType { Name = request.Name };
        await _branchTypesService.CreateBranchType(branchType);
        return branchType;
    }
}