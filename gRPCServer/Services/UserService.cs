using Api.Users;
using Grpc.Core;
using gRPCServer.Core.Application.Features.Users.Commands;
using MediatR;

namespace gRPCServer.Services
{
    public class UserService : UsersGrpc.UsersGrpcBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMediator _mediator;
        public UserService(ILogger<UserService> logger, IMediator mediator) 
        {
            _logger = logger;
            _mediator = mediator;
        }

        public override async Task<CreateUserReply> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            return new CreateUserReply() { User = await _mediator.Send(new AddUserCommand(request.User)) };
        }

        public override async Task<GetAllUsersReply> GetAllUsers(GetAllUsersRequest request, ServerCallContext context)
        {
            return new GetAllUsersReply() { Users = await _mediator.Send(new GetUserAllCommand())};
        }
    }
}
