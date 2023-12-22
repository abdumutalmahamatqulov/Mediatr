using Mediator.Commands;
using Mediator.Interface;
using MediatR;

namespace Mediator.Handlers.UserHandler;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var userDetails = await _userRepository.GetUserByIdAsync(command.Id);
        userDetails.Id = command.Id;
        userDetails.UserName = command.Name;
        userDetails.Email = command.Email;
        userDetails.PasswordHash = command.Password;

        return await _userRepository.UpdateUserAsync(userDetails);
    }
}
