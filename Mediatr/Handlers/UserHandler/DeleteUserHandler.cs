using Mediator.Commands;
using Mediator.Interface;
using MediatR;

namespace Mediator.Handlers.UserHandler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _userRepository.GetUserByIdAsync(command.Id);
            if (studentDetails == null)
                return default;

            return await _userRepository.DeleteUserAsync(studentDetails.Id);
        }
    }
}
