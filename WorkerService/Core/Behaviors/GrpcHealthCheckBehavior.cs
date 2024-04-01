using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Health.V1;
using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading.Channels;

namespace WorkerService.Core.Behaviors
{
    public class GrpcHealthCheckBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly GrpcChannel _channel;
        private readonly ILogger<GrpcHealthCheckBehavior<TRequest, TResponse>> _logger;


        public GrpcHealthCheckBehavior(ILogger<GrpcHealthCheckBehavior<TRequest, TResponse>> logger, GrpcChannel channel)
        {
            _logger = logger;
            _channel = channel;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var client = new Health.HealthClient(_channel);
            var response = await client.CheckAsync(new HealthCheckRequest());
            var status = response.Status;

            _logger.LogInformation($"gRPC 상태 : {status}");

            return await next();
        }
    }
}
