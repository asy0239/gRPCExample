using Api.Users;
using Grpc.Net.Client;

namespace gRPCClient.Controllers
{
    public class UserControl
    {
        private readonly GrpcChannel _channel;
        public UserControl(GrpcChannel channel) 
        {
            _channel = channel;
        }

        public async Task CreateUserAsync()
        {
            var client = new UsersGrpc.UsersGrpcClient(_channel);
            var newUser = new User()
            {
                Email = "asy0239@gmail.com",
                Id = 1,
                Name = "안성윤",
                Password = "1234"
            };

            var clientRequested = new CreateUserRequest { User = newUser };

            await client.CreateUserAsync(clientRequested);

            var clientGetUserRequest = new GetUserByIdRequest { Id = clientRequested.User.Id };
            var reply = await client.GetUserByIdAsync(clientGetUserRequest);

            Console.WriteLine($"{reply.User.Email} 저장 완료");
        }

        public async Task GetUserAsync(int key)
        {
            var client = new UsersGrpc.UsersGrpcClient(_channel);
            var clientRequested = new GetUserByIdRequest { Id = key };
            var user = await client.GetUserByIdAsync(clientRequested);

            Console.WriteLine($"ID = {user.User.Id}, Email = {user.User.Email}, Name = {user.User.Name}");
        }
    }
}
