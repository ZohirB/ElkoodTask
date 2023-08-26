using MediatR;

namespace ElkoodTask.CQRS.Command.ProductionOprationCommand;

public class CreateProductionOprationCommand : IRequest<ProductionOperation>
{
    public int BranchInfoId { get; set; }
    public int ProductInfoId { get; set; }
    public int quantity { get; set; }
    public DateTime date { get; set; }
}