using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Grpc.Extension
{
    public static class GrpcClientChannelExtension
    {
        public static IServiceCollection AddGrpcClientChannel(this IServiceCollection services)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7066");

            services.AddSingleton(channel);

            return services;
        }
    }
}
