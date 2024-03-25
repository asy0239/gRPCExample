using Api.Users;
using gRPCServer.Core.Application.Features.Users.Commands;
using gRPCServer.Services;
using MediatR;

namespace gRPCServer.Core.Application.Features.Users.Handlers
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, User>
    {
        RedisManagerService _managerService;
        public GetUserCommandHandler(RedisManagerService service)
        {
            _managerService = service;
        }

        public Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return _managerService.GetUserAsync(request.Key);
        }
    }
}
