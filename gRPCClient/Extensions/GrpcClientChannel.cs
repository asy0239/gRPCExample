using Grpc.Core;
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

            var httpHandler = new HttpClientHandler();
            //httpHandler.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate(""));
            //var channel = GrpcChannel.ForAddress("https://localhost:7066", new GrpcChannelOptions
            //{
            //    HttpHandler = httpHandler,
            //});
            var channel = GrpcChannel.ForAddress("https://localhost:7066");

            services.AddSingleton(channel);

            return services;
        }
    }
}
