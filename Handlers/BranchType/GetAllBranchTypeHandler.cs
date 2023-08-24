﻿using ElkoodTask.Queries;
using ElkoodTask.Servies;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ElkoodTask.Handlers;

public class GetAllBranchTypeHandler : IRequestHandler<GetAllBranchTypeQuery, IEnumerable<BranchType>>
{
    private readonly IBranchTypesService _branchTypesService;

    public GetAllBranchTypeHandler(IBranchTypesService branchTypesService)
    {
        _branchTypesService = branchTypesService;
    }

    public async Task<IEnumerable<BranchType>> Handle(GetAllBranchTypeQuery request, CancellationToken cancellationToken)
    {
        var branchTypes = await _branchTypesService.GetAllBranchType();
        return branchTypes;
    }
}