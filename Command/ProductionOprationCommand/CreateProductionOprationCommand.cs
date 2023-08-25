using MediatR;

namespace ElkoodTask.Command.ProductionOprationCommand;

public class CreateProductionOprationCommand : IRequest<ProductionOperation>
{
    public int Id { get; set; }
    public int BranchInfoId { get; set; }
    public int ProductInfoId { get; set; }
    public int quantity { get; set; }
    public DateTime date { get; set; }
}