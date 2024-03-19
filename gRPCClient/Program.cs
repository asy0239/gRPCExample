using Api.Greeter;
using Api.Users;
using Grpc.Net.Client;
using gRPCClient.Controllers;
using gRPCClient.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace gRPCClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var channel = GrpcChannel.ForAddress("https://localhost:7173");
            ////var customerClient = new Customer.CustomerClient(channel);

            ////var clientRequested = new CustomerLookupModel { UserId = 1 };

            ////var customer = await customerClient.GetCustomerInfoAsync(clientRequested);


            ////Console.WriteLine($"{customer.FirstName} {customer.LastName}");

            //var greeterClient = new Greeter.GreeterClient(channel);

            //var greeterRequested = new HelloRequest() { Name = "asyHello"};

            //var reply = await greeterClient.SayHelloAsync(greeterRequested);


            //Console.WriteLine(reply.Message);
            //Console.ReadLine();

            //var userClient = new UsersGrpc.UsersGrpcClient(channel);
            //var userRequest = new GetUserRequest();

            //var replyUser = await userClient.GetUsersAsync(userRequest);
            //Console.WriteLine(replyUser);
            //Console.ReadLine();
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices(services =>
            {
                services.AddGrpcClientChannel();
                services.AddTransient<UserController>();
            }).Build();
        }
    }
}