using Api.Users;
using MediatR;

namespace gRPCServer.Core.Application.Features.Users.Commands
{
    public record class GetUserAllCommand : IRequest<IEnumerable<User>>
    {

    }
}
