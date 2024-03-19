using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCClient.Extensions
{
    public static class GrpcClientChannel
    {
        public static IServiceCollection AddGrpcClientChannel(this IServiceCollection services)
        {
            var loggerFactory = LoggerFactory.Create(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Debug);
            });
            var channel = GrpcChannel.ForAddress("https://localhost:7173");
            services.AddSingleton(channel);

            return services;
        }
    }
}
