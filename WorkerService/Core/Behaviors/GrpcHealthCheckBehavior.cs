using Grpc.Core;
using Grpc.Health.V1;
using Grpc.Net.Client;
using MediatR;
using Polly;
using WorkerService.Core.policies;

namespace WorkerService.Core.Behaviors
{
    public class GrpcHealthCheckBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly GrpcChannel _channel;
        private readonly ILogger<GrpcHealthCheckBehavior<TRequest, TResponse>> _logger;
        private readonly PolicyFactory _policy;


        public GrpcHealthCheckBehavior(ILogger<GrpcHealthCheckBehavior<TRequest, TResponse>> logger, GrpcChannel channel, PolicyFactory policy)
        {
            _logger = logger;
            _channel = channel;
            _policy = policy;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var client = new Health.HealthClient(_channel);

            var retryPolicy = await _policy.RetryPolicy();
            var timeOutPolicy = await _policy.TimeOutPolicy();
            var policyWrap = retryPolicy.WrapAsync(timeOutPolicy);

            var response = await policyWrap.ExecuteAsync(async () => await client.CheckAsync(new HealthCheckRequest()));
            var status = response.Status;

            _logger.LogInformation($"gRPC 상태 : {status}");

            return await next();
        }
    }
}
