using Elkood.Application.OperationResponses;
using MediatR;

namespace ElkoodTask.CQRS.ProductProduced.Queries.GetAll;

public class GetAllProductProducedQuery : IRequest<OperationResponse<List<ProductProducedDetailsDto>>>
{
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}