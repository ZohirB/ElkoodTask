using MediatR;

namespace ElkoodTask.Queries;

public class AddBranchTypeQuery : IRequest<BranchType>
{
    public CreateBranchTypeCommand Command;
    public AddBranchTypeQuery(CreateBranchTypeCommand command)
    {
        Command = command;
    }
}