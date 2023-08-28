using MediatR;

namespace ElkoodTask.CQRS.BranchType.Commands.Create;

public class CreateBranchTypeCommand : IRequest<ElkoodTask.Models.BranchType>
{
    [MaxLength(100)] public string Name { get; set; }
}