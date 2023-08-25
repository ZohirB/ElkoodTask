using MediatR;

namespace ElkoodTask.Queries.AllProductProducedQuery;

public class GetAllProductProducedQuery : IRequest<List<ProductProducedDetailsDto>>
{
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}