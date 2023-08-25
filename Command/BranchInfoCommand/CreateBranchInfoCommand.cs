using MediatR;

namespace ElkoodTask.Command.BranchInfoCommand;

public class CreateBranchInfoCommand : IRequest<BranchInfo>
{
    [MaxLength(length: 100)]
    public string Name { get; set; }

    public int BranchTypeId { get; set; }

    public int CompanyInfoId { get; set; }

    [MaxLength(length: 100)]
    public string Location { get; set; }
}