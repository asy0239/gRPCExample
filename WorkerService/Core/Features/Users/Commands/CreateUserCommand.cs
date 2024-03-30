using Api.Users;
using LanguageExt;
using MediatR;

namespace WorkerService.Core.Features.Users.Commands
{
    public record class CreateUserCommand : IRequest<Option<User>>
    {
        public Option<User> User { get; set; }

        public CreateUserCommand(Option<User> user)
        {
            User = user;                        
        }
    }
}
