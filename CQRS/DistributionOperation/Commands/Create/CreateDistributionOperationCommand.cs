﻿using Elkood.Application.OperationResponses;
using MediatR;

namespace ElkoodTask.CQRS.DistributionOperation.Commands.Create;

public class CreateDistributionOperationCommand : IRequest<OperationResponse<ElkoodTask.Models.DistributionOperation>>
{
    public int PrimaryBranchInfoId { get; set; }
    public int SecondaryBranchInfoId { get; set; }
    public int ProductInfoId { get; set; }
    public int quantity { get; set; }
    public DateTime date { get; set; }
}