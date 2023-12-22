using Mediator.Domains;
using Mediator.Interface;
using Mediator.Queries;
using MediatR;

namespace Mediator.Handlers.UserHandler;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDetail>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
        => _userRepository = userRepository;



    public async Task<UserDetail> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        => await _userRepository.GetUserByIdAsync(query.Id);
}
