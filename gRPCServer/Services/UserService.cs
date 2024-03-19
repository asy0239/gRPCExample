using Api.Users;
using Grpc.Core;

namespace gRPCServer.Services
{
    public class UserService : UsersGrpc.UsersGrpcBase
    {
        public UserService() { }

        public override Task<GetUserReply> GetUsers(GetUserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetUserReply() { Users = new User() { Email = "asy0239@gmail.com", Id = 1, Name = "안성윤"} });
        }
    }
}
