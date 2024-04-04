using Grpc.Core;
using Polly;
using Polly.Retry;
using Polly.Timeout;

namespace WorkerService.Core.policies
{
    public class PolicyFactory
    {
        private readonly ILogger _logger;
        public PolicyFactory(ILogger logger) 
        {
            _logger = logger;
        }

        public async Task<AsyncRetryPolicy> RetryPolicy()
        {
            var retryPolicy = Policy
                    .Handle<RpcException>()
                    .RetryAsync(5, async (exception, retryCount, context) =>
                    {
                        _logger.LogInformation($"RpcException Retry : {retryCount}, Exception : {exception.Message}");
                        await Task.Delay( 1000 );
                    });

            return await Task.FromResult(retryPolicy);
        }

        public async Task<AsyncTimeoutPolicy> TimeOutPolicy()
        {
            var timeOutPolicy = Policy
                .TimeoutAsync(TimeSpan.FromSeconds(5), TimeoutStrategy.Pessimistic,
                async (context, timeSpan, task) =>
                {
                    _logger.LogInformation($"Retry TimeOut");
                    await Task.Delay( 500 );
                });

            return await Task.FromResult(timeOutPolicy);
        }
    }
}
