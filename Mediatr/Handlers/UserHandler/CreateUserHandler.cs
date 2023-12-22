using Mediator.Commands;
using Mediator.Domains;
using Mediator.Interface;
using MediatR;

namespace Mediator.Handlers.UserHandler;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDetail>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository) => _userRepository = userRepository ??
        throw new ArgumentNullException(nameof(userRepository));

    public async Task<UserDetail> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userDetails = new UserDetail()
        {
            UserName = command.Name,
            Email = command.Email,
            PasswordHash = command.Password,
        };
        return await _userRepository.AddUserAsync(userDetails);
    }
}
