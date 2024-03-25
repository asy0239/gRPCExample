using Api.Greeter;
using Api.Users;
using Grpc.Net.Client;
using gRPCClient.ApiServices;
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
            IHost builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<ApiUserService>();
                    services.AddTransient<UserControl>();
                    services.AddSingleton<Application>();
                    services.AddGrpcClientChannel();
                }).Build(); 

            //builder.Run();
            Application app = builder.Services.GetRequiredService<Application>(); 
            app.Run();
        }
    }
}