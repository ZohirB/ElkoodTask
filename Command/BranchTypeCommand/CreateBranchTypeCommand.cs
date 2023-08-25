using MediatR;

namespace ElkoodTask.Command.BranchTypeCommand
{
    public class CreateBranchTypeCommand : IRequest<BranchType>
    {
        [MaxLength(length: 100)]
        public string Name { get; set; }
    }
}
