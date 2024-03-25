using Api.Users;
using MediatR;

namespace gRPCServer.Core.Application.Features.Users.Commands
{
    public class GetUserCommand : IRequest<User>
    {
        public long Key { get; }
        public GetUserCommand(long key)
        {
            Key = key;
        }
    }
}
