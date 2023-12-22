using Mediator.Domains;
using MediatR;

namespace Mediator.Queries
{
    public class GetUserByIdQuery:IRequest<UserDetail>
    {
        public string Id { get; set; }
    }
}
