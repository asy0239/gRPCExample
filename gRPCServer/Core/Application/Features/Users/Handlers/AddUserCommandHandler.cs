using Api.Users;
using gRPCServer.Core.Application.Features.Users.Commands;
using gRPCServer.Services;
using MediatR;

namespace gRPCServer.Core.Application.Features.Users.Handlers
{

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly RedisManagerService _managerService;
        public AddUserCommandHandler(RedisManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _managerService.Push(request.RequestUser);

            return new User 
            { 
                Name = request.RequestUser.Name,
                Email = request.RequestUser.Email,
                Id = request.RequestUser.Id, 
                Password = request.RequestUser.Password 
            };
        }
    }
}
