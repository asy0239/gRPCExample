using gRPCClient.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Grpc.Extension;

namespace gRPCClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
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