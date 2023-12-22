using MediatR;

namespace Mediator.Commands;

public class DeleteUserCommand:IRequest<int>
{
    public string Id { get; set; }
}
