using Api.Users;
using gRPCServer.Services;
using MediatR;

namespace gRPCServer.Core.Application.Features.Users.Commands
{
    public record class AddUserCommand : IRequest<User>
    {
        public User RequestUser { get; }
        public AddUserCommand(User user) 
        {
            RequestUser = user;
        }
    }
}
