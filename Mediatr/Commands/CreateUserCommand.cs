using Mediator.Domains;
using MediatR;

namespace Mediator.Commands
{
    public class CreateUserCommand:IRequest<UserDetail>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ERole Role { get; set; }
        public CreateUserCommand(string name, string email, string password, ERole role)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}
