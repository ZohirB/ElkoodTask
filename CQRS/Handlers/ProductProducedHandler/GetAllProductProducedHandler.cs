using ElkoodTask.CQRS.Queries.ProductProducedQuery;
using ElkoodTask.Repositories.ProductProducedRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.ProductProducedHandler;

public class GetAllProductProducedHandler : IRequestHandler<GetAllProductProducedQuery, List<ProductProducedDetailsDto>>
{
    private readonly IProductProducedService _productProducedService;

    public GetAllProductProducedHandler(IProductProducedService productProducedService)
    {
        _productProducedService = productProducedService;
    }

    public async Task<List<ProductProducedDetailsDto>> Handle(GetAllProductProducedQuery request,
        CancellationToken cancellationToken)
    {
        //TODO find solution for checking response Create Branch Info
        /*
        var isValidcompanyName = await _allProductProducedService.IsValidCompanyName(request.companyName);
        if (!isValidcompanyName)
        {
            return BadRequest(error: "Invalid Company Name");
        }
        */
        var productDetails =
            await _productProducedService.GetAllProductProduced(request.CompanyName, request.StartDate,
                request.EndDate);
        /*
        if (!productDetails.Any())
        {
            return Content("There is no production recorded for the company between the entered date");
        }
        */
        return productDetails;
    }
}