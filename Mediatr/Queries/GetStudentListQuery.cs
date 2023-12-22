using Mediatr.Domains;
using MediatR;

namespace Mediator.Queries;

public class GetStudentListQuery:IRequest<List<StudentDetails>>
{
}
