using Mediator.Domains;
using Mediator.Interface;
using Mediator.Queries;
using MediatR;

namespace Mediator.Handlers.UserHandler;

public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<UserDetail>>
{
    private readonly IUserRepository _userRepository;



    public GetUserListHandler(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<List<UserDetail>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        => await _userRepository.GetUserListAsync();
}
