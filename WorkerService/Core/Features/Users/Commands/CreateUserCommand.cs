using Api.Users;
using MediatR;

namespace WorkerService.Core.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }

        public CreateUserCommand(User user)
        {
            User = user;                        
        }
    }
}
