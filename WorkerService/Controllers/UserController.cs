using Api.Users;
using Grpc.Core;
using MediatR;
using WorkerService.Core.Features.Users.Commands;
using WorkerService.Core.Features.Users.Queries;

namespace WorkerService.Controllers
{
    public class UserController : UsersGrpc.UsersGrpcBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public override async Task<CreateUserReply> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var user = await _mediator.Send(new CreateUserCommand( new User
            {
                Id = request.User.Id,
                Email = request.User.Email,
                Name = request.User.Name, 
                Password = request.User.Password
            }));

            return await Task.FromResult(new CreateUserReply());
        }

        public override async Task<GetUserByIdReply> GetUserById(GetUserByIdRequest request, ServerCallContext context)
        {
            return new GetUserByIdReply() { User = await _mediator.Send(new GetUserByIdQuery(request.Id)) };
        }
    }
}
