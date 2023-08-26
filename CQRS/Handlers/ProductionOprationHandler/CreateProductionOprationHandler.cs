using Elkood.Application.OperationResponses;
using Elkood.Domain.Exceptions;
using Elkood.Domain.Exceptions.Http;
using ElkoodTask.CQRS.Command.ProductionOprationCommand;
using ElkoodTask.Repositories.ProductionOperationRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductionOprationHandler;

public class
    CreateProductionOprationHandler : IRequestHandler<CreateProductionOprationCommand,
        OperationResponse<ProductionOperation>>
{
    private readonly IProductionOperationService _productionOperationService;

    public CreateProductionOprationHandler(IProductionOperationService productionOperationService)
    {
        _productionOperationService = productionOperationService;
    }

    public async Task<OperationResponse<ProductionOperation>> Handle(CreateProductionOprationCommand request,
        CancellationToken cancellationToken)
    {
        var isValidBranchInfo =
            await _productionOperationService.IsValidBranchInfo(request.BranchInfoId);
        var isValidProductInfo =
            await _productionOperationService.IsValidProductInfo(request.ProductInfoId);
        var isValidBranchType =
            await _productionOperationService.IsValidBranchType(request.BranchInfoId);

        if (!isValidBranchInfo) return new HttpMessage("Invalid Branch Info ID", HttpStatusCode.BadRequest400);
        if (!isValidProductInfo) return new HttpMessage("Invalid Product Info ID", HttpStatusCode.BadRequest400);
        if (!isValidBranchType)
            return new HttpMessage("Invalid Branch Type ID... you can only USE ID:1 (Primary) for production",
                HttpStatusCode.BadRequest400);

        var productionOperation =
            await _productionOperationService.CreateProductionOperation(request);
        return productionOperation;
    }
}