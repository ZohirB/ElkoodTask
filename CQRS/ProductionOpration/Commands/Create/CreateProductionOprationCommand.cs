﻿using Elkood.Application.OperationResponses;
using MediatR;

namespace ElkoodTask.CQRS.ProductionOpration.Commands.Create;

public class CreateProductionOprationCommand : IRequest<OperationResponse<ProductionOperation>>
{
    public int BranchInfoId { get; set; }
    public int ProductInfoId { get; set; }
    public int quantity { get; set; }
    public DateTime date { get; set; }
}