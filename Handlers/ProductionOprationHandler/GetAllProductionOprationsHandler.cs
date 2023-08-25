using ElkoodTask.Queries.ProductionOprationQuery;
using ElkoodTask.Repositories.ProductionOperationRepository;
using MediatR;

namespace ElkoodTask.Handlers.ProductionOprationHandler;

public class GetAllProductionOprationsHandler : IRequestHandler<GetAllProductionOprationQuery, List<ProductionDetailsDto>>
{
    private readonly IProductionOperationService _productionOperationService;

    public GetAllProductionOprationsHandler(IProductionOperationService productionOperationService)
    {
        _productionOperationService = productionOperationService;
    }

    public async Task<List<ProductionDetailsDto>> Handle(GetAllProductionOprationQuery request, CancellationToken cancellationToken)
    {
        var productionOperations = await _productionOperationService.GetAllProductionOperations();
        return productionOperations;
    }
}