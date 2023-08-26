using ElkoodTask.CQRS.Command.ProductionOprationCommand;
using ElkoodTask.Repositories.ProductionOperationRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductionOprationHandler;

public class CreateProductionOprationHandler : IRequestHandler<CreateProductionOprationCommand, ProductionOperation>
{
    private readonly IProductionOperationService _productionOperationService;

    public CreateProductionOprationHandler(IProductionOperationService productionOperationService)
    {
        _productionOperationService = productionOperationService;
    }

    public async Task<ProductionOperation> Handle(CreateProductionOprationCommand request,
        CancellationToken cancellationToken)
    {
        //TODO find solution for checking response Create Create new Production Operation

        /*
        var isValidBranchInfo =
            await _productionOperationService.IsValidBranchInfo(productionOprerationDto.BranchInfoId);
        var isValidProductInfo =
            await _productionOperationService.IsValidProductInfo(productionOprerationDto.ProductInfoId);
        var isValidBranchType =
            await _productionOperationService.IsValidBranchType(productionOprerationDto.BranchInfoId);
            
        if (!isValidBranchInfo)
        {
            return BadRequest(error: "Invalid Branch Info ID");
        }
        if (!isValidProductInfo)
        {
            return BadRequest(error: "Invalid Product Info ID");
        }
        if (!isValidBranchType)
        {
            return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:1 (Primary) for production");
        }
        */
        var productionOperation =
            await _productionOperationService.CreateProductionOperation(request);
        return productionOperation;
    }
}