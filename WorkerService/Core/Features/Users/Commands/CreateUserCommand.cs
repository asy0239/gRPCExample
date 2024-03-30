using Api.Users;
using MediatR;

namespace WorkerService.Core.Features.Users.Commands
{
    public record class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }

        public CreateUserCommand(User user)
        {
            User = user;                        
        }
    }
}
