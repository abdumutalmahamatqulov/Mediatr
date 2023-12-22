using MediatR;

namespace Mediator.Commands;

public class DeleteStudentCommand:IRequest<int>
{
    public int Id { get; set; }
}
