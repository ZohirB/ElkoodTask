using MediatR;

namespace ElkoodTask.CQRS.Queries.ProductProducedQuery;

public class GetAllProductProducedQuery : IRequest<List<ProductProducedDetailsDto>>
{
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}