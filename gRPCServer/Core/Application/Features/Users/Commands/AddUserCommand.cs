using Api.Users;
using MediatR;

namespace gRPCServer.Core.Application.Features.Users.Commands
{
    public class AddUserCommand : IRequest<User>
    {
        public User RequestUser { get; }
        public AddUserCommand(User user) 
        {
            RequestUser = user;
        }
    }
}
