using MediatR;

namespace ElkoodTask.Dtos
{
    public class CreateBranchTypeCommand : IRequest<BranchType>
    {
        [MaxLength(length: 100)]
        public string Name { get; set; }
    }
}
