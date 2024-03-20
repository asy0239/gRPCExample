using Api.Users;
using gRPCServer.Core.Application.Features.Users.Commands;
using gRPCServer.Services;
using MediatR;

namespace gRPCServer.Core.Application.Features.Users.Handlers
{
    public class GetUserAllCommandHandler : IRequestHandler<GetUserAllCommand, IEnumerable<User>>
    {
        private readonly RedisManagerService _managerService;
        public GetUserAllCommandHandler(RedisManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<IEnumerable<User>> Handle(GetUserAllCommand request, CancellationToken cancellationToken)
        {
            var users = await _managerService.GetAllUsers();
            return users;
        }
    }
}
