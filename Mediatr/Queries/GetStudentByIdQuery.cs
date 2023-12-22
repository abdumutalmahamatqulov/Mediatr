using Mediatr.Domains;
using MediatR;

namespace Mediator.Queries;

public class GetStudentByIdQuery : IRequest<StudentDetails>
{
    public int Id { get; set; }
}
