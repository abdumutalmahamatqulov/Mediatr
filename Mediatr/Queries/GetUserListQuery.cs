using Mediator.Domains;
using MediatR;

namespace Mediator.Queries;

public class GetUserListQuery:IRequest<List<UserDetail>>
{
}
