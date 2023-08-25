using ElkoodTask.Queries.AllProductProducedQuery;
using ElkoodTask.Repositories.AllProductProducedRepository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ElkoodTask.Handlers.AllProductProducedHandler;

public class GetAllProductProducedHandler : IRequestHandler<GetAllProductProducedQuery, List<ProductProducedDetailsDto>>
{
    private readonly IAllProductProducedService _allProductProducedService;

    public GetAllProductProducedHandler(IAllProductProducedService allProductProducedService)
    {
        _allProductProducedService = allProductProducedService;
    }

    public async Task<List<ProductProducedDetailsDto>> Handle(GetAllProductProducedQuery request, CancellationToken cancellationToken)
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
            await _allProductProducedService.GetAllProductProduced(request.CompanyName, request.StartDate, request.EndDate);
        /*
        if (!productDetails.Any())
        {
            return Content("There is no production recorded for the company between the entered date");
        }
        */
        return productDetails;
    }
}