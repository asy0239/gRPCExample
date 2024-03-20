using Api.Users;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var clientReply = new GetAllUsersRequest();
            var reply = await client.GetAllUsersAsync(clientReply);

            foreach (var user in reply.Users)
            {
                Console.WriteLine("생성 데이터 : " + user);
            }
            Console.ReadLine();
        }
    }
}
