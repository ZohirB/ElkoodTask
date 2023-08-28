using Elkood.Application.OperationResponses;
using Elkood.Domain.Exceptions;
using Elkood.Domain.Exceptions.Http;
using ElkoodTask.Repositories.ProductProducedRepository;
using MediatR;

namespace ElkoodTask.CQRS.ProductProduced.Queries.GetAll;

public class GetAllProductProducedHandler : IRequestHandler<GetAllProductProducedQuery,
    OperationResponse<List<ProductProducedDetailsDto>>>
{
    private readonly IProductProducedService _productProducedService;

    public GetAllProductProducedHandler(IProductProducedService productProducedService)
    {
        _productProducedService = productProducedService;
    }

    public async Task<OperationResponse<List<ProductProducedDetailsDto>>> Handle(GetAllProductProducedQuery request,
        CancellationToken cancellationToken)
    {
        var isValidcompanyName = await _productProducedService.IsValidCompanyName(request.CompanyName);
        if (!isValidcompanyName) return new HttpMessage("Invalid Company Name", HttpStatusCode.BadRequest400);

        var productDetails =
            await _productProducedService.GetAllProductProduced(request.CompanyName, request.StartDate,
                request.EndDate);

        if (!productDetails.Any())
            return new HttpMessage("There is no production recorded for the company between the entered date",
                HttpStatusCode.NoContent204);
        return productDetails;
    }
}